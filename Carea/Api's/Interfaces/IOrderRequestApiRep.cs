using Carea.Extend;
using Carea.Models;
using Carea.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Carea.Api_s.Interfaces
{
    public interface IOrderRequestApiRep
    {
        public OrderRequest Creat(OrderRequestVM obj);
         Task<IEnumerable<OrderRequestVM>> GetbyUserId(string UserId);
        public OrderRequest Edite(OrderRequestVM obj);
        public OrderRequestVM GetbycarUserId(int carId, string userId);
        public void Delete(int RequestOrderId);
         Task<IEnumerable<OrderRequestVM>> GetOldRequestsbyUserId(string UserId);
    }
    public class OrderRequestApiRep : IOrderRequestApiRep
    {
        private readonly ApplicationDbContext db;
        private UserManager<ApplicationUser> _userManger;
        public OrderRequestApiRep(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            _userManger = userManager;
        }

        public OrderRequest Creat(OrderRequestVM obj)
        {
            OrderRequest rate = new OrderRequest();
            rate.ApplicationUserId = obj.ApplicationUserId;
            rate.CarId = obj.CarId;
            rate.OfferdPrice = obj.OfferdPrice;
            rate.Statues = 0;
         

            db.OrderRequest.Add(rate);
            db.SaveChanges();

            var data = db.OrderRequest.OrderBy(a => a.Id).LastOrDefault();
            return data;
        }
        public OrderRequest Edite(OrderRequestVM obj)
        {
            var OldData = db.OrderRequest.Find(obj.Id);

            return OldData;
        }

        public async Task<IEnumerable<OrderRequestVM>> GetbyUserId(string UserId)
        {

            var data = db.OrderRequest.Include("Cars.Car_Photo_Color")
                .Include("Cars.Brand")
                .Include("Cars.Car_Rate")
                .Include("Cars.Car_Rate.ApplicationUser")
                .Where(a => a.ApplicationUserId == UserId && a.Statues<3).Select(a => new OrderRequestVM
            {
                Id = a.Id,
                OfferdPrice = a.OfferdPrice,
                Statues=a.Statues,
                CarId=a.CarId,
                Cars = a.Cars,
                ApplicationUser = a.ApplicationUser,

            });

            return data;
        }
        public async Task<IEnumerable<OrderRequestVM>> GetOldRequestsbyUserId(string UserId)
        {

            var data = db.OrderRequest.Include("Cars.Car_Photo_Color")
                .Include("Cars.Brand")
                .Include("Cars.Car_Rate")
                .Include("Cars.Car_Rate.ApplicationUser")
                .Where(a => a.ApplicationUserId == UserId && a.Statues==3).Select(a => new OrderRequestVM
            {
                Id = a.Id,
                OfferdPrice = a.OfferdPrice,
                Statues=a.Statues,
                CarId=a.CarId,
                Cars = a.Cars,
                ApplicationUser = a.ApplicationUser,

            });

            return data;
        }
        public OrderRequestVM GetbycarUserId(int carId, string userId)
        {

            var data = db.OrderRequest.Include("Cars.Car_Photo_Color")
                .Include("Cars.Brand")
                .Include("Cars.Car_Rate")
                 .Include("Cars.Car_Rate.ApplicationUser")
.Where(a => a.CarId == carId && a.ApplicationUserId == userId).Select(a => new OrderRequestVM
            {
                Id = a.Id,
                OfferdPrice=a.OfferdPrice,
                Statues = a.Statues,
                CarId = a.CarId,

                Cars = a.Cars,
                ApplicationUser=a.ApplicationUser,

            }).FirstOrDefault();

            return data;
        }


        public void Delete( int RequestOrderId)
        {
            var data = db.OrderRequest.Where(a=>a.Id == RequestOrderId).FirstOrDefault();
            db.OrderRequest.Remove(data);
            db.SaveChanges();
        }

    }
}
