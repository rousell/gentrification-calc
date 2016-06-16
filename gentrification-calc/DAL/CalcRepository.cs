﻿using CsvHelper;
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
            IEnumerable<PopulationYear> populations;
            string resourcePath = "C:\\Users\\NSSStudent\\Documents\\GitHub\\gentrification-calc\\gentrification-calc\\DAL\\SeedData\\ACS2011_Cleaned.csv";
            using (StreamReader reader = new StreamReader(resourcePath, Encoding.UTF8))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.WillThrowOnMissingField = false;
                populations = csvReader.GetRecords<PopulationYear>();

                context.PopulationYears.AddRange(populations);

                context.SaveChanges();
            }

        }
    }
}