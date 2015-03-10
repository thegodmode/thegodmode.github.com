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

namespace Forum.Tests
{
    [TestClass]
    public class UserLogoutIntegrationTest
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
        public void Logout_WithValidSessionKey_()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Put("api/users/logout",null,headers);
            
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
           
        }

        [TestMethod]
        public void Logout_WithInvalidSessionKey_()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey+"d";
            var response = httpServer.Put("api/users/logout", headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void Logout_WithNullSessionKey()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = null;
            var response = httpServer.Put("api/users/logout", headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }



        //[TestMethod]
        //public void GetAll_WhenDataInDatabase_ShouldReturnData()
        //{
        //    var testUser = new UserLogginModel()
        //    {
        //        Username = "VALIDUSER",
        //        Nickname = "VALIDNICK",
        //        AuthCode = new string('b', 40)
        //    };
        //    UserResponseModel userModel = RegisterTestUser(httpServer, testUser);
        //    var headers = new Dictionary<string, string>();
        //    headers["X-sessionKey"] = userModel.SessionKey;
        //    var response = httpServer.Get("api/threads", headers);

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //    Assert.IsNotNull(response.Content);
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