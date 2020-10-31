using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class LoginVM
    {
        [Required]
        [StringLength(16)]
        public string Username { get; set; }
        [Required]
        [MinLength(3), MaxLength(16)]
        public string Password { get; set; }
    }
}