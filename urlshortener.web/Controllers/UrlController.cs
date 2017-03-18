using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using urlshortener.domain.model;
using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;

namespace urlshortener.web.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UrlController : Controller
    {
        private readonly IUrlManager _urlManager;

        public UrlController(IUrlManager urlManager) : base()
        {
            _urlManager = urlManager;
        }
        
        [HttpGet("{userGuid}")]
        public async Task<List<UrlModel>> Get([FromRoute]Guid userGuid)
        {
            var urls = await _urlManager.GetUrlModels(userGuid);

            return urls;
        }

        [HttpPost("{userGuid}")]
        public async Task<UrlModel> Post([FromRoute]Guid userGuid, [FromBody]UrlModel url)
        {
            if (!ModelState.IsValid) throw new HttpRequestException($"{nameof(url)} is invalid");

            // ToDo : [feature] generate key for url
            url.Key = string.Empty;

            await _urlManager.AddUrl(url);
            
            return url;
        }
        
        [HttpDelete("{userGuid}")]
        public async Task Delete([FromRoute]Guid userGuid, [FromBody]string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new HttpRequestException($"{nameof(key)} is invalid");

            await _urlManager.DeleteUrl(key);
        }
    }
}
