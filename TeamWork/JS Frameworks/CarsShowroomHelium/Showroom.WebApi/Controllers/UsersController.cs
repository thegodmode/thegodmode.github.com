using System.Collections;
using System.Collections.Generic;

namespace Showroom.WebApi.Controllers
{
    using Showroom.Models;
    using Showroom.WebApi.Attributes;
    using Showroom.WebApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;

    public class UsersController : BaseApiController
    {
        private IDbContextFactory<DbContext> contextFactory;

        private const int UsernameMinLenght = 5;
        private const int UsernameMaxLenght = 30;
        private const string UsernameValidCharacters = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890._";

        private const int AuthCodeLenght = 40;
        private const int SessionKeyLen = 50;
        private const string SessionKeyChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static Random rand = new Random();

        public UsersController()
        {
            this.contextFactory = new ShowroomDbContextFactory();
        }

        public UsersController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [HttpGet]
        [ActionName("profile")]
        public FullUserModel GetCurrentUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = this.contextFactory.Create();
                    ValidateSessionKey(sessionKey);

                    using (context)
                    {
                        var user = context.Set<User>().FirstOrDefault(usr => usr.SessionKey == sessionKey);
                        if (user == null)
                        {
                            throw new ArgumentException("Invalid authentication");
                        }

                        var userFullModel = new FullUserModel
                        {
                            Username = user.Username,
                            Offers = user.Offers.AsQueryable().Select(OfferModel.FromOffer).ToList()
                        };

                        return userFullModel;
                    }
                });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("all")]
        public IQueryable<UserAdminModel> GetAllUsers(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var context = this.contextFactory.Create();
            ValidateSessionKey(sessionKey);

            var user = context.Set<User>().FirstOrDefault(usr => usr.SessionKey == sessionKey);
            if (user == null || user.IsAdmin == false)
            {
                throw new ArgumentException("Invalid authentication");
            }

            var allUsers = context.Set<User>().OrderBy(us => us.Id).Skip(1).Select(UserAdminModel.FromUser);
            return allUsers;
        }

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(RegisterUserModel userModel)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.contextFactory.Create();
                using (context)
                {
                    ValidateUsername(userModel.Username);
                    ValidateAuthCode(userModel.AuthCode);

                    string usernameToLower = userModel.Username.ToLower();

                    var user = context.Set<User>().FirstOrDefault(usr => usr.Username == usernameToLower);

                    if (user != null)
                    {
                        throw new InvalidOperationException("User already exists in the database");
                    }

                    user = new User
                    {
                        Username = usernameToLower,
                        AuthCode = userModel.AuthCode,
                    };

                    context.Set<User>().Add(user);
                    context.SaveChanges();

                    user.SessionKey = GenerateSessionKey(user.Id);
                    context.SaveChanges();

                    var loggedModel = new LoggedUserModel
                    {
                        Username = user.Username,
                        SessionKey = user.SessionKey,
                      
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                    return response;
                }
            });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUnser(RegisterUserModel userModel)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.contextFactory.Create();
                using (context)
                {
                    ValidateUsername(userModel.Username);
                    ValidateAuthCode(userModel.AuthCode);

                    string usernameToLower = userModel.Username.ToLower();

                    var user = context.Set<User>().FirstOrDefault(usr => usr.Username == usernameToLower &&
                                                                         usr.AuthCode == userModel.AuthCode);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password");
                    }

                    if (user.SessionKey == null)
                    {
                        user.SessionKey = GenerateSessionKey(user.Id);
                        context.SaveChanges();
                    }

                    var loggedModel = new LoggedUserModel
                    {
                        Username = user.Username,
                        SessionKey = user.SessionKey,
                        IsAdmin = user.IsAdmin
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                    return response;
                }
            });

            return responseMsg;
        }


        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                ValidateSessionKey(sessionKey);
                var context = this.contextFactory.Create();
                using (context)
                {
                    var user = context.Set<User>().FirstOrDefault(usr => usr.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new ArgumentException("Invalid authentication");
                    }

                    user.SessionKey = null;
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
            });
            return responseMsg;
        }

        [HttpPut]
        [ActionName("update")]
        public void UpdateUsers(ICollection<UserAdminModel> users,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var context = this.contextFactory.Create();
            ValidateSessionKey(sessionKey);

            var user = context.Set<User>().FirstOrDefault(usr => usr.SessionKey == sessionKey);
            if (user == null || user.IsAdmin == false)
            {
                throw new ArgumentException("Invalid authentication");
            }

            foreach (var username in users)
            {
                var current = context.Set<User>().FirstOrDefault(usr => usr.Username == username.Username);
                current.IsAdmin = username.IsAdmin;
            }

            context.SaveChanges();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null)
            {
                throw new ArgumentNullException("Auth code cannot be null");
            }
            else if (authCode.Length != AuthCodeLenght)
            {
                throw new ArgumentOutOfRangeException("Password", "Auth code must be sha1 encrypted");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < UsernameMinLenght)
            {
                throw new ArgumentOutOfRangeException("Username",
                    string.Format("Username must be at least {0} characters long.", UsernameMinLenght));
            }
            else if (username.Length > UsernameMaxLenght)
            {
                throw new ArgumentOutOfRangeException("Username",
                    string.Format("Username must be less than {0} characters long.", UsernameMinLenght));
            }
            else if (username.Any(ch => !UsernameValidCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException("Username", "Username must contain only latin letters, digits .(dot) and _");
            }
        }

        private static string GenerateSessionKey(int userId)
        {
            StringBuilder keyChars = new StringBuilder(50);
            keyChars.Append(userId.ToString());
            while (keyChars.Length < SessionKeyLen)
            {
                int randomCharNum;
                lock (rand)
                {
                    randomCharNum = rand.Next(SessionKeyChars.Length);
                }
                char randomKeyChar = SessionKeyChars[randomCharNum];
                keyChars.Append(randomKeyChar);
            }
            string sessionKey = keyChars.ToString();
            return sessionKey;
        }
    }
}
