using GentrificationCalc.DAL;
using GentrificationCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GentrificationCalc.Controllers
{
    public class PopulationYearController : ApiController
    {
        CalcRepository Repo = new CalcRepository();

        //Get api/PopulationYear
        public IEnumerable<PopulationYear> Get()
        {
            List<PopulationYear> populationyears = Repo.GetPopYear();
            return populationyears;
        }

        //Get api/PopulationYear/Zip
        [Route("api/PopulationYear/{Zip}")]
        public IEnumerable<PopulationYear> GetPopYearByZip(int Zip)
        {
            IEnumerable<PopulationYear> popzip = Repo.GetPopYearByZip(Zip);
            return popzip;
        }
    }
}
