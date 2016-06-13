using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gentrification_calc.Models
{
    public class Demographic
    {
        public ZipCode Zip { get; set; }
        public int DemographicId { get; set; }
        public string Race { get; set; }
    }
}