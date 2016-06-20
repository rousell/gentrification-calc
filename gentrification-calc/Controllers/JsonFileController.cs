using System.IO;
using System.Web.Http;
using Newtonsoft.Json;

namespace GentrificationCalc.Controllers.Api
{
    public class JsonFileController : ApiController
    {
        public object Get()
        {
            string allText = File.ReadAllText(@"C:\Users\NSSStudent\Documents\GitHub\gentrification-calc\gentrification-calc\App_Data\zipData.topo.json");

            object jsonObject = JsonConvert.DeserializeObject(allText);
            return jsonObject;
        }
    }
}
