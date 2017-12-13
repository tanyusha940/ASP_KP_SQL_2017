using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KP_2017_itog.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        public string Visitor_Name { get; set; }



        [Required(ErrorMessage = "Укажите пароль")]
        [StringLength(50, ErrorMessage = "Длинная пароля должна быть от 6 до 50 символов", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }
}