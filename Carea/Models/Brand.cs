namespace Carea.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string LogoUrl { get; set; }
        public string Phone { get; set; }
        public ICollection<Cars> Cars { get; set; }
    }
}
