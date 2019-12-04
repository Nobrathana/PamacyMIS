using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class RoleViewModels
    {
        [Required(ErrorMessage = "Required")]
        public string name { get; set; }
        public string description { get; set; }
        public string[] roles { get; set; }
    }
}