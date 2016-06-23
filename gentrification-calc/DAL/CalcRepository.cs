using CsvHelper;
using GentrificationCalc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace GentrificationCalc.DAL
{
    public class CalcRepository
    {
        public CalcContext context { get; set; }

        public CalcRepository()
        {
            context = new CalcContext();
        }

        public CalcRepository(CalcContext _context)
        {
            context = _context;
        }

        internal List<ZipCode> GetZip()
        {
            List<ZipCode> List = context.ZipCodes.ToList();
            return List;
        }

        internal List<PopulationYear> GetPopYear()
        {
            return context.PopulationYears.ToList<PopulationYear>();
        }

        public IEnumerable<PopulationYear> GetPopYearByZip(int ZipDigit)
        {
            IEnumerable<PopulationYear> popyears = context.PopulationYears.ToList<PopulationYear>();
            IEnumerable<PopulationYear> query = popyears.Where(popyear => popyear.ZipCodeDigit == ZipDigit);
            return query;
        }

        public int GetDemographicDataCount()
        {
            return context.Demographics.Count();
        }

    }
}