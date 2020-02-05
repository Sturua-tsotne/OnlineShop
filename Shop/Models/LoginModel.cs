using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "ელ ფოსტის ველი ცარიელია")]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "პაროლის ველი ცარიელია")]
     
        public string Password { get; set; }
    }
}