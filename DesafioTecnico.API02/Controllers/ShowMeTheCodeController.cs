﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.API02.Controllers
{
    [Route("api/show-me-the-code")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var uri = new URL() { Uri= "https://github.com/bisslee/DesafioTecnico" };
            return Ok(uri);
        }
    }

    public class URL
    {
        public string Uri { get; set; }
    }
}
