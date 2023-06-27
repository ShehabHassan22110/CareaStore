using Carea.Extend;
using Carea.Models;
using System.ComponentModel.DataAnnotations;

namespace Carea.ViewModels {
	public class CreateOrderVM
    {
        public int Id { get; set; }
        public int RequestOrderId { get; set; }

        [Required]
		public int CarsId { get; set; }

		public virtual Cars? Cars { set; get; }

		[Required]
		public int ShippingId { get; set; }
		public Shipping? Shipping { get; set; }
        public string ApplicationUserId { get; set; }
		public virtual ApplicationUser? ApplicationUser { set; get; }
		public double TAX { get; set; }
		public double Amount { get; set; }
		public string Address { get; set; }
		public int? Status { get; set; }
		public int Payment { get; set; }



	}
}
