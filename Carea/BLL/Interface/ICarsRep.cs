
using Carea.Models;
using Carea.ViewModels;

namespace Carea.BLL.Interface
{
    public interface ICarsRep
    {
        IEnumerable<CarsVM> Get();
        Cars GetById(int id);
        void Creat(Cars obj);
        void Edit(Cars obj);
        void Delete(Cars obj);
    }
}
