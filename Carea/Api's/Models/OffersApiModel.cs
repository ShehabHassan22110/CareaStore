using Carea.Models;

namespace Carea.Api_s.Models
{
    public class OffersApiModel
    {
        public Cars? CarData { get; set; }
        public int offerId { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int Discount { get; set; }
       

    }
}
