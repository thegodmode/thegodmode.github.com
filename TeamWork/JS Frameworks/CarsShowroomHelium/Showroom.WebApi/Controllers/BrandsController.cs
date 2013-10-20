namespace Showroom.WebApi.Controllers
{
    using Showroom.Models;
    using Attributes;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;

    public class BrandsController : BaseApiController
    {
        private IDbContextFactory<DbContext> contextFactory;

        public BrandsController()
        {
            contextFactory = new ShowroomDbContextFactory();
        }

        public BrandsController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [HttpGet]
        public IQueryable<BrandsModel> GetAllBrands(
            [ValueProvider(typeof (HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = PerformOperationAndHandleExceptions(() =>
            {
                var context = contextFactory.Create();
                ValidateSessionKey(sessionKey);

                var user = context.Set<User>().FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new ArgumentException("Invalid authentication");
                }

                var allBrands = context.Set<Brand>().Select(b =>
                    new BrandsModel()
                    {
                        Id = b.Id,
                        Name = b.Name
                    });

                var response = allBrands;
                return response;
            });

            return responseMsg;
        }

        [HttpGet]
        public string GetBrandById(int id)
        {
            var responseMsg = PerformOperationAndHandleExceptions(() =>
            {
                var context = contextFactory.Create();
                using (context)
                {
                    var brand = context.Set<Brand>().FirstOrDefault(b => b.Id == id);
                    return brand.Name;
                }
            });
            return responseMsg;
        }
    }
}
