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
    [ApiController]
    [Route("api/pelicula")]
    public class PeliculaController : Controller
    {
        private readonly IGenericsRepository _repocitory;
        private readonly IpeliculaService _service;

        public PeliculaController(IGenericsRepository repocitory, IpeliculaService service)
        {
            _repocitory = repocitory;
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFilm(int id)
        {

            var response = new ResponseDTO<Object>();
            response = _service.GetFilm(id);
            if (!response.Response.Any())
            {
                return new JsonResult(response.Data) { StatusCode = 200 };
            }
            else
            {
                return new JsonResult(response.Response) { StatusCode = 400 };
            }
           
        }
        [HttpGet]
        [Route("/api/pelicula/all")]
        public IActionResult GetAllFilm()
        {
            try
            {
                return new JsonResult(_service.GetAllFilm()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message)) { StatusCode = 400 };
            }
        }
        [HttpGet]
        [Route("/api/pelicula/funcion/{id}")]
        public IActionResult GetFilmByFuntion(int id)
        {

            var response = new ResponseDTO<FuncionViwDTO>();
            response = _service.GetFilmByFuntion(id);
            if (response.Response.Any()) {
                return new JsonResult(response.Response) { StatusCode = 400 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 200 };
            }
        }
        [HttpPut]
       
        public IActionResult UpdatePelicula([FromBody] PeliculaDTO pelicula,[FromQuery]int id)
        {
            try
            {
                return new JsonResult(_service.UpdatePelicula(pelicula, id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message)) { StatusCode = 400 };
            }
        }
    }
}
