using GentrificationCalc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GentrificationCalc.DAL
{
    public class CalcContext : ApplicationDbContext
    {
        public virtual DbSet<ZipCode> ZipCodes { get; set; }
        public virtual DbSet<Demographic> Demographics { get; set; }
        public virtual DbSet<PopulationYear> PopulationYears { get; set; }
    }
}