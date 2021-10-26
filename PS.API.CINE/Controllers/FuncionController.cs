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
        [Route("api/funcion")]


        [HttpPost]
        public IActionResult Post([FromBody] FuncionesDTO funciones)
        {


            ResponseDTO<FuncionesDTO> response = _service.AddFunctionAndReturn(funciones);

            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 400 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 201 };
            }
        }


        [Route("api/funcion/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            ResponseDTO<object> response = _service.Delete(id);

            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 400 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 201 };
            }



        }


        [HttpGet]
        [Route("api/funcion/pelicula/{peliculaId}")]
        public IActionResult GetFuncionesPelicula(int peliculaId)
        {

            ResponseDTO<object> response = _service.GetFuncionesDePelicula(peliculaId);

            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 400 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 201 };
            }




        }
        [HttpGet("api/funcion/{id}/tickets")]
        public IActionResult GetTicketsRestantes(int id)
        {

            ResponseDTO<object> response = _service.GetTicketsRestantes(id);

            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 400 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 200};
            }
           
        }
      
        [Route("api/funcion")]
        [HttpGet]
        public IActionResult GetFuncionesFechaNombre([FromQuery]string Fecha="",[FromQuery]string Titulo="")
        {
            var fecha = Fecha;
            if (string.IsNullOrEmpty(fecha))
                fecha = DateTime.Today.ToString("yyyy/MM/dd");
               


            ResponseDTO<object> response = _service.GetFuncionesCondicional(fecha, Titulo);

            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 400 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 200 };
            }

        }
        [Route("api/funcion/id")]
        [HttpGet]
        public IActionResult GetFuncionByIdFilm(int id)
        {
            ResponseDTO<object> response = _service.GetFuncionById(id);

            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 400 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 200 };
            }

        }
    }
}
