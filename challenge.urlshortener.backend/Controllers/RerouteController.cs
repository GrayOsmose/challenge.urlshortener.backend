using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace urlshortener.web.Controllers
{
    [Produces("application/json")]
    [Route("")]
    public class RerouteController : Controller
    {
        public RerouteController() : base()
        {

        }

        [HttpGet("{route}")]
        public RedirectResult Get(string route)
        {
            return new RedirectResult(url: "https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/actions", permanent: true);
        }
    }
}