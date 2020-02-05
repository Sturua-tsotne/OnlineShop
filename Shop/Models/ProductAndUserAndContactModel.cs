using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class ProductAndUserAndContactModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required(ErrorMessage = "სათაურის ველი ცარიელია")]
        [DisplayName("სათაური")]
        public string ProductName { get; set; }
       
        [Required(ErrorMessage = "ფოტოს ველი ცარიელია")]
        [DisplayName("ფოტო")]
        public string ProductImg { get; set; }
        [Required(ErrorMessage = "ფასის ველი ცარიელია")]
        [DisplayName("ფასიო")]
        public int ProductPass { get; set; }
        public int AuthenticUserId { get; set; }
        
        public System.DateTime ProductCreationDate { get; set; }

    }
}