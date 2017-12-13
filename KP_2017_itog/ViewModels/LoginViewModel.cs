using System.ComponentModel.DataAnnotations;

namespace KP_2017_itog.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле логина не может быть пустым.")]
        [Display(Name = "Логин")]
        public string Visitor_Name { get; set; }

        [Required(ErrorMessage = "Поле пароля не может быть пустым.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}