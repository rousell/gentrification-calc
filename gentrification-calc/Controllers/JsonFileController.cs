using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GentrificationCalc.DAL;
using System.Text;
using Newtonsoft.Json;

namespace GentrificationCalc.Controllers.Api
{
    public class JsonFileController : ApiController
    {
        /*public HttpResponseMessage Get()
        {
            var json = File.ReadAllText(Microsoft.SqlServer.Server.MapPath(@"~/App_Data/zipData.json");

            return new HttpResponseMessage()
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }*/

        public object Get()
        {
            string allText = System.IO.File.ReadAllText(@"C:\Users\NSSStudent\Documents\GitHub\gentrification-calc\gentrification-calc\App_Data\zipData.json");

            object jsonObject = JsonConvert.DeserializeObject(allText);
            return jsonObject;
        }


    }
}
