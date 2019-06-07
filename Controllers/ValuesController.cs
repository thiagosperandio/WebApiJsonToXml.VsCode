using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApiJsonToXml.VsCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<System.Xml.XmlElement>> Get()
        {
            HttpClient request = new HttpClient();
            var responseClient = await request.GetStringAsync("https://www.redesocialdecidades.org.br/cities");

            var jsonObj = JObject.Parse(responseClient);
            var node = JsonConvert.DeserializeXmlNode(jsonObj.ToString(), "Root");
            return Ok(node.DocumentElement);
        }
    }
}
