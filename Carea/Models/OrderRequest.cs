using Carea.Extend;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carea.Models
{
    public class OrderRequest
    {
        [Key]
        public int Id { get; set; }
        public double OfferdPrice { get; set; }
        public int? Statues { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public Cars? Cars { get; set; }
    }
}
