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
        public IActionResult Post([FromBody] FuncionesDTO funciones)
        {
            return new JsonResult(_service.AddFunctionAndReturn(funciones)) { StatusCode = 201 };
        }


        [Route("api/[controller]")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return new JsonResult(_service.Delete(id)) { StatusCode = 201 };
        }

        
        [HttpGet]
        [Route("/funcion/pelicula")]
        public IActionResult GetFuncionesPelicula (int id)
        {
            try
            {
                return new JsonResult(_service.GetFuncionesDePelicula(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/tickets")]

        public async Task<ActionResult<int>> GetTicketsRestantes(int id)
        {
            try
            {
                return new JsonResult(_service.GetTicketsRestantes(id)) { StatusCode = 200 };

                
            }
            catch (Exception e)
            {

                return new JsonResult(e.Message) { StatusCode = 404 };
            }
        }
    }
}
