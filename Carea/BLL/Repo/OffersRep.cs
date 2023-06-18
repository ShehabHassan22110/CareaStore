using Carea.BLL.Interface;
using Carea.Models;
using Microsoft.EntityFrameworkCore;

namespace Carea.BLL.Repo {
	public class OffersRep: IOffersRep
	{
			private readonly ApplicationDbContext db;
			public OffersRep(ApplicationDbContext db) {
				this.db = db;
			}
			public IEnumerable<Offers> Get() {
				var All = db.Offers.Select(a => a).Include("Cars");
				return All;
			}
			public Offers GetById(int id) {
				var data = db.Offers.Where(x => x.Id == id).Include("Cars").FirstOrDefault();
				return data;
			}

			public void Creat(Offers obj) {
				db.Offers.Add(obj);
				db.SaveChanges();

			}

			public void Delete(Offers obj) {
				var olddata = db.Offers.Find(obj.Id);
				db.Offers.Remove(olddata);
				db.SaveChanges();
			}

			public void Edit(Offers obj) {
				db.Entry(obj).State = EntityState.Modified;
				db.SaveChanges();
			}
		}
}
