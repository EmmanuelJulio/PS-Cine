using Microsoft.AspNetCore.Mvc;
using PS.APLICATION.Services;
using PS.DOMAIN.Comands;
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
                return new JsonResult(_service.GetFilm(id)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "No se devuelve nada" + e.Message });
            }
        }
    }
}
