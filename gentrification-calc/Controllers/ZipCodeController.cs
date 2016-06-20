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
    public class ZipCodeController : ApiController
    {
        CalcRepository Repo = new CalcRepository();

        // GET api/ZipCode
        public IEnumerable<ZipCode> Get()
        {
            List<ZipCode> zipcode = Repo.GetZip();
            return zipcode;
        }
    }
}
