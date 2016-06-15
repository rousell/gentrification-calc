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

        public void CsvImport()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourcePath = "C:\\Users\\NSSStudent\\Documents\\GitHub\\gentrification-calc\\gentrification-calc\\DAL\\SeedData\\ACS_2011_Cleaned.csv";
            using (StreamReader reader = new StreamReader(resourcePath, Encoding.UTF8))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.WillThrowOnMissingField = false;
                while (csvReader.Read())
                {
                    int TotalPop = csvReader.GetField<int>(1);
                    context.PopulationYears.Add(new PopulationYear { TotalPopulation = TotalPop });
                    context.SaveChanges();
                   

                    //this.context.PopulationYears.Add(myData);

                    //context.PopulationYears.AddOrUpdate(p => p.Id, myData);
                    /*foreach(var item in myData)
                    {

                        context.PopulationYears.AddOrUpdate(pop => pop.Id,
                            new PopulationYear { TotalPopulation = item.TotalPopulation }
                        ); 
                    }*/


                    //context.PopulationYears.AddOrUpdate(p => p.Id, myData);
                }
            }
        }
    }
}