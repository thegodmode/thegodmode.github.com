using System;
using System.Net.Http;
using System.Transactions;
using BlogWebAPi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using ForumWebApi.Models.Users;
using BlogWebAPi.Models.Users;
using BlogWebAPi.Models.Posts;
using BlogWebAPi.Models.Tags;
using System.Linq;

namespace Forum.Tests
{
    [TestClass]
    public class PostsByTagsIntegrationTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "PostsByTagApi",
                    "api/tags/{tagId}/posts",
                    new
                {
                    controller = "tags",
                    action = "getposts"
                }),
                new Route(
                    "CommentPostApi",
                    "api/posts/{postId}/comment",
                    new
                {
                    controller = "posts",
                    action = "addComment"
                }),
                new Route(
                    "PosttApi",
                    "api/posts/{page}/{tags}",
                    new
                {
                    controller = "posts",
                    action = "tags"
                }),
                new Route(
                    "UsertApi",
                    "api/users/{action}",
                    new
                {
                    controller = "users"
                }),
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional })
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetPostByTagFromDb_WithValidTags_CheckIfAreCorrect()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var post = new PostFullModel()
            {
                Title = "newtag",
                Text = "Full text",
                Tags = new List<string>()
                {
                    "tagtag"
                }
            };

            string tags = "newtag,tagtag";
            List<string> taglist = new List<string> { "newtag", "tagtag" };

            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
          
            httpServer.Post("api/posts", post, headers);

            var response = httpServer.Get("api/posts?tags=" + tags, headers);

            var responseString = response.Content.ReadAsStringAsync().Result;

            var postsModels = JsonConvert.DeserializeObject<IEnumerable<PostFullModel>>(responseString);
            foreach (var p in postsModels)
            {
                List<string> postTags = new List<string>();
                postTags.AddRange(p.Tags);
                foreach (var item in taglist)
                {
                    Assert.IsTrue(postTags.Contains(item));
                }
            }
        }

        [TestMethod]
        public void GetPostByTagFromDb_WithNoExistedTags_CheckIfAreCorrect()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var post = new PostFullModel()
            {
                Title = "This",
                Text = "Full text",
                Tags = new List<string>()
                {
                    "is"
                }
            };

            string tags = "newtag,tagtag";
            List<string> taglist = new List<string> { "newtag", "tagtag" };

            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var response = httpServer.Get("api/posts?tags=" + tags, headers);

            var responseString = response.Content.ReadAsStringAsync().Result;

            IEnumerable<PostFullModel> postsModels = JsonConvert.DeserializeObject<IEnumerable<PostFullModel>>(responseString);
            Assert.IsTrue(postsModels.Count() == 0);
        }

        [TestMethod]
        public void GetPostByTagFromDb_CheckOrder()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var post = new PostFullModel()
            {
                Title = "This",
                Text = "Full text",
                Tags = new List<string>()
                {
                    "is"
                }
            };

            string tags = "this,is";
           
            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            
            httpServer.Post("api/posts", post, headers);

            var response = httpServer.Get("api/posts?tags=" + tags, headers);

            var responseString = response.Content.ReadAsStringAsync().Result;

            var postsModels = JsonConvert.DeserializeObject<IEnumerable<PostFullModel>>(responseString);

            var dateTime = DateTime.MinValue;
            foreach (var p in postsModels)
            {
                Assert.IsTrue(p.PostDate > dateTime);
                dateTime = p.PostDate;
            }

          
        }


        //[TestMethod]
        //public void Create_ValidPost_CheckTagsIsCorrectInDB()
        //{
        //    var testUser = new UserLogginModel()
        //    {
        //        UserName = "VALIDUSER",
        //        NickName = "VALIDNICK",
        //        AuthCode = new string('b', 40)
        //    };

        //    var post = new PostFullModel()
        //    {
        //        Title = "newtag",
        //        Text = "Full text",
        //        Tags = new List<string>()
        //        {
        //            "tagtag"
        //        }
        //    };

        //    List<string> inputTags = new List<string>() { "test", "post" };

        //    UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
        //    var headers = new Dictionary<string, string>();
        //    headers["X-sessionKey"] = userModel.SessionKey;

        //    var response = httpServer.Post("api/posts", post, headers);

        //    var tags = httpServer.Get("api/tags", headers);
        //    var tagsString = tags.Content.ReadAsStringAsync().Result;

        //    var tagsModels = JsonConvert.DeserializeObject<IEnumerable<TagModel>>(tagsString);
        //    foreach (var tag in tagsModels)
        //    {
        //        if (inputTags.Contains(tag.Name))
        //        {
        //            Assert.IsTrue(tag.PostNumber > 0);
        //        }
        //    }
        //}

        //[TestMethod]
        //public void Create_ValidPost_ShouldSaveInDB()
        //{
        //    var testUser = new UserLogginModel()
        //    {
        //        UserName = "VALIDUSER",
        //        NickName = "VALIDNICK",
        //        AuthCode = new string('b', 40)
        //    };

        //    var post = new PostFullModel()
        //    {
        //        Title = "Test",
        //        Text = "Full text",
        //        Tags = new List<string>()
        //        {
        //            "post"
        //        }
        //    };

        //    UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
        //    var headers = new Dictionary<string, string>();
        //    headers["X-sessionKey"] = userModel.SessionKey;

        //    var response = httpServer.Post("api/posts", post, headers);
        //    var contentString = response.Content.ReadAsStringAsync().Result;

        //    var postModel = JsonConvert.DeserializeObject<PostShortModel>(contentString);
        //    Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        //    Assert.IsTrue(postModel.Id > 0);
        //    Assert.AreEqual(postModel.Title, post.Title);

        //}

        //[TestMethod]
        //public void Create_NullPost_ShouldThrowException()
        //{
        //    var testUser = new UserLogginModel()
        //    {
        //        UserName = "VALIDUSER",
        //        NickName = "VALIDNICK",
        //        AuthCode = new string('b', 40)
        //    };

        //    PostFullModel post = null;

        //    UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
        //    var headers = new Dictionary<string, string>();
        //    headers["X-sessionKey"] = userModel.SessionKey;

        //    var response = httpServer.Post("api/posts", post, headers);
        //    var contentString = response.Content.ReadAsStringAsync().Result;

        //    var postModel = JsonConvert.DeserializeObject<PostShortModel>(contentString);
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        //}

        private UserResponseModel RegisterTestUser(InMemoryHttpServer httpServer, UserLogginModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<UserResponseModel>(contentString);
            return userModel;
        }
    }
}