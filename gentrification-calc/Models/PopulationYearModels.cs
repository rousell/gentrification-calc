using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GentrificationCalc.Models
{
    public class PopulationYear
    {
        public int PopYear { get; set;}
        public Demographic Race { get; set; }

        public int TotalPopulation { get; set; }


        public ZipCode Zip { get; set; }
        public int Id { get; set; }
    }
}