using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_KP_SQL_2017.Models
{
    public class Visitors
    {
        public int Visitor_ID { get; set; }

        //[Required(ErrorMessage = "Visitor Categiry is required")]
        public VisitorsCategory Visitor_Category_ID { get; set; }

       // [Required(ErrorMessage = "Visitor Name is required")]
        public string Visitor_Name { get; set; }


        public string Visitor_Description { get; set; }

       // [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}