using Carea.BLL.Interface;
using Carea.Models;
using Microsoft.EntityFrameworkCore;

namespace Carea.BLL.Repo
{
    public class OrderRequestRep: IOrderRequestRep
    {
        private readonly ApplicationDbContext db;
        public OrderRequestRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<OrderRequest> Get()
        {
            var All = db.OrderRequest.Select(a => a).Include("Cars").Include("ApplicationUser");
            return All;
        }
        public OrderRequest GetById(int id)
        {
            var data = db.OrderRequest.Where(x => x.Id == id).Include("Cars").Include("ApplicationUser").FirstOrDefault();
            return data;
        }

        public void Creat(OrderRequest obj)
        {
            db.OrderRequest.Add(obj);
            db.SaveChanges();

        }

        public void Delete(OrderRequest obj)
        {
            var olddata = db.OrderRequest.Find(obj.Id);
            db.OrderRequest.Remove(olddata);
            db.SaveChanges();
        }

        public void Edit(OrderRequest obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

