using System.ComponentModel.DataAnnotations;
namespace KP_2017_itog.Models
{
    public class Visitors
    {
        public int Visitor_ID { get; set; }
       
        public int Visitor_Category_ID { get; set; }

        public string Visitor_Description { get; set; }

        [Required(ErrorMessage = "Поле логина не может быть пустым.")]
        [Display(Name = "Логин")]
        public string Visitor_Name { get; set; }

        [Required(ErrorMessage = "Поле пароля не может быть пустым.")]
        [StringLength(100, ErrorMessage = "{0} должен быть не меньше {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле подтверждения пароля не может быть пустым.")]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

}