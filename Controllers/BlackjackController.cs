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
            return View();
        }
    }
}
