using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bfaubion_webapp.Controllers
{
    [Route("api")]
    public class CardController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            Card drawcard = new Card();
            return Ok(drawcard);
        }
    }
}