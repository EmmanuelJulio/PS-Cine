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
    [Route("api/Pelicula")]
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
        public IActionResult GetFilm(int id)
        {
            try
            {
                return new JsonResult(_service.GetFilm(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "No se devuelve nada" + e.Message });
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdatePelicula([FromBody] PeliculaDTO pelicula,[FromQuery]int id)
        {
            return new JsonResult(_service.UpdatePelicula(pelicula,id)) { StatusCode = 200 };
        }
    }
}
