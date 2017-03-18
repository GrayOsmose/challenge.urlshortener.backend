using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using urlshortener.domain.model;
using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;

namespace urlshortener.web.Controllers
{
    [Produces("application/json")]
    [Route("api/url")]
    public class UrlController : Controller
    {
        private readonly IUrlManager _urlManager;

        public UrlController(IUrlManager urlManager) : base()
        {
            _urlManager = urlManager;
        }
        
        [HttpGet("{userGuid}")]
        public async Task<List<UrlModel>> Get([FromBody]Guid userGuid)
        {
            var urls = await _urlManager.GetUrlModels(userGuid);

            return urls;
        }

        [HttpPost("{userGuid}")]
        public async Task Post([FromRoute]Guid userGuid, [FromBody]UrlModel url)
        {
            await _urlManager.AddUrl(url);
        }
        
        [HttpDelete("{userGuid}")]
        public async Task Delete([FromRoute]Guid userGuid, [FromBody]string key)
        {
            // await _urlManager.DeleteUrl(key);
        }
    }
}