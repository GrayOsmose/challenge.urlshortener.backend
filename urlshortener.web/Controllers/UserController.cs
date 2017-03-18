using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace urlshortener.web.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        [HttpGet]
        public Guid Get()
        {
            return Guid.NewGuid();
        }
    }
}
