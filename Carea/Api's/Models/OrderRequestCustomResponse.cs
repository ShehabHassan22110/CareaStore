using Carea.API.Models;
using Carea.ViewModels;

namespace Carea.Api_s.Models
{
    public class OrderRequestCustomResponse : CustomResponse
    {
        
        public IEnumerable<OrderRequestVM> Records { get; set; }

        public OrderRequestVM Record { get; set; }
    }
}
