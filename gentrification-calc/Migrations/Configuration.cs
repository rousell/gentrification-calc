namespace gentrification_calc.Migrations
{
    using CsvHelper;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    internal sealed class Configuration : DbMigrationsConfiguration<gentrification_calc.DAL.CalcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(gentrification_calc.DAL.CalcContext context)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "gentrification-calc.DAL.SeedData.ACS_2011_Cleaned.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);

                    IEnumerable<PopulationYear> myData = csvReader.GetRecords<PopulationYear>();

                    csvReader.Configuration.WillThrowOnMissingField = false;
                    var acs = csvReader.GetRecords<PopulationYear>().ToArray();
                    context.PopulationYears.AddOrUpdate(z => z.Zip, acs);

                    while (csvReader.Read() ){
                        int[] zipFromCsv = csvReader.GetField<int[]>(0);
                        for (int i = 0; i < zipFromCsv.Length; i++)
                        {
                            int zipField = zipFromCsv[i];
                            var totalField = csvReader.GetField<string>(1);
                            var whitePopField = csvReader.GetField<string>(2);

                        }

                    }

                }
            }

            /*
            resourceName = "SeedingDataFromCSV.Domain.SeedData.provincestates.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    while (csvReader.Read())
                    {
                        var provinceState = csvReader.GetRecord<ProvinceState>();
                        var countryCode = csvReader.GetField<string>("CountryCode");
                        provinceState.Country = context.Countries.Local.Single(c => c.Code == countryCode);
                        context.ProvinceStates.AddOrUpdate(p => p.Code, provinceState);
                    }
                }
            }
            */

            context.Demographics.AddOrUpdate(
                demographic => demographic.Race,
                new Demographic { Race = "TotalPopulation" },
                new Demographic { Race = "White"},
                new Demographic { Race = "BlackorAfricanAmerican"},
                new Demographic { Race = "AmericanIndianandAlaskaNative"},
                new Demographic { Race = "Asian"},
                new Demographic { Race = "NativeHawaiianandOtherPacificIslander"},
                new Demographic { Race = "Other"},
                new Demographic { Race = "TwoorMoreRaces"}
            );

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

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
