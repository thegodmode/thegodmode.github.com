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
using BlogWebAPi.Models.Comments;

namespace Forum.Tests
{
    [TestClass]
    public class LeaveCommentIntegrationTests
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
        public void AddComment_ToPost_CheckIfDBSaveIt()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var comment = new CommentShortModel()
            {
                Text = "TestComment"
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
       
            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var postResponse = httpServer.Post("api/posts", post, headers);
            var postString = postResponse.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostShortModel>(postString);
          
            httpServer.Put("api/posts/" + postModel.Id + "/comment",comment, headers);

            var postResponse1 = httpServer.Get("api/posts", headers);
            var postString1 = postResponse1.Content.ReadAsStringAsync().Result;
            var postsModels = JsonConvert.DeserializeObject<IEnumerable<PostFullModel>>(postString1);
            foreach (var p in postsModels)
            {
                if (p.Id == postModel.Id)
                {
                    Assert.IsTrue(p.Comments.Count() != 0);
                }
            }
        }

        //[TestMethod]
        //public void GetPostByTagFromDb_WithNoExistedTags_CheckIfAreCorrect()
        //{
        //    var testUser = new UserLogginModel()
        //    {
        //        UserName = "VALIDUSER",
        //        NickName = "VALIDNICK",
        //        AuthCode = new string('b', 40)
        //    };

        //    var post = new PostFullModel()
        //    {
        //        Title = "This",
        //        Text = "Full text",
        //        Tags = new List<string>()
        //        {
        //            "is"
        //        }
        //    };

        //    string tags = "newtag,tagtag";
        //    List<string> taglist = new List<string> { "newtag", "tagtag" };

        //    UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
        //    var headers = new Dictionary<string, string>();
        //    headers["X-sessionKey"] = userModel.SessionKey;

        //    var response = httpServer.Get("api/posts?tags=" + tags, headers);

        //    var responseString = response.Content.ReadAsStringAsync().Result;

        //    IEnumerable<PostFullModel> postsModels = JsonConvert.DeserializeObject<IEnumerable<PostFullModel>>(responseString);
        //    Assert.IsTrue(postsModels.Count() == 0);
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