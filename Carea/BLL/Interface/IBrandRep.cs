
using Carea.Models;

namespace Carea.BLL.Interface
{
    public interface IBrandRep
    {
        IEnumerable<Brand> Get();
        Brand GetById(int id);
        void Creat(Brand obj);
        void Edit(Brand obj);
        void Delete(Brand obj);
    }
}
