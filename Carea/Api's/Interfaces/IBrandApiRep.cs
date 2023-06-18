using Carea.Models;
using Carea.ViewModels;

namespace Carea.Api_s.Interfaces
{
    public interface IBrandApiRep
    {
        public IEnumerable<BrandVM> GetAllBrands();
        public BrandVM GetById(int id);
    }
    public class BrandApiRep : IBrandApiRep
    {
        private readonly ApplicationDbContext db;
        public BrandApiRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public BrandVM GetById(int id)
        {

            var data = db.Brand.Where(a => a.Id == id).Select(a => new BrandVM
            {

                Id = a.Id,
                BrandName = a.BrandName,
                LogoUrl = "/Uploads/Brand/" + a.LogoUrl,
                Phone = a.Phone,
            }).FirstOrDefault();

            return data;

        }
        public IEnumerable<BrandVM> GetAllBrands()
        {

            var data = db.Brand.Select(a => new BrandVM
            {

                Id = a.Id,
                BrandName=a.BrandName,
                LogoUrl= "/Uploads/Brand/"+ a.LogoUrl,
                Phone=a.Phone,

              
            });

            return data;

        }


    }
}
