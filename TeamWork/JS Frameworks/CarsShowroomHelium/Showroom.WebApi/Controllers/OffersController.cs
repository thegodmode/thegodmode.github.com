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
    using System.Web.Http;
    using System.Web.Http.ValueProviders;

    public class OffersController : BaseApiController
    {
        private IDbContextFactory<DbContext> contextFactory;

        public OffersController()
        {
            this.contextFactory = new ShowroomDbContextFactory();
        }

        public OffersController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [HttpPost]
        public HttpResponseMessage CreateOffer(CreateOfferModel offerModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
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

                        var car = new Car
                        {
                            Brand = context.Set<Brand>().Find(offerModel.Car.Brand),
                            Model = context.Set<Model>().Find(offerModel.Car.Model),
                            Color = context.Set<Color>().Find(offerModel.Car.Color),
                            EngineType = context.Set<Engine>().Find(offerModel.Car.Engine),
                            GearboxType = context.Set<Gearbox>().Find(offerModel.Car.Gearbox),
                            Mileage = offerModel.Car.Mileage,
                            Power = offerModel.Car.Power,
                            Year = offerModel.Car.Year,
                            Features = context.Set<Feature>().Select(f => f).Where(f => offerModel.Car.Features.Any(f1 => f.Name == f1)).ToList()
                        };

                        var offer = new Offer
                        {
                            Title = offerModel.Title,
                            Description = offerModel.Description,
                            DateCreated = DateTime.Now,
                            Location = offerModel.Location,
                            Price = offerModel.Price,
                            Email = offerModel.Email,
                            PhoneNumber = offerModel.PhoneNumber,
                            PictureUrl = offerModel.PictureUrl,
                            User = user,
                            Car = car
                        };

                        context.Set<Offer>().Add(offer);
                        context.SaveChanges();
                        var createdOffer = new OfferModel
                        {
                            Id = offer.Id,
                            Title = offer.Title
                        };

                        var response = this.Request.CreateResponse(HttpStatusCode.Created, createdOffer);
                        return response;
                    }
                });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<OfferModel> GetAllOffers([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
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

                    var allOffers = context.Set<Offer>().OrderBy(x => x.DateCreated).Select(OfferModel.FromOffer);

                    var response = allOffers;
                    return response;                    
                });

            return responseMsg;
        }

        [HttpPut]
        public void UpdateOfferById(FullOfferModel offerModel,[ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            PerformOperationAndHandleExceptions(() =>
            {
                var context = this.contextFactory.Create();
                ValidateSessionKey(sessionKey);

                var user = context.Set<User>().FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new ArgumentException("Invalid authentication");
                }

                var offer = context.Set<Offer>().FirstOrDefault(o => o.Id == offerModel.Id);

                offer.Description = offerModel.Description;
                offer.Title = offerModel.Title;

                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            });
        }

        [HttpGet]
        public FullOfferModel GetOfferById(int id, 
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
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

                var allOffers = context.Set<Offer>().Select(FullOfferModel.FromOffer).Where(x => x.Id==id).FirstOrDefault();

                var response = allOffers;
                return response;
            });

            return responseMsg;
        }
    }
}
