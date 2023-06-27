using Carea.Api_s.Interfaces;
using Carea.Models;
using Carea.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Carea.Api_s.Services {
	public class CreateOrderService:ICreateOrderService
	{
		private readonly ApplicationDbContext db;

		public CreateOrderService(ApplicationDbContext db)
        {
			this.db = db;
		}

		public void Create(CreateOrderVM obj) {

			CreateOrder order = new CreateOrder();
			order.Id = obj.Id;
			order.CarsId = obj.CarsId;
			order.ApplicationUserId = obj.ApplicationUserId;
			order.TAX = obj.TAX;
			order.ShippingId = obj.ShippingId;
			order.Amount = obj.Amount;
			order.Address = obj.Address;
			order.Status = obj.Status; 
			order.Payment = obj.Payment; 

			db.CreateOrder.Add(order);
			db.SaveChanges();
		}
		public void Delete(string ApplicationUserId, int OrderId) {
			var data = db.CreateOrder.Include("Cars.Car_Photo_Color")
                .Include("Cars.Brand")
                .Include("Cars.Car_Rate")
                .Include("Cars.Car_Rate.ApplicationUser").Where(a => a.ApplicationUserId == ApplicationUserId && a.Id == OrderId).FirstOrDefault();
			db.CreateOrder.Remove(data);
			db.SaveChanges();
		}

		public IEnumerable<CreateOrderVM> GetByApplcationUserId(string Userid) {
			var data = db.CreateOrder.Include("Cars.Car_Photo_Color")
                .Include("Cars.Brand")
                .Include("Cars.Car_Rate")
                .Include("Cars.Car_Rate.ApplicationUser").Where(a => a.ApplicationUserId == Userid)
				.Select(a => new CreateOrderVM {
					Id = a.Id,
					ApplicationUserId = a.ApplicationUserId,
					ApplicationUser = a.ApplicationUser,
					CarsId = a.CarsId,
					Cars= a.Cars,
					TAX = a.TAX,
					ShippingId = a.ShippingId,
					Shipping = a.Shipping,
					Amount = a.Amount,
					Address= a.Address,
                    Status = a.Status,
                    Payment = a.Payment

                }); 

			return data;

		}

		public async Task<IEnumerable<CreateOrderVM>> GetOrderByUserIdAndItemId(string UserId, int CreateOrderId) {
			var data = db.CreateOrder.Include("Cars.Car_Photo_Color")
                .Include("Cars.Brand")
                .Include("Cars.Car_Rate")
                .Include("Cars.Car_Rate.ApplicationUser").Where(a => a.ApplicationUserId == UserId && a.Id == CreateOrderId).Select(a => new CreateOrderVM {

				Id = a.Id,
				ApplicationUserId = a.ApplicationUserId,
				ApplicationUser = a.ApplicationUser,
				CarsId = a.CarsId,
				Cars = a.Cars,
				TAX = a.TAX,
				ShippingId = a.ShippingId,
				Shipping = a.Shipping,
				Amount = a.Amount,
				Address = a.Address,
                Status=a.Status,
				Payment = a.Payment


                });
			return data;

		}

		public IEnumerable<CreateOrderVM> GetByOrderStatus(string Status) {
			var data = db.CreateOrder.Include("Cars.Car_Photo_Color")
                .Include("Cars.Brand")
                .Include("Cars.Car_Rate")
               // .Include("Cars.Car_Rate.ApplicationUser").Where(a => a.Status == Status)
			   .Select(a => new CreateOrderVM {
				Id = a.Id,
				ApplicationUserId = a.ApplicationUserId,
				ApplicationUser = a.ApplicationUser,
				CarsId = a.CarsId,
				Cars = a.Cars,
				TAX = a.TAX,
				ShippingId = a.ShippingId,
				Shipping = a.Shipping,
				Amount = a.Amount,
				Address = a.Address,
				Status = a.Status,
                Payment = a.Payment
               });
			return data;

		}
	}
}
