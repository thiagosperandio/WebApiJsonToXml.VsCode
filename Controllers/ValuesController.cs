using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApiJsonToXml.VsCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            HttpClient request = new HttpClient();
            var responseClient = await request.GetStringAsync("https://www.redesocialdecidades.org.br/cities");
            XNode node = Newtonsoft.Json.JsonConvert.DeserializeXNode(responseClient, "Root");
            return Ok(node.ToString());
        }
    }
}
