using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class UserViewModels
    {
        public string ID { get; set; }

        public string User_Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "IncorrectInput")]
        public string First_Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "IncorrectInput")]
        public string Last_Name { get; set; }

        public string Gender { get; set; }
        public DateTime? DOB { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        [RegularExpression("([0-9]+)", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "IncorrectInput")]
        public string Phone_Number { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string User_Name { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public int User_Role { get; set; }

        public bool Status { get; set; } = true;

 
    }
}