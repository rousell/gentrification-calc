namespace gentrification_calc.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<gentrification_calc.DAL.CalcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(gentrification_calc.DAL.CalcContext context)
        {

            context.ZipCodes.AddOrUpdate(
                zipcode => zipcode.ZipCodeDigit,
                new ZipCode { ZipCodeDigit = 37013, ZipCodeId = 1 },
                new ZipCode { ZipCodeDigit = 37015, ZipCodeId = 2 },
                new ZipCode { ZipCodeDigit = 37027, ZipCodeId = 3 },
                new ZipCode { ZipCodeDigit = 37064, ZipCodeId = 4 },
                new ZipCode { ZipCodeDigit = 37072, ZipCodeId = 5 },
                new ZipCode { ZipCodeDigit = 37076, ZipCodeId = 6 },
                new ZipCode { ZipCodeDigit = 37080, ZipCodeId = 7 },
                new ZipCode { ZipCodeDigit = 37086, ZipCodeId = 8 },
                new ZipCode { ZipCodeDigit = 37115, ZipCodeId = 9 },
                new ZipCode { ZipCodeDigit = 37122, ZipCodeId = 10 },
                new ZipCode { ZipCodeDigit = 37135, ZipCodeId = 11 },
                new ZipCode { ZipCodeDigit = 37138, ZipCodeId = 12 },
                new ZipCode { ZipCodeDigit = 37143, ZipCodeId = 13 },
                new ZipCode { ZipCodeDigit = 37189, ZipCodeId = 14 },
                new ZipCode { ZipCodeDigit = 37201, ZipCodeId = 15 },
                new ZipCode { ZipCodeDigit = 37203, ZipCodeId = 16 },
                new ZipCode { ZipCodeDigit = 37204, ZipCodeId = 17 },
                new ZipCode { ZipCodeDigit = 37205, ZipCodeId = 18 },
                new ZipCode { ZipCodeDigit = 37206, ZipCodeId = 19 },
                new ZipCode { ZipCodeDigit = 37207, ZipCodeId = 20 },
                new ZipCode { ZipCodeDigit = 37208, ZipCodeId = 21 },
                new ZipCode { ZipCodeDigit = 37209, ZipCodeId = 22 },
                new ZipCode { ZipCodeDigit = 37210, ZipCodeId = 23 },
                new ZipCode { ZipCodeDigit = 37211, ZipCodeId = 24 },
                new ZipCode { ZipCodeDigit = 37212, ZipCodeId = 25 },
                new ZipCode { ZipCodeDigit = 37213, ZipCodeId = 26 },
                new ZipCode { ZipCodeDigit = 37214, ZipCodeId = 27 },
                new ZipCode { ZipCodeDigit = 37215, ZipCodeId = 28 },
                new ZipCode { ZipCodeDigit = 37216, ZipCodeId = 29 },
                new ZipCode { ZipCodeDigit = 37217, ZipCodeId = 30 },
                new ZipCode { ZipCodeDigit = 37218, ZipCodeId = 31 },
                new ZipCode { ZipCodeDigit = 37219, ZipCodeId = 32 },
                new ZipCode { ZipCodeDigit = 37220, ZipCodeId = 33 },
                new ZipCode { ZipCodeDigit = 37221, ZipCodeId = 34 },
                new ZipCode { ZipCodeDigit = 37228, ZipCodeId = 35 },
                new ZipCode { ZipCodeDigit = 37240, ZipCodeId = 36 },
                new ZipCode { ZipCodeDigit = 37243, ZipCodeId = 37 },
                new ZipCode { ZipCodeDigit = 37246, ZipCodeId = 38 }
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
