using Carea.BLL.Interface;
using Carea.Models;
using Microsoft.EntityFrameworkCore;

namespace Carea.BLL.Repo
	{
	public class ShippingRep:IShippingRep
	{
		private readonly ApplicationDbContext db;

		public ShippingRep(ApplicationDbContext db)
		{
			this.db = db;
		}
		public IEnumerable<Shipping> Get() {
			var All = db.Shipping.Select(a => a).Include("SubShipping");
			return All;
		}
		public Shipping GetById(int id) {
			var data = db.Shipping.Where(x => x.Id == id).FirstOrDefault();
			return data;
		}

		public void Create(Shipping obj) {
			db.Shipping.Add(obj);
			db.SaveChanges();

		}

		public void Delete(Shipping obj) {
			var olddata = db.Shipping.Find(obj.Id);
			db.Shipping.Remove(olddata);
			db.SaveChanges();
		}

		public void Edit(Shipping obj) {
			db.Entry(obj).State = EntityState.Modified;
			db.SaveChanges();
		}
	}
}
