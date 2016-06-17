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

        public int GetDemographicDataCount()
        {
            return context.Demographics.Count();
        }

    }
}