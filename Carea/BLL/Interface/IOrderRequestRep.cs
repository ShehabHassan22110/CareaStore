using Carea.Models;

namespace Carea.BLL.Interface
{
    public interface IOrderRequestRep
    {
        IEnumerable<OrderRequest> Get();
        OrderRequest GetById(int id);
        void Creat(OrderRequest obj);
        void Edit(OrderRequest obj);
        void Delete(OrderRequest obj);
    }
}
