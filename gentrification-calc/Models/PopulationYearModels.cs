using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gentrification_calc.Models
{
    public class PopulationYear
    {
        public int PopYear { get; set;}
        public int DemographicId { get; set; }
        public Demographic Race { get; set; }
        public int PopulationByRace { get; set; }
        public ZipCode Zip { get; set; }
        public int PopulationId { get; set; }
    }
}