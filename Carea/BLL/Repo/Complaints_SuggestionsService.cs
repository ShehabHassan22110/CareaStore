using Carea.Entities;
using Carea.Interfaces;
using Carea.Models;
using Carea.Models;
using Microsoft.EntityFrameworkCore;

namespace Carea.Services
{

    public class Complaints_SuggestionsService : IComplaints_SuggestionsService
    {
        private readonly ApplicationDbContext db;
        public Complaints_SuggestionsService( ApplicationDbContext db )
        {
            this.db = db;
        }
        public IEnumerable<Complaints_Suggestions> Get()
        {
            var All = db.Complaints_Suggestions.Select(a => a);
            return All;
        }
        public Complaints_Suggestions GetById(int id)
        {
            var data = db.Complaints_Suggestions.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Create(Complaints_Suggestions obj)
        {
            db.Complaints_Suggestions.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Complaints_Suggestions obj)
        {
            var olddata = db.Complaints_Suggestions.Find(obj.Id);
            db.Complaints_Suggestions.Remove(olddata);
            db.SaveChanges();
        }

        public void Edit(Complaints_Suggestions obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }


}

