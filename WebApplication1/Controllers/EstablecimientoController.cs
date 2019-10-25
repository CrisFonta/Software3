using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstablecimientoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public EstablecimientoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Establecimiento> Get()
        {
            return context.Establecimientos.ToList();
        }
        [HttpGet("{id}", Name ="establecimientoCreado")]
        public IActionResult GetById(int id)
        {
            var establecimiento = context.Establecimientos.FirstOrDefault(x => x.Id == id);
            if(establecimiento == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(establecimiento);
            }
        }
        [HttpPost]
        public IActionResult AgregarEstablecimiento([FromBody] Establecimiento establecimiento)
        {
            if (ModelState.IsValid)
            {
                context.Establecimientos.Add(establecimiento);
                context.SaveChanges();
                return new CreatedAtRouteResult("establecimientoCreado", new { id = establecimiento.Id }, establecimiento);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult ActualizarEstablecimiento([FromBody] Establecimiento establecimiento, int id)
        {
            if(establecimiento.Id != id)
            {
                return BadRequest();
            }
            context.Entry(establecimiento).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var establecimiento = context.Establecimientos.FirstOrDefault(x=>x.Id == id);
            if (establecimiento==null)
            {
                return NotFound();
            }
            context.Establecimientos.Remove(establecimiento);
            context.SaveChanges();
            return Ok(establecimiento);
        }
    }
}