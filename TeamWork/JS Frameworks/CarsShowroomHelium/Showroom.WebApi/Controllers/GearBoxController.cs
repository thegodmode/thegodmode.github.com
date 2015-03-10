using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Showroom.Models;
using Showroom.WebApi.Models;

namespace Showroom.WebApi.Controllers
{
    public class GearBoxController : BaseApiController
    {
        private IDbContextFactory<DbContext> contextFactory;

        public GearBoxController()
        {
            contextFactory = new ShowroomDbContextFactory();
        }

        public GearBoxController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        [HttpGet]
        public GearboxModel GetModelById(int id)
        {
            var responseMsg = PerformOperationAndHandleExceptions(() =>
            {
                var context = contextFactory.Create();
                using (context)
                {
                    var gearbox = context.Set<Gearbox>().FirstOrDefault(g => g.Id == id);
                    return new GearboxModel()
                    {
                        Id = gearbox.Id,
                        Type = gearbox.Type
                    };
                }
            });
            return responseMsg;
        }
    }
}
