namespace Showroom.WebApi.Controllers
{
    using Showroom.Models;
    using Showroom.WebApi.Attributes;
    using Showroom.WebApi.Models;
    using System;    
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;

    public class ColorsController : BaseApiController
    {
        private IDbContextFactory<DbContext> contextFactory;

        public ColorsController()
        {
            this.contextFactory = new ShowroomDbContextFactory();
        }

        public ColorsController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [HttpGet]
        public IQueryable<ColorModel> GetAllColors(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = this.contextFactory.Create();
            ValidateSessionKey(sessionKey);
            var user = context.Set<User>().FirstOrDefault(u => u.SessionKey == sessionKey);
            if (user == null)
            {
                throw new ArgumentException("Invalid authentication");
            }

            var allColorts = context.Set<Color>().Select(ColorModel.FromColor);
            return allColorts;

        }

        [HttpGet]
        public ColorModel GetColorById(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var color = this.GetAllColors(sessionKey).Where(c => c.Id == id).FirstOrDefault();
            return color;
        }
    }
}
