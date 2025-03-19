using System.ComponentModel.DataAnnotations;

namespace Backend_Mobile.Entities
{
    public class Product : BasicEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        
        public decimal Price { get; set; }

        
        public int Stock { get; set; }


        //public string ImageURl  { get; set; }
    }
}