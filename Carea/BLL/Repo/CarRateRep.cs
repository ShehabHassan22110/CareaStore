using Carea.BLL.Interface;
using Carea.Models;
using Carea.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Carea.BLL.Repo
{
    public class CarRateRep: ICarRateRep
    {
        private readonly ApplicationDbContext db;
        public CarRateRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        public IEnumerable<Car_Rate> Get()
        {
            var All = db.Car_Rate.Select(a => a).Include("Cars");
            return All;
        }
        public Car_Rate GetById(int id , string userId)
        {
            var data = db.Car_Rate.Where(x => x.CarId == id&&x.UserId== userId).FirstOrDefault();
            return data;
        }

        public void Creat(Car_Rate obj)
        {
            db.Car_Rate.Add(obj);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var olddata = db.Car_Rate.Find(id);
            db.Car_Rate.Remove(olddata);
            db.SaveChanges();
        }

        public void Edit(Car_RateVM obj)
        {
           var newobj  = new Car_Rate
            {
               Id = obj.Id, 
               UserId = obj.UserId, 
               CarId = obj.CarId,
               Comment =obj.Comment,
               Rate = obj.Rate, 

            };
            db.Entry(newobj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
