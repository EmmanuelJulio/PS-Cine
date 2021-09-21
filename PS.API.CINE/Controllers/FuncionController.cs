using Microsoft.AspNetCore.Mvc;
using PS.APLICATION.Services;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.API.CINE.Controllers
{
    public class FuncionController : Controller
    {

        private readonly IFuncionService _service;

        public FuncionController(IFuncionService service)
        {

            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromQuery] Funciones funciones)
        {
            return new JsonResult(_service.AddFunctionAndReturn(funciones)) { StatusCode = 201 };
        }
        [HttpGet]
        public IActionResult GetFunciones()
        {
            try
            {
                return new JsonResult(_service.OptenerTodasLasFunciones()) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
