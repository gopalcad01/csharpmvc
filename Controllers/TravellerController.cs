using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace firstsitecsharp.Controllers
{
    //  [Route("[controller]")]
    public class TravellerController : Controller
    {
        private readonly ILogger<TravellerController> _logger;

        public TravellerController(ILogger<TravellerController> logger)
        {
            _logger = logger;
        }

        //  [Route("Traveller/Index")]
        public IActionResult Index()
        {
            return View("Index", "_LayoutTraveller");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}