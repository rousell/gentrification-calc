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
        public int WhitePopulation { get; set;}
        public int BlackorAfricanAmericanPopulation { get; set; }
        public int AmericanIndianandAlaskaNativePopulation { get; set; }
        public int AsianPopulation { get; set; }
        public int NativeHawaiianandOtherPacificIslanderPopulation { get; set; }
        public int OtherPopulation { get; set; }
        public int TwoorMoreRacesPopulation { get; set; }

        public ZipCode Zip { get; set; }
        public int Id { get; set; }
    }
}