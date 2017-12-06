using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_KP_SQL_2017.Models
{
    public class VisitorsCategory
    {
        public int Visitor_Category_ID { get; set; }

        [Required(ErrorMessage = "Visitor Categiry description is required")]
        public string Visitor_Category_Description { get; set; }
    }
}