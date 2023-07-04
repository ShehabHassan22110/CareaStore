using System.ComponentModel.DataAnnotations.Schema;
namespace Carea.Models
{
    public class Cars
    {      
        public int Id { get; set; }
        public string Car_Name { get; set; }
        public string Car_Model { get; set; }
        public string Car_Desc { get; set; }
        public double Car_Price { get; set; }
        public bool Is_Used { get; set; }
        public bool Leather_Interior { get; set; }
        public bool Turbo { get; set; }
        public double Engine_volume { get; set; }
        public double Cylinders { get; set; }
        public double Levy { get; set; }
        public string Wheel { get; set; }
        public string Drive_Wheels { get; set; }
        public string Gear_Box_Type { get; set; }
        public string Doors { get; set; }
        public string Car_FuelType { get; set; }
        public string Category { get; set; }
        public int Airbags { get; set; }
        public Double? Rate { get; set; }

        //Brand Relation
        public int Brand_Id { get; set; }
        [ForeignKey("Brand_Id")]
        public Brand Brand { get; set; }
        //Car_Photo_Color
        public ICollection<Car_Photo_Color> Car_Photo_Color { get; set; }
        public ICollection<Car_Rate>? Car_Rate { get; set; }
        public ICollection<Offers>? Offers { get; set; }

        //rate
    }
}
