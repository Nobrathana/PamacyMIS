using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class ProductViewModels
    {
        public string id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string productCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string description { get; set; }
        public string brandID { get; set; }
        public string categoryID { get; set; }
        public bool status { get; set; } = true;

        
    }
}