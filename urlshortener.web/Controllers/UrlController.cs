using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using urlshortener.domain.model;
using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;
using urlshortener.web.Data;

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

        private Guid UserData
        {
            get { return Storage.GetUserData(HttpContext.Session); }
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var urls = await _urlManager.GetUrlModels(UserData);

            return Ok(urls);
        }

        [HttpPost("{userGuid}")]
        public async Task<ActionResult> Post([FromBody]UrlModel url)
        {
            if (!ModelState.IsValid) return BadRequest($"{nameof(url)} is invalid");

            url.UserGuid = UserData;
            // ToDo : [feature] generate key for url
            url.Key = string.Empty;

            await _urlManager.AddUrl(url);
            
            return Ok(url);
        }
        
        [HttpDelete("{userGuid}")]
        public async Task<ActionResult> Delete([FromBody]string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return NoContent();

            await _urlManager.DeleteUrl(UserData, key);

            return Ok(key);
        }
    }
}
