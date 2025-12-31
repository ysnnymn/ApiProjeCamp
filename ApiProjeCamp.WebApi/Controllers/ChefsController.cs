using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProjeCamp.WebApi.Context;
using ApiProjeCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Eklendi");
        }

        [HttpGet("GetChef")]
        public IActionResult GetChef(int id)
        {
            var value=_context.Chefs.FirstOrDefault(x => x.ChefId == id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Güncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value=_context.Chefs.FirstOrDefault(x => x.ChefId == id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Silindi");
        }
        
    }
}
