using Microsoft.AspNetCore.Mvc;
using PS.APLICATION.Services;
using PS.DOMAIN.Comands;
using PS.DOMAIN.DTOs;
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
        private readonly IGenericsRepository _repository;

        public FuncionController(IFuncionService service, IGenericsRepository repository)
        {
            _service = service;
            _repository = repository;
        }
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromQuery] FuncionesDTO funciones)
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
