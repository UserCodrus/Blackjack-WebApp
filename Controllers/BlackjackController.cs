using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bfaubion_webapp.Controllers
{
    public class BlackjackController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Image"] = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Playing_card_diamond_A.svg/192px-Playing_card_diamond_A.svg.png";
            return View();
        }
    }
}
