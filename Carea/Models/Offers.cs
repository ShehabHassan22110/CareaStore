using System.ComponentModel.DataAnnotations.Schema;

namespace Carea.Models 
{
	public class Offers
	{
        public int Id { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
		public int CarId { get; set; }		
		[ForeignKey("CarId")]
		public Cars? Cars { get; set; }
	}
}
