using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.API.CINE.Controllers
{
    public class SalaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
