using Carea.API.Models;
using Carea.ViewModels;

namespace Carea.Api_s.Models
{
	public class CarsCustomResponse : CustomResponse
    {
        public IEnumerable<CarsVM> Records { get; set; }

        public CarsVM Record { get; set; }
    }
}
