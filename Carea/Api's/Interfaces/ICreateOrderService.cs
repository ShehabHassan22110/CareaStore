using Carea.ViewModels;

namespace Carea.Api_s.Interfaces {
	public interface ICreateOrderService
	{
		Task<IEnumerable<CreateOrderVM>> CreateOrderByUserIdAndItemId(string UserId, int CreateOrderId);
		IEnumerable<CreateOrderVM> GetByApplcationUserId(string Userid);
		IEnumerable<CreateOrderVM> GetByOrderStatus(string Status);
		public void Delete(string ApplicationUserId, int ProductId);
		public void Create(CreateOrderVM obj);
	}
}
