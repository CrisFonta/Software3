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
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public UsuarioController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return context.Usuarios.ToList();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(usuario);
            }
        }

        // POST: api/Usuario
        [HttpPost]
        public IActionResult AgregarUsuario([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return new CreatedAtRouteResult("establecimientoCreado", new { id = usuario.Id }, usuario);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario([FromBody] Usuario usuario, int id)
        {
            if (usuario.Id != id)
            {
                return BadRequest();
            }
            context.Entry(usuario).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            return Ok(usuario);
        }
    }
