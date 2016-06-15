using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}