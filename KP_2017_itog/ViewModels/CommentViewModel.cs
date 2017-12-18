using KP_2017_itog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP_2017_itog.ViewModels
{
    public class CommentViewModel
    {
        public int Visitor_Comment_ID { get; set; }

        public int Restaurant_ID { get; set; }

        public int Visitor_ID { get; set; }

        public string Comment_Text { get; set; }

        public Restaurants restarant { get; set; }
    }
}