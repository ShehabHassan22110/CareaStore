using Carea.Models;

namespace Carea.BLL.Interface {
	public interface IOffersRep
	{
		IEnumerable<Offers> Get();
		Offers GetById(int id);
		void Creat(Offers obj);
		void Edit(Offers obj);
		void Delete(Offers obj);
	}
}
