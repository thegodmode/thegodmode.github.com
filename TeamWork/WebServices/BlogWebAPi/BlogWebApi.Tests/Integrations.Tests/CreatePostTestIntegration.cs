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

namespace Forum.Tests
{
    [TestClass]
    public class CreatePostTestIntegration
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
        public void Create_ValidPost_CheckUserIsCorrectInDB()
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

            List<string> inputTags = new List<string>() { "test", "post" };

            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            httpServer.Post("api/posts", post, headers);

            var allposts = httpServer.Get("api/posts", headers);
            var tagsString = allposts.Content.ReadAsStringAsync().Result;

            var postsModels = JsonConvert.DeserializeObject<IEnumerable<PostFullModel>>(tagsString);
            foreach (var p in postsModels)
            {
                if (p.Title == post.Title)
                {
                    Assert.IsTrue(p.PostBy != null);
                }
            }
        }

        [TestMethod]
        public void Create_ValidPost_CheckTagsIsCorrectInDB()
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

            List<string> inputTags = new List<string>() { "test", "post" };

            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
           
            var response = httpServer.Post("api/posts", post, headers);
        
            var tags = httpServer.Get("api/tags", headers);
            var tagsString = tags.Content.ReadAsStringAsync().Result;

            var tagsModels = JsonConvert.DeserializeObject<IEnumerable<TagModel>>(tagsString);
            foreach (var tag in tagsModels)
            {
                if (inputTags.Contains(tag.Name))
                {
                    Assert.IsTrue(tag.PostNumber > 0);
                }
            }
        }

        [TestMethod]
        public void Create_ValidPost_ShouldSaveInDB()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var post = new PostFullModel()
            {
                Title = "Test",
                Text = "Full text",
                Tags = new List<string>()
                {
                    "post"
                }
            };

            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var response = httpServer.Post("api/posts", post, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;

            var postModel = JsonConvert.DeserializeObject<PostShortModel>(contentString);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsTrue(postModel.Id > 0);
            Assert.AreEqual(postModel.Title, post.Title);
           
        }

        [TestMethod]
        public void Create_NullPost_ShouldThrowException()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            PostFullModel post = null;

            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var response = httpServer.Post("api/posts", post, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;

            var postModel = JsonConvert.DeserializeObject<PostShortModel>(contentString);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

       
        private UserResponseModel RegisterTestUser(InMemoryHttpServer httpServer, UserLogginModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<UserResponseModel>(contentString);
            return userModel;
        }
    }
}