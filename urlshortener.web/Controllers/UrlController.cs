using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using urlshortener.domain.model;

using IKeyManager = urlshortener.web.Data.IKeyManager;

namespace urlshortener.web.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UrlController : Controller
    {
        private readonly IUrlManager _urlManager;
        private readonly IKeyManager _keyManager;

        public UrlController(IUrlManager urlManager, IKeyManager keyManager) : base()
        {
            _urlManager = urlManager;
            _keyManager = keyManager;
        }

        private Guid UserData
        {
            // get my user
            get { return (Guid)HttpContext.Items["User"]; }
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var urls = await _urlManager.GetUrlModels(UserData);

            return Ok(urls);
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody]UrlModel url)
        {
            if (!ModelState.IsValid) return BadRequest($"{nameof(url)} is invalid");

            url.UserGuid = UserData;
            url.Key = _keyManager.GenerateKey(url.UserGuid, url.Url);

            await _urlManager.AddUrl(url);
            
            return Ok(url);
        }
        
        [HttpDelete()]
        public async Task<ActionResult> Delete([FromBody]string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return NoContent();

            await _urlManager.DeleteUrl(UserData, key);

            return Ok(key);
        }
    }
}
