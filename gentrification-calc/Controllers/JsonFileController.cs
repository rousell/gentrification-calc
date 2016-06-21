using System.IO;
using System.Web.Http;
using Newtonsoft.Json;
using System;
using System.Web;

namespace GentrificationCalc.Controllers.Api
{
    public class JsonFileController : ApiController
    {
        public object Get()
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data/zipData.topo.json");
            string allText = File.ReadAllText(path);

            object jsonObject = JsonConvert.DeserializeObject(allText);
            return jsonObject;
        }
    }
}
