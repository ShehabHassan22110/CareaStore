using Carea.API.Models;
using Carea.ViewModels;

namespace Carea.Api_s.Models
{
    public class CarRateCustomResponse: CustomResponse

    {
        public IEnumerable<Car_RateVM> Records { get; set; }

        public Car_RateVM Record { get; set; }
    }
}
