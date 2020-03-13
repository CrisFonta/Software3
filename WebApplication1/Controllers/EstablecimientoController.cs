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
        // Constructor del controller que recibe el contexto de la base de datos
          
        public EstablecimientoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //WS consumido para obtener la lista de establecimientos existentes
        //GET: api/establecimiento
        [HttpGet]
        public IEnumerable<Establecimiento> Get()
        {
            return context.Establecimientos.ToList();
        }
        //WS consumido para obtener la informacion de un establecimiento identificado por su id
        //GET: api/establecimiento/1
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
        //WS consumido para obtener la lista de establecimientos existentes
        //POST: api/establecimiento
        [HttpPost]
        public IActionResult AgregarEstablecimiento([FromBody] Establecimiento establecimiento)
        {
            if (ModelState.IsValid)
            {
                if(establecimiento.Cantidad <0||establecimiento.IdDueno <=0||establecimiento.Nombre==null)
                {
                    return NoContent();
                }
                context.Establecimientos.Add(establecimiento);
                context.SaveChanges();
                return new CreatedAtRouteResult("establecimientoCreado", new { id = establecimiento.Id }, establecimiento);
            }
            return BadRequest(ModelState);
        }
        //WS consumido para Actualizar la información de un establecimiento identificado por el id
        //PUT: api/establecimiento/1
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
        //WS consumido para eliminar la información de un establecimiento identificado por el id
        //DELETE: api/establecimiento/1
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