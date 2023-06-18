using Carea.Extend;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carea.Models
{
    public class Car_Rate
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? ApplicationUser { get; set; }
        public double Rate { get; set; }
      

        public string Comment { get; set; }
        public int CarId { get; set; }
        public DateTime RateTime { get; set; } = DateTime.Now;

        [ForeignKey("CarId")]
        public Cars? Cars { get; set; }

    }
}
