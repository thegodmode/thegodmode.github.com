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

    public class ModelsController : BaseApiController
    {
        private IDbContextFactory<DbContext> contextFactory;

        public ModelsController()
        {
            this.contextFactory = new ShowroomDbContextFactory();
        }

        public ModelsController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [HttpGet]
        public IQueryable<ModelsModel> GetAllModels(
            [ValueProvider(typeof (HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.contextFactory.Create();
                ValidateSessionKey(sessionKey);

                var user = context.Set<User>().FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new ArgumentException("Invalid authentication");
                }

                var allModels = context.Set<Model>().Select(ModelsModel.FromModel);                   

                var response = allModels;
                return response;
            });

            return responseMsg;
        }

        [HttpGet]
        public ModelsModel GetModelById(int id)
        {
            var responseMsg = PerformOperationAndHandleExceptions(() =>
            {
                var context = contextFactory.Create();
                using (context)
                {
                    var model = context.Set<Model>().FirstOrDefault(m => m.Id == id);
                    if (model == null)
                    {
                        throw new ArgumentException("Model does not exist");
                    }

                    return new ModelsModel
                    {
                        Id = model.Id,
                        Name = model.Name
                    };
                }
            });
            return responseMsg;
        }
    }
}
