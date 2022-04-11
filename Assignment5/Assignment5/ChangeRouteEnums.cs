using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// TODO REMOVE


namespace Assignment5
{
    public enum ChangeRouteEnums
    {
        [Display(Name = "30 degrees")]
        Degrees30,
        [Display(Name = "45 degrees")]
        Degrees45,
        [Display(Name = "60 degrees")]
        Degrees60,
        [Display(Name = "90 degrees")]
        Degrees90,
        [Display(Name = "180 degrees")]
        Degrees180,
    }
}
