using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contexts;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengesJsonController : ControllerBase
    {
        private string ChallengesJson;
        private IWebHostEnvironment hostEnvironment;

        public ChallengesJsonController(IWebHostEnvironment hostEnvironment)
        {
           this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
           return Ok(this.ChallengesJson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] object challengesJson)
        {
            using (StreamWriter writer = 
                    new StreamWriter(hostEnvironment.ContentRootPath + "/App_Data/challenges.json"))
            {
                writer.Write(challengesJson);
            }

            return Ok(true);
        }
    }
}
