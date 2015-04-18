using System.Web.Http.Cors;
using Greyhound.Data;
using System;
using System.Linq;
using System.Web.Http;

namespace GreyhoundAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RaceController : ApiController
    {
        private IGreyhoundData greyhoundData;
        public RaceController(IGreyhoundData greyhoundData)
        {
            this.greyhoundData = greyhoundData;
        }

        // GET api/race/getall
        public IHttpActionResult GetAll()
        {
            var UpcomingEvents = this.greyhoundData.UpcomingEvents.All();
            return Ok(UpcomingEvents);
        }

    }
}
