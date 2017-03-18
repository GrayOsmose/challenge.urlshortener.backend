using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using urlshortener.domain.model;

namespace urlshortener.web.Controllers
{
    [Produces("application/json")]
    [Route("api/r")]
    public class RerouteController : Controller
    {
        private readonly IUrlManager _urlManager;

        public RerouteController(IUrlManager urlManager) : base()
        {
            _urlManager = urlManager;
        }

        [HttpGet("{key}")]
        public async Task<RedirectResult> Get(string key)
        {
            var urlModel = await _urlManager.GetUrlModel(key);

            if (urlModel == null) throw new HttpRequestException($"Couldn't find {nameof(key)}");

            // ToDo : [feature] check if we can run separately
            await _urlManager.AddCounter(key);
            
            return new RedirectResult(url: urlModel.Url, permanent: true);
        }
    }
}