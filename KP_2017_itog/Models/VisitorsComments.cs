﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KP_2017_itog.Models
{
    public class VisitorsComments
    {
        public int Visitor_Comment_ID { get; set; }
        public Restaurants Restaurant_ID { get; set; }
        public Visitors Visitor_ID { get; set; }
        public DateTime Comment_Date{ get; set; }
        [Required(ErrorMessage = "Comment is required")]
        public string Comment_Text { get; set; }
    }
}