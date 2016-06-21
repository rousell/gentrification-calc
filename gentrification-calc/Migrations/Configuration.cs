namespace GentrificationCalc.Migrations
{
    using CsvHelper;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web;
    using System.Web.Hosting;

    internal sealed class Configuration : DbMigrationsConfiguration<GentrificationCalc.DAL.CalcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GentrificationCalc.DAL.CalcContext context)
        {

            context.ZipCodes.AddOrUpdate(
                zipcode => zipcode.ZipCodeDigit,
                new ZipCode { ZipCodeDigit = 37013 },
                new ZipCode { ZipCodeDigit = 37015 },
                new ZipCode { ZipCodeDigit = 37027 },
                new ZipCode { ZipCodeDigit = 37064 },
                new ZipCode { ZipCodeDigit = 37072 },
                new ZipCode { ZipCodeDigit = 37076 },
                new ZipCode { ZipCodeDigit = 37080 },
                new ZipCode { ZipCodeDigit = 37086 },
                new ZipCode { ZipCodeDigit = 37115 },
                new ZipCode { ZipCodeDigit = 37122 },
                new ZipCode { ZipCodeDigit = 37135 },
                new ZipCode { ZipCodeDigit = 37138 },
                new ZipCode { ZipCodeDigit = 37143 },
                new ZipCode { ZipCodeDigit = 37189 },
                new ZipCode { ZipCodeDigit = 37201 },
                new ZipCode { ZipCodeDigit = 37203 },
                new ZipCode { ZipCodeDigit = 37204 },
                new ZipCode { ZipCodeDigit = 37205 },
                new ZipCode { ZipCodeDigit = 37206 },
                new ZipCode { ZipCodeDigit = 37207 },
                new ZipCode { ZipCodeDigit = 37208 },
                new ZipCode { ZipCodeDigit = 37209 },
                new ZipCode { ZipCodeDigit = 37210 },
                new ZipCode { ZipCodeDigit = 37211 },
                new ZipCode { ZipCodeDigit = 37212 },
                new ZipCode { ZipCodeDigit = 37213 },
                new ZipCode { ZipCodeDigit = 37214 },
                new ZipCode { ZipCodeDigit = 37215 },
                new ZipCode { ZipCodeDigit = 37216 },
                new ZipCode { ZipCodeDigit = 37217 },
                new ZipCode { ZipCodeDigit = 37218 },
                new ZipCode { ZipCodeDigit = 37219 },
                new ZipCode { ZipCodeDigit = 37220 },
                new ZipCode { ZipCodeDigit = 37221 },
                new ZipCode { ZipCodeDigit = 37228 },
                new ZipCode { ZipCodeDigit = 37240 },
                new ZipCode { ZipCodeDigit = 37243 },
                new ZipCode { ZipCodeDigit = 37246 }
            );

            context.Demographics.AddOrUpdate(
                demographic => demographic.Race,
                new Demographic { Race = "TotalPopulation" },
                new Demographic { Race = "White" },
                new Demographic { Race = "BlackorAfricanAmerican" },
                new Demographic { Race = "AmericanIndianandAlaskaNative" },
                new Demographic { Race = "Asian" },
                new Demographic { Race = "NativeHawaiianandOtherPacificIslander" },
                new Demographic { Race = "Other" },
                new Demographic { Race = "TwoorMoreRaces" }
            );

            /*if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();*/

            var resourcePath = HttpContext.Current.Server.MapPath("~/DAL/SeedData/ACS2011_Cleaned.csv");
            using (StreamReader reader = new StreamReader(resourcePath, Encoding.UTF8))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.WillThrowOnMissingField = false;
                var populations = csvReader.GetRecords<PopulationYear>().ToArray();
                context.PopulationYears.AddOrUpdate(p => p.ZipCodeDigit, populations);
            }

            var resourcePath2 = HttpContext.Current.Server.MapPath("~/DAL/SeedData/ACS2012_Cleaned.csv");
            using (StreamReader reader = new StreamReader(resourcePath2, Encoding.UTF8))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.WillThrowOnMissingField = false;
                var populations = csvReader.GetRecords<PopulationYear>().ToArray();
                context.PopulationYears.AddOrUpdate(p => p.ZipCodeDigit, populations);
            }

            var resourcePath3 = HttpContext.Current.Server.MapPath("~/DAL/SeedData/ACS2013_Cleaned.csv");
            using (StreamReader reader = new StreamReader(resourcePath3, Encoding.UTF8))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.WillThrowOnMissingField = false;
                var populations = csvReader.GetRecords<PopulationYear>().ToArray();
                context.PopulationYears.AddOrUpdate(p => p.ZipCodeDigit, populations);
            }

            var resourcePath4 = HttpContext.Current.Server.MapPath("~/DAL/SeedData/ACS2014_Cleaned.csv");
            using (StreamReader reader = new StreamReader(resourcePath4, Encoding.UTF8))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.WillThrowOnMissingField = false;
                var populations = csvReader.GetRecords<PopulationYear>().ToArray();
                context.PopulationYears.AddOrUpdate(p => p.ZipCodeDigit, populations);
            }

        }
    }
}
