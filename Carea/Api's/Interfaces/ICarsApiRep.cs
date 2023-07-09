using Carea.Models;
using Carea.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Carea.Api_s.Interfaces
{
    public interface ICarsApiRep
    {
        public IEnumerable<CarsVM> GetByBrandId(int brandId);
        public IEnumerable<CarsVM> SearchCars(string SearchValue);
        public IEnumerable<CarsVM> GetAllCars();
        public IEnumerable<CarsVM> GetTopRated();
        public CarsVM GetById(int id);
    }
    public class CarsApiRep : ICarsApiRep
    {
        private readonly ApplicationDbContext db;
        public CarsApiRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        static int getrate(int id) 
        {

            return 0;
        }
        public IEnumerable<CarsVM> GetByBrandId(int brandId)
        {
            var data = db.Cars.Include("Car_Rate.ApplicationUser").Where(a => a.Brand_Id == brandId).Select(a => new CarsVM
            {

             Id = a.Id,
             Car_Desc = a.Car_Desc,
             Brand_Id = a.Brand_Id,
             Car_Model=a.Car_Model,
             Car_Name=a.Car_Name,
             Car_Price=a.Car_Price,
             Is_Used=a.Is_Used,
             Car_Rate=a.Car_Rate,
             Leather_Interior = a.Leather_Interior,
             Turbo = a.Turbo,
             Engine_volume = a.Engine_volume,
             Cylinders = a.Cylinders,
             Levy = a.Levy,
             Wheel = a.Wheel,
             Drive_Wheels = a.Drive_Wheels,
			Gear_Box_Type = a.Gear_Box_Type,
			Doors = a.Doors,
			Car_FuelType = a.Car_FuelType,
			Category= a.Category,
			Airbags = a.Airbags,


			 Rates_Number = a.Car_Rate.Count(),
                Rate = a.Car_Rate.Average(a=>a.Rate),
                Brand =a.Brand,
             Car_Photo_Color=a.Car_Photo_Color,
            });
            return data;
        }
        public CarsVM GetById(int id)
        {

            var data = db.Cars.Include("Car_Rate.ApplicationUser").Where(a => a.Id == id).Select(a => new CarsVM
            {
                Id = a.Id,
                Car_Desc = a.Car_Desc,
                Brand_Id = a.Brand_Id,
                Car_Model = a.Car_Model,
                Car_Name = a.Car_Name,
                Car_Price = a.Car_Price,
                Is_Used = a.Is_Used,
                Car_Rate = a.Car_Rate,
				Leather_Interior = a.Leather_Interior,
				Turbo = a.Turbo,
				Engine_volume = a.Engine_volume,
				Cylinders = a.Cylinders,
				Levy = a.Levy,
				Wheel = a.Wheel,
				Drive_Wheels = a.Drive_Wheels,
				Gear_Box_Type = a.Gear_Box_Type,
				Doors = a.Doors,
				Car_FuelType = a.Car_FuelType,
				Category = a.Category,
				Airbags = a.Airbags,

				Rates_Number = a.Car_Rate.Count(),
                Rate = a.Car_Rate.Average(a => a.Rate),
                Brand = a.Brand,
                Car_Photo_Color = a.Car_Photo_Color,

            }).FirstOrDefault();

            return data;

        }
        public IEnumerable<CarsVM> GetAllCars()
        {

            var data = db.Cars.Include("Car_Rate.ApplicationUser").Select(a => new CarsVM
            {

                Id = a.Id,
                Car_Desc = a.Car_Desc,
                Brand_Id = a.Brand_Id,
                Car_Model = a.Car_Model,
                Car_Name = a.Car_Name,
                Car_Price = a.Car_Price,
                Is_Used = a.Is_Used,
                Car_Rate = a.Car_Rate,
				Leather_Interior = a.Leather_Interior,
				Turbo = a.Turbo,
				Engine_volume = a.Engine_volume,
				Cylinders = a.Cylinders,
				Levy = a.Levy,
				Wheel = a.Wheel,
				Drive_Wheels = a.Drive_Wheels,
				Gear_Box_Type = a.Gear_Box_Type,
				Doors = a.Doors,
				Car_FuelType = a.Car_FuelType,
				Category = a.Category,
				Airbags = a.Airbags,

				Rates_Number = a.Car_Rate.Count(),
                Rate = a.Car_Rate.Average(a => a.Rate),
                Brand = a.Brand,
                Car_Photo_Color = a.Car_Photo_Color,


            });

            return data;

        }
        public IEnumerable<CarsVM> SearchCars( string SearchValue)
        {

            var data = db.Cars.Include("Car_Rate.ApplicationUser").Select(a => new CarsVM
            {
                Id = a.Id,
                Car_Desc = a.Car_Desc,
                Brand_Id = a.Brand_Id,
                Car_Model = a.Car_Model,
                Car_Name = a.Car_Name,
                Car_Price = a.Car_Price,
                Is_Used = a.Is_Used,
                Car_Rate = a.Car_Rate,

				Leather_Interior = a.Leather_Interior,
				Turbo = a.Turbo,
				Engine_volume = a.Engine_volume,
				Cylinders = a.Cylinders,
				Levy = a.Levy,
				Wheel = a.Wheel,
				Drive_Wheels = a.Drive_Wheels,
				Gear_Box_Type = a.Gear_Box_Type,
				Doors = a.Doors,
				Car_FuelType = a.Car_FuelType,
				Category = a.Category,
				Airbags = a.Airbags,

				Rates_Number = a.Car_Rate.Count(),
                Rate = a.Car_Rate.Average(a => a.Rate),
                Brand = a.Brand,
                Car_Photo_Color = a.Car_Photo_Color,

            }).Where(a=>a.Car_Name.Contains(SearchValue)
            ||a.Car_Desc.Contains(SearchValue)
            ||a.Car_Model.Contains(SearchValue)
            ||a.Brand.BrandName.Contains(SearchValue));

            return data;

        }
        public IEnumerable<CarsVM> GetTopRated()
        {

            var data = db.Cars.Include("Car_Rate.ApplicationUser").Select(a => new CarsVM
            {

                Id = a.Id,
                Car_Desc = a.Car_Desc,
                Brand_Id = a.Brand_Id,
                Car_Model = a.Car_Model,
                Car_Name = a.Car_Name,
                Car_Price = a.Car_Price,
                Is_Used = a.Is_Used,
                Car_Rate = a.Car_Rate,
				Leather_Interior = a.Leather_Interior,
				Turbo = a.Turbo,
				Engine_volume = a.Engine_volume,
				Cylinders = a.Cylinders,
				Levy = a.Levy,
				Wheel = a.Wheel,
				Drive_Wheels = a.Drive_Wheels,
				Gear_Box_Type = a.Gear_Box_Type,
				Doors = a.Doors,
				Car_FuelType = a.Car_FuelType,
				Category = a.Category,
				Airbags = a.Airbags,

				Rates_Number = a.Car_Rate.Count(),
                Rate = a.Car_Rate.Average(a => a.Rate),
                Brand = a.Brand,
                Car_Photo_Color = a.Car_Photo_Color,

            }).OrderByDescending(a=>a.Rate);

            return data;

        }
        public double getrateavgbycarId(int id)
        {
            var total = db.Car_Rate.Where(a => a.CarId == id).Select(a => a.Rate).Sum();
            var number = db.Car_Rate.Where(a => a.CarId == id).Select(a => a.Rate).Count();
            var avg = total / number;

            return avg;

        }


    }
}
