using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KP_2017_itog.Models
{
    public class VisitorsComments
    {
        [Required]
        public int Visitor_Comment_ID { get; set; }

        [Required]
        public int Restaurant_ID { get; set; }

        [Required]
        public int Visitor_ID { get; set; }

        public DateTime Comment_Date{ get; set; }

        [Required(ErrorMessage = "Комментарий не указан")]
        public string Comment_Text { get; set; }
    }
}