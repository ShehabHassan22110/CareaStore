

using Carea.Models;

namespace Carea.BLL.Interface
    {
    public interface ICreateOrderServive
    {
        IEnumerable<CreateOrder> Get();
        CreateOrder GetById(int id);
        void Create(CreateOrder obj);
        void Edit(CreateOrder obj);
        void Delete(CreateOrder obj);
    }
}
