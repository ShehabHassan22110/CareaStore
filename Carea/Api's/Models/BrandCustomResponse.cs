using Carea.API.Models;
using Carea.ViewModels;

namespace Carea.Api_s.Models
{
    public class BrandCustomResponse:CustomResponse
    {
        public IEnumerable<BrandVM> Records { get; set; }

        public BrandVM Record { get; set; }
    }
}
