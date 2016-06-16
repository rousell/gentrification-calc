using CsvHelper;
using GentrificationCalc.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using GentrificationCalc.DAL;

namespace gentrification_calc.DAL
{
    public class CsvSeedService
    {
        public CalcContext context { get; set; }

        public CsvSeedService()
        {
            context = new CalcContext();
        }

        public IEnumerable<PopulationYear> CsvImport()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<PopulationYear> populations;
            string resourcePath = "C:\\Users\\NSSStudent\\Documents\\GitHub\\gentrification-calc\\gentrification-calc\\DAL\\SeedData\\ACS2011_Cleaned.csv";
            using (StreamReader reader = new StreamReader(resourcePath, Encoding.UTF8))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.WillThrowOnMissingField = false;
                populations = csvReader.GetRecords<PopulationYear>();

                context.PopulationYears.AddRange(populations);

                context.SaveChanges();

                return populations;
            }
            
        }
    }
}