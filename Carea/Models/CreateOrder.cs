using Carea.Extend;
namespace Carea.Models {
	public class CreateOrder
		{
			public CreateOrder()
			{
				SevedDate = DateTime.Now;
			}
			public int Id { get; set; }
			public int CarsId { get; set; }
			public virtual Cars? Cars { set; get; }
			public int ShippingId { get; set; }
			public virtual Shipping? Shipping { set; get; }
			public string ApplicationUserId { get; set; }
			public int? Status { get; set; } 
			public virtual ApplicationUser? ApplicationUser { set; get; }
			public DateTime SevedDate { get; set; }
			public double TAX { get; set; }
			public string Address { get; set; }
			public double Amount { get; set; }
			public int Payment { get; set; }
	}
}
