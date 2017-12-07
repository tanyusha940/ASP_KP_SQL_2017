using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KP_2017_itog.Models
{
    public class Visitors
    {
        public int Visitor_ID { get; set; }
       
        [Required(ErrorMessage = "Категория посетителя не установлена")]
        public int Visitor_Category_ID { get; set; }

       [Required(ErrorMessage = "Укажите имя")]
        public string Visitor_Name { get; set; }


        public string Visitor_Description { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
 
    }
}