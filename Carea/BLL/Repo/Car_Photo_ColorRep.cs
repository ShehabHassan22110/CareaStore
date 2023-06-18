using Carea.BLL.Interface;

using Microsoft.EntityFrameworkCore;
using Carea.Models;

namespace Carea.BLL.Repo
{
    public class Car_Photo_ColorRep: ICar_Photo_ColorRep
    {
        private readonly ApplicationDbContext db;
        public Car_Photo_ColorRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Car_Photo_Color> Get()
        {
            var All = db.Car_Photo_Color.Select(a => a);
            return All;
        }
        public Car_Photo_Color GetById(int id)
        {
            var data = db.Car_Photo_Color.Where(x => x.Id == id).Include("Cars").FirstOrDefault();
            return data;
        }

        public void Creat(Car_Photo_Color obj)
        {
            db.Car_Photo_Color.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Car_Photo_Color obj)
        {
            var olddata = db.Car_Photo_Color.Find(obj.Id);
            db.Car_Photo_Color.Remove(olddata);
            db.SaveChanges();
        }

        public void Edit(Car_Photo_Color obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
