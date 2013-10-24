namespace BlogWebAPi.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Net.Http;
    using System.Net;
    using System.Web.Http.ValueProviders;
    using BlogWebAPi.Attributes;
    using BlogWebAPi.Extensions;
    using ForumWebApi.Models.Users;
    using Blog.Model;
    using BlogWebAPi.Models.Users;

    public class UsersController : BaseApiController
    {
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody]
                                                UserLogginModel userModel)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var dbContext = new BlogContext();
                using (dbContext)
                {


                    UserValidator.ValidateUsername(userModel.UserName);
                    UserValidator.ValidateNickname(userModel.NickName);
                    UserValidator.ValidateAuthCode(userModel.AuthCode);

                    var user = dbContext.Users.Where(
                        x => x.Username == userModel.UserName ||
                             x.Displayname == userModel.NickName).FirstOrDefault();

                    if (user != null)
                    {
                        throw new InvalidOperationException("User Exist");
                    }

                    var userEntity = userModel.CreateUser();
                    dbContext.Users.Add(userEntity);

                    dbContext.SaveChanges();

                    userEntity.SessionKey = SessionKeyGenerator.Generate(userEntity.Id);
                    dbContext.SaveChanges();
                   

                    return this.Request.CreateResponse(HttpStatusCode.Created, new UserResponseModel
                    {
                        NickName = userModel.NickName,
                        SessionKey = userEntity.SessionKey
                    });
                }
            });
            
            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody]
                                             UserLogginModel userModel)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                  var dbContext = new BlogContext();
                  using (dbContext)
                  {
                      UserValidator.ValidateUsername(userModel.UserName);
                      UserValidator.ValidateAuthCode(userModel.AuthCode);

                      var user = dbContext.Users.Where(
                          x => x.Username == userModel.UserName &&
                               x.Authcode == userModel.AuthCode).FirstOrDefault();

                      if (user == null)
                      {
                          throw new InvalidOperationException("User doesn't Exist");
                      }

                      if (user.SessionKey == null)
                      {
                          user.SessionKey = SessionKeyGenerator.Generate(user.Id);
                          dbContext.SaveChanges();
                      }

                      return this.Request.CreateResponse(HttpStatusCode.OK, new UserResponseModel
                      {
                          NickName = user.Displayname,
                          SessionKey = user.SessionKey
                      });
                  }
            });
            return responseMsg;
        }

        [HttpPut]
        [ActionName("logout")]
        public void LogoutUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            this.PerformOperationAndHandleExceptions(() =>
            {
                 var dbContext = new BlogContext();
                 using (dbContext)
                 {

                     UserValidator.ValidateSessionKey(sessionKey);

                     var user = dbContext.Users.Where(
                         x => x.SessionKey == sessionKey).FirstOrDefault();

                     if (user.SessionKey != null)
                     {
                         user.SessionKey = null;
                         dbContext.SaveChanges();
                     }

                     return this.Request.CreateResponse(HttpStatusCode.OK);
                 }
            });
        }
    }
}