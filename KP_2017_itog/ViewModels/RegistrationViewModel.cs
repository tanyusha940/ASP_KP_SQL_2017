using KP_2017_itog.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KP_2017_itog.ViewModels
{
    public class RegistrationViewModel
    {
        public List<VisitorsCategory> Categories { get; set; }

        public Visitors Visitor { get; set; }
    }
}