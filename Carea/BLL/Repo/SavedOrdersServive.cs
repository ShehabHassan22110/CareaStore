using Carea.BLL.Interface;
using Carea.Models;
using Microsoft.EntityFrameworkCore;

namespace Carea.BLL.Repo 
    {
    public class CreateOrderServive : ICreateOrderRep
    {
        private readonly ApplicationDbContext db;

        public CreateOrderServive(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<CreateOrder> Get()
        {
            var All = db.CreateOrder.Select(a => a);
            return All;
        }
        public CreateOrder GetById(int id)
        {
            var data = db.CreateOrder.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Create(CreateOrder obj)
        {
            db.CreateOrder.Add(obj);
            db.SaveChanges();

        }

        public void Delete(CreateOrder obj)
        {
            var olddata = db.CreateOrder.Find(obj.Id);
            db.CreateOrder.Remove(olddata);
            db.SaveChanges();
        }

        public void Edit(CreateOrder obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
