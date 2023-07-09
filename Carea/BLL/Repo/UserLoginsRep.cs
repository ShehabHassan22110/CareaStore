using Carea.BLL.Interface;
using Carea.Models;
using Carea.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Carea.BLL.Repo
{
    public class UserLoginsRep : IUserLoginsRep 
    {
        private readonly ApplicationDbContext db;
        public UserLoginsRep(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UserLogins> Get()
        {
            var All = db.UserLogins.Select(a => a);
            return All;
        }
        public UserLogins GetById(string  userid)
        {
            var data = db.UserLogins.Where(x => x.UserId == userid).LastOrDefault();
            return data;
        }

        public void Creat(UserLogins obj)
        {
            db.UserLogins.Add(obj);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var olddata = db.UserLogins.Find(id);
            db.UserLogins.Remove(olddata);
            db.SaveChanges();
        }

    }
}
