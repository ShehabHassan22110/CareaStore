using Carea.Api_s.Models;
using Carea.Models;
using Carea.ViewModels;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Carea.Api_s.Interfaces
{
    public interface IOffersApiRep
    {
        public IEnumerable<OffersApiModel> GetAllOfferss();
        public OffersApiModel GetById(int id);
    }
    public class OffersApiRep : IOffersApiRep
    {
        private readonly ApplicationDbContext db;
        public OffersApiRep(ApplicationDbContext db)
        {
            this.db = db; 
        }
        public OffersApiModel GetById(int id)
        {

            var data = db.Offers.Include("Cars.Car_Photo_Color")
                .Include("Cars.Brand")
                .Include("Cars.Car_Rate")
                .Include("Cars.Car_Rate.ApplicationUser")
                .Where(a => a.Id == id).Select(a => new OffersApiModel
            {
                CarData=a.Cars,
                offerId = a.Id,
                CarId = a.Cars.Id,
                Discount = a.Discount,
               Description=a.Description,
                Title = a.Title,


            }).FirstOrDefault();

            return data;

        }
        public IEnumerable<OffersApiModel> GetAllOfferss()
        {

            var data = db.Offers
                .Include("Cars.Car_Photo_Color")
                .Include("Cars.Brand")
                .Include("Cars.Car_Rate")
                .Include("Cars.Car_Rate.ApplicationUser")

                .Select(a => new OffersApiModel
            {

                offerId = a.Id,
                CarId = a.Cars.Id,

                Discount = a.Discount,
                Description = a.Description,
                Title = a.Title,
                CarData = a.Cars,

                


            });

            return data;

        }


    }
}
