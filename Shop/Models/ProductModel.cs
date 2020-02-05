using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class ProductModel
    {
        public int Productid { get; set; }
        public int AuthenticUserId { get; set; }

        [Required(ErrorMessage = " ველი ცარიელია")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "ველი ცარიელია")]
        public string ProductImg { get; set; }
        [Required(ErrorMessage = "ველი ცარიელია")]
        public int ProductPass { get; set; }
        [Required(ErrorMessage = " ველი ცარიელია")]
        public string Category { get; set; }
    }
}