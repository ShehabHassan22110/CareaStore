using Carea.Models;
using Carea.ViewModels;

namespace Carea.BLL.Interface
{
    public interface ICarRateRep
    {
        IEnumerable<Car_Rate> Get();
        Car_Rate GetById(int id, string userId);
        void Creat(Car_Rate obj);
        void Edit(Car_RateVM obj);
        void Delete(int id);
    }
}
