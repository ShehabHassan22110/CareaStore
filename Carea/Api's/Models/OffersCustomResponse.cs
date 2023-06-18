using Carea.API.Models;
using Carea.ViewModels;

namespace Carea.Api_s.Models
{
    public class OffersCustomResponse : CustomResponse
    {
        public IEnumerable<OffersApiModel> Records { get; set; }

        public OffersApiModel Record { get; set; }
    }
}
