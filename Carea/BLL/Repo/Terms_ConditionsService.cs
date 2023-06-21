using Carea.Entities;
using Carea.Interfaces;
using Carea.Models;
using Carea.Models;
using Microsoft.EntityFrameworkCore;

namespace Carea.Services
{
    
        public class Terms_ConditionsService : ITerms_ConditionsSevice
        {
            private readonly ApplicationDbContext db;
            public Terms_ConditionsService( ApplicationDbContext db )
            {
                this.db = db;
            }
            public IEnumerable<Terms_Conditions> Get()
            {
                var All = db.Terms_Conditions.Select(a => a);
                return All;
            }
            public Terms_Conditions GetById(int id)
            {
                var data = db.Terms_Conditions.Where(x => x.Id == id).FirstOrDefault();
                return data;
            }

            public void Create(Terms_Conditions obj)
            {
                db.Terms_Conditions.Add(obj);
                db.SaveChanges();

            }

            public void Delete(Terms_Conditions obj)
            {
                var olddata = db.Terms_Conditions.Find(obj.Id);
                db.Terms_Conditions.Remove(olddata);
                db.SaveChanges();
            }

            public void Edit(Terms_Conditions obj)
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
    

}
