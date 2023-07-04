using Carea.Entities;
using Carea.Extend;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Carea.Models
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Car_Photo_Color> Car_Photo_Color { get; set; }
        public DbSet<Car_Rate> Car_Rate { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
		public virtual DbSet<CreateOrder> CreateOrder { set; get; }
		public virtual DbSet<OrderRequest> OrderRequest { set; get; }
		public virtual DbSet<Complaints_Suggestions> Complaints_Suggestions { set; get; }
		public virtual DbSet<Terms_Conditions> Terms_Conditions { set; get; }
		public virtual DbSet<PrivacyPolicy> PrivacyPolicy { set; get; }
	}
}
