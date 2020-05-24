﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.IoC.Domain.Entities.DTOs;
using Sample.IoC.Domain.Interfaces;

namespace Sample.IoC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IServiceClub _serviceClub;

        public ClubController(IServiceClub serviceClub)
        {
            _serviceClub = serviceClub;
        }

        [HttpGet]
        public IActionResult CalculatePercentage([FromQuery] ClubDTO clubDTO)
        {
            try
            {
                var data = _serviceClub.CalculatePercentage(clubDTO);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}