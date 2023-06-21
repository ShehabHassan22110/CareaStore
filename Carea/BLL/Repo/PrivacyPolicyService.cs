using Carea.Entities;
using Carea.Interfaces;
using Carea.Models;
using Microsoft.EntityFrameworkCore;

namespace Carea.Services {
	public class PrivacyPolicyService: IPrivacyPolicyService
	{
		private readonly ApplicationDbContext db;
		public PrivacyPolicyService( ApplicationDbContext db ) {
			this.db = db;
		}
		public IEnumerable<PrivacyPolicy> Get() {
			var All = db.PrivacyPolicy.Select(a => a);
			return All;
		}
		public PrivacyPolicy GetById(int id) {
			var data = db.PrivacyPolicy.Where(x => x.Id == id).FirstOrDefault();
			return data;
		}

		public void Create(PrivacyPolicy obj) {
			db.PrivacyPolicy.Add(obj);
			db.SaveChanges();

		}

		public void Delete(PrivacyPolicy obj) {
			var olddata = db.PrivacyPolicy.Find(obj.Id);
			db.PrivacyPolicy.Remove(olddata);
			db.SaveChanges();
		}

		public void Edit(PrivacyPolicy obj) {
			db.Entry(obj).State = EntityState.Modified;
			db.SaveChanges();
		}
	}
}
