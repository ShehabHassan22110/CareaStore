using Carea.Extend;
using Carea.Models;
using Carea.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;

namespace Carea.Api_s.Interfaces
{
    public interface ICar_RateApiRep
    {
        public Car_Rate Creat(Car_RateVM obj);
        Task<IEnumerable<Car_RateVM>> GetbycarIdAsync(int carId);
        public Car_Rate Edite(Car_RateVM obj);
        public Car_RateVM GetbycarUserId(int carId, string userId);
    }
    public class Car_RateApiRep : ICar_RateApiRep
    {
        private readonly ApplicationDbContext db;
        private UserManager<ApplicationUser> _userManger;
        public Car_RateApiRep(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            _userManger = userManager;
        }
     
        public Car_Rate Creat(Car_RateVM obj)
        {
            Car_Rate rate = new Car_Rate();
            rate.Id = obj.Id;
            rate.UserId = obj.UserId;
            rate.CarId = obj.CarId;
            rate.Rate = obj.Rate;
            rate.Comment = obj.Comment;
            rate.RateTime = DateTime.Now;
            db.Car_Rate.Add(rate);
            db.SaveChanges();

            var data = db.Car_Rate.OrderBy(a => a.Id).LastOrDefault();
            return data;
        }
          public Car_Rate Edite(Car_RateVM obj)
        {
            var OldData = db.Car_Rate.Find(obj.Id);

            OldData.UserId = obj.UserId;
            OldData.CarId = obj.CarId;
            OldData.Rate = obj.Rate;
            OldData.Comment = obj.Comment;
            OldData.RateTime = DateTime.Now;

            db.SaveChanges();

            return OldData;
        }

        public async Task<IEnumerable<Car_RateVM>> GetbycarIdAsync(int carId)
        {

            var data = db.Car_Rate.Where(a => a.CarId == carId).Select(a => new Car_RateVM
            {
                Id = a.Id,
                UserId = a.UserId,
                CarId = a.CarId,
                Rate = a.Rate,
                Comment = a.Comment,
                RateTime=a.RateTime,
                ApplicationUser = a.ApplicationUser,

            });
                     
 return data;
        }
        public Car_RateVM GetbycarUserId(int carId, string userId)
        {

            var data = db.Car_Rate.Where(a => a.CarId == carId && a.UserId == userId).Select(a => new Car_RateVM
            {
                Id = a.Id,
                UserId = a.UserId,
                CarId = a.CarId,
                Rate = a.Rate,
                Comment = a.Comment,
                RateTime = a.RateTime,
                ApplicationUser=a.ApplicationUser,
            }).FirstOrDefault();

            return data;
        }
    }
}
