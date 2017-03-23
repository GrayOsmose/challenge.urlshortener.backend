using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using urlshortener.domain.model;
using System.Net;

namespace urlshortener.web.Controllers
{
    [Produces("application/json")]
    // ToDo: [refactoring] make path cuter later
    [Route("api/r")]
    public class RerouteController : Controller
    {
        private readonly IUrlManager _urlManager;
        // use it to parse key
        // private readonly IKeyManager _keyManager;

        public RerouteController(IUrlManager urlManager/*, IKeyManager keyManager*/) : base()
        {
            _urlManager = urlManager;
        }

        [HttpGet("{key}")]
        public async Task<ActionResult> Get([FromRoute]string key)
        {
            // parse key to generate url with userGuid
            var urlModel = await _urlManager.GetUrlModel(key);
            if (urlModel == null) return BadRequest($"{nameof(key)} is invalid");

            // ToDo : [feature] check if we can run separately
            await _urlManager.AddCounter(key);

            return RedirectPermanent(urlModel.Url);
        }
    }
}
