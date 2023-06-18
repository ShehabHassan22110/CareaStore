using System.ComponentModel.DataAnnotations.Schema;

namespace Carea.Models
{
    public class Car_Photo_Color
    {
        public int Id { get; set; }
        public string imgUrl { get; set; }
        public string Color_Code { get; set; }



        //Cars Relation
        public int Car_Id { get; set; }
        [ForeignKey("Car_Id")]
        public Cars Cars { get; set; }
    }
}
