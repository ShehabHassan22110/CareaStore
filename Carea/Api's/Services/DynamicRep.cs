using Carea.Api_s.Interfaces;
using Carea.Interfaces;
using Carea.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace amal.Api_s.Services
{
    public class DynamicRep<T> : IDynamicRep<T> where T : class
    {
        private readonly ApplicationDbContext dBContext;

        public DynamicRep(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public T Create(T item)
        {
            dBContext.Set<T>().Add(item);
            dBContext.SaveChanges();
            return item;
        }

        public T Edit(T item)
        {
            dBContext.Set<T>().Update(item);
            dBContext.SaveChanges();
            return item;
        }

        public T Delete(T item)
        {
            dBContext.Set<T>().Remove(item);
            dBContext.SaveChanges();
            return item;
        }


        public IEnumerable<T> Get(string[] includes = null)
        {
            IQueryable<T> data = dBContext.Set<T>();

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    data = data.Include(item);
                }
            }

            return data;
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> data = dBContext.Set<T>();

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    data = data.Include(item);
                }
            }

            return data.Where(match);
        }



        public T GetById(int id)
        {
            var data = dBContext.Set<T>().Find(id);
            return data;
        }
        public T GetById(Expression<Func<T, bool>> match = null, string[] includes = null)
        {
            IQueryable<T> data = dBContext.Set<T>();

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    data = data.Include(item);
                }
            }
            return data.FirstOrDefault(match);
        }

        //public async Task<IEnumerable<SavedOrders>> GetAll(int userId = 0)
        //{
        //    return await dBContext.SavedOrders
        //        .Where(m => m.ApplicationUserId == userId || userId == 0)
        //        .Include(m => m.ApplicatonUser)
        //        .ToListAsync();
        //}


    }
}
