namespace Showroom.WebApi.Models
{
    using Showroom.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using System.Web;

    [DataContract]
    public class FullOfferModel : OfferModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "pictureUrl")]
        public string PictureUrl { get; set; }

        [DataMember(Name = "car")]
        public CarModel Car { get; set; }

        [DataMember(Name = "user")]
        public LoggedUserModel User { get; set; }
     
        //public ICollection<Comment> Comments { get; set; }

        public static Expression<Func<Offer, FullOfferModel>> FromOffer
        {
            get
            {
                return x => new FullOfferModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Car = new CarModel()
                    {
                        Brand = x.Car.Brand.Name,
                        Color = x.Car.Color.Name,
                        Engine = x.Car.EngineType.Type,
                        Features = (ICollection<string>)x.Car.Features.Select(f=>f.Name),
                        Gearbox = x.Car.GearboxType.Type,
                        Mileage = x.Car.Mileage,
                        Model = x.Car.Model.Name,
                        Power = x.Car.Power,
                        Year = x.Car.Year
                    },
                    DateCreated = x.DateCreated,
                    Description = x.Description,
                    Email = x.Email,
                    Location = x.Location,
                    PhoneNumber = x.PhoneNumber,
                    PictureUrl = x.PictureUrl,
                    Price = x.Price,
                    User = new LoggedUserModel()
                    {
                        Username = x.User.Username
                    }
                };
            }
        }
    }
}