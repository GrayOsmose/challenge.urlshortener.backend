using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace urlshortener.web.Controllers
{
    [Produces("application/json")]
    [Route("api/url")]
    public class UrlController : Controller
    {
        public UrlController() : base()
        {

        }

        // GET api/url/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/url
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/url/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/url/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}