using Carea.BLL.Interface;
using Carea.Models;
using Carea.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Carea.BLL.Repo
{
    public class CarsRep: ICarsRep
    {
        private readonly ApplicationDbContext db;
        public CarsRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<CarsVM> Get()
        {
            var All = db.Cars.Include("Brand").Select(a => new CarsVM
            {
                Id = a.Id,
                Car_Desc = a.Car_Desc,
                Brand_Id = a.Brand_Id,
                Car_Model = a.Car_Model,
                Car_Name = a.Car_Name,
                Car_Price = a.Car_Price,
                Is_Used = a.Is_Used,
                Rates_Number = a.Car_Rate.Count(),
                Rate = a.Car_Rate.Average(a => a.Rate),
                Brand = a.Brand,
                Car_Photo_Color = a.Car_Photo_Color,
            }).OrderByDescending(a => a.Car_Price);
            
            return All;
        }
        public Cars GetById(int id)
        {
            var data = db.Cars.Where(x => x.Id == id).Include("Brand").Include("Car_Photo_Color").FirstOrDefault();
            return data;
        }

        public void Creat(Cars obj)
        {
            db.Cars.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Cars obj)
        {
            var olddata = db.Cars.Find(obj.Id);
            db.Cars.Remove(olddata);
            db.SaveChanges();
        }

        public void Edit(Cars obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
