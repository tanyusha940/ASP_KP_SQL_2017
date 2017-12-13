using System;

namespace KP_2017_itog.Models
{
    public class VisitorsComments
    {
        public int Visitor_Comment_ID { get; set; }

        public int Restaurant_ID { get; set; }

        public int Visitor_ID { get; set; }

        public DateTime Comment_Date{ get; set; }

        public string Comment_Text { get; set; }
    }
}