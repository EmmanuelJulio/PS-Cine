﻿using Microsoft.AspNetCore.Mvc;
using PS.APLICATION.Services;
using PS.DOMAIN.Comands;
using PS.DOMAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.API.CINE.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IGenericsRepository _repocitory;
        private readonly ITicketService _service;

        public TicketsController(IGenericsRepository repocitory, ITicketService service)
        {
            _repocitory = repocitory;
            _service = service;
        }
        [Route("api/[controller]")]
        [HttpPost]

        public IActionResult Post([FromBody] TicketDTO Tiket)
        {
            return new JsonResult(_service.AddTiket(Tiket)) { StatusCode = 201 };
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}