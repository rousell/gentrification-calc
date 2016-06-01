using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gentrification_calc.Models
{
    public class Demographics
    {
        public int ZipCode { get; set; }
        public int DemographicsId { get; set; }
        public int DemographicsYear { get; set; }
        public int Population { get; set; }
        public string Race { get; set; }
    }
}