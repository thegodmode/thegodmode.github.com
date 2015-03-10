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
    public class UserRegisterTestIntegration
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
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            //var httpServer = new InMemoryHttpServer("http://localhost/");
            var model = this.RegisterTestUser(httpServer, testUser);
            Assert.AreEqual(testUser.NickName, model.NickName);
            Assert.IsNotNull(model.SessionKey);
            Assert.AreEqual(model.SessionKey.Length,49);
        }

        [TestMethod]
        public void Register_WhenAddSameUserTwice_ShouldTrowException()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            var response = httpServer.Post("api/users/register", testUser);
            var response1 = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response1.StatusCode);

        }

        [TestMethod]
        public void Register_AddingInvalidUserAuthCode_ShouldTrowException()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "VALIDUSER",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 20)
            };
            var response = httpServer.Post("api/users/register", testUser);
        
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void Register_AddingInvalidUserName_ShouldTrowException()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "Pesho Kirov",
                NickName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void Register_AddingInvalidUserNickName_ShouldTrowException()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "Pesho",
                NickName = "???DJS? ",
                AuthCode = new string('b', 40)
            };
            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void Register_AddingNullUser_ShouldTrowException()
        {
            UserLogginModel testUser = null;
            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void Register_AddingUserWithEmptyName_ShouldTrowException()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "",
                NickName = "Dancho",
                AuthCode = new string('b', 40)
            };
            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void Register_AddingUserWithEmptyNickName_ShouldTrowException()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "Pesho",
                NickName = "",
                AuthCode = new string('b', 40)
            };
            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void Register_AddingUserWithEmptyAuthocode_ShouldTrowException()
        {
            var testUser = new UserLogginModel()
            {
                UserName = "Pesho",
                NickName = "Pesho Ovcata",
                AuthCode = ""
            };
            var response = httpServer.Post("api/users/register", testUser);

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