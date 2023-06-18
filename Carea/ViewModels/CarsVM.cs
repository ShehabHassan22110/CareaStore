using Carea.Models;

namespace Carea.ViewModels
{
    public class CarsVM:Cars
    {
        //public CarsVM()
        //{
        //    Rate = Car_Rate.Average(a => a.Rate);
        //}
        public int Rates_Number { get; set; } = 0;
    }
}
