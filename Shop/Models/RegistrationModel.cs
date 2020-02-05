using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "სახელის ველი ცარიელია")]

        public string Name { get; set; }

        [Required(ErrorMessage = "გვარის ველი ცარიელია")]

        public string Surname { get; set; }

        [Required(ErrorMessage = "ელ ფოსტის ველი ცარიელია")]

        public string Email { get; set; }


        [Required(ErrorMessage = "პაროლის  ველი ცარიელია")]
        [StringLength(25, ErrorMessage = "პაროლში არსებული სიმბოლოები რაოდენობა მეტი უნდა იტოს 6 -ზე და ნაკლები 25 -ზე", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = " გთხოვთ გაიმეოროთ პაროლი")]

        [StringLength(25, ErrorMessage = "პაროლში არსებული სიმბოლოები რაოდენობა მეტი უნდა იტოს 6 -ზე და ნაკლები 25 -ზე", MinimumLength = 6)]

        [Compare("Password", ErrorMessage = "პაროლები არ ემთხვევა")]
        public string RepeatPassword { get; set; }
    }
}