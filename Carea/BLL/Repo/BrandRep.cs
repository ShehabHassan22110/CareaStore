using Carea.BLL.Interface;

using Carea.Models;
using Microsoft.EntityFrameworkCore;

namespace Carea.BLL.Repo
{
    public class BrandRep: IBrandRep
    {
        private readonly ApplicationDbContext db;
        public BrandRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Brand> Get()
        {
            var All = db.Brand.Select(a => a).Include("Cars");
            return All;
        }
        public Brand GetById(int id)
        {
            var data = db.Brand.Where(x => x.Id == id).Include("Cars").FirstOrDefault();
            return data;
        }

        public void Creat(Brand obj)
        {
            db.Brand.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Brand obj)
        {
            var olddata = db.Brand.Find(obj.Id);
            db.Brand.Remove(olddata);
            db.SaveChanges();
        }

        public void Edit(Brand obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
