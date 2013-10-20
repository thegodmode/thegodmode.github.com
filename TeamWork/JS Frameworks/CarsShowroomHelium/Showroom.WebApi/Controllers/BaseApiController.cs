namespace Showroom.WebApi.Controllers
{
    using System;    
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        private const int SessionKeyLen = 50;
        private const string SessionKeyChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        protected T PerformOperationAndHandleExceptions<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                var response = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(response);
            }
        }

        protected static void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey.Length != SessionKeyLen || sessionKey.Any(ch => !SessionKeyChars.Contains(ch)))
            {
                throw new ArgumentException("Invalid Password"); 
            }
        }
    }
}
