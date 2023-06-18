using Carea.Models;

namespace Carea.BLL.Interface {
	public interface IShippingRep
	{
		IEnumerable<Shipping> Get();
		Shipping GetById(int id);
		void Create(Shipping obj);
		void Edit(Shipping obj);
		void Delete(Shipping obj);
	}
}
