using System.Linq.Expressions;

namespace Carea.Api_s.Interfaces
{
	
        public interface IDynamicRep<T> where T : class
        {
        //Task<IEnumerable<SavedOrders>> GetAll(int userId = 0);


        IEnumerable<T> Get(string[] includes = null);
            IEnumerable<T> Get(Expression<Func<T, bool>> match, string[] includes = null);
            T GetById(int id);
            T GetById(Expression<Func<T, bool>> match, string[] includes = null);


            T Create(T item);
            T Edit(T item);
            T Delete(T item);
        }
    
}
