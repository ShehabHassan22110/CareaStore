
using Carea.Models;

namespace Carea.BLL.Interface
{
    public interface ICar_Photo_ColorRep
    {
        IEnumerable<Car_Photo_Color> Get();
        Car_Photo_Color GetById(int id);
        void Creat(Car_Photo_Color obj);
        void Edit(Car_Photo_Color obj);
        void Delete(Car_Photo_Color obj);
    }
}
