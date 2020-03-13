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
        //WS consumido al momento de autenticar
        //GET: api/Usuario/login
        [HttpGet("login")]
        public IActionResult Login([FromBody] Usuario usuarioData)
        {
            var usuario = context.Usuarios.Where(x => x.Contrasena == usuarioData.Contrasena).Where(x => x.UsuarioLogin == usuarioData.UsuarioLogin).FirstOrDefault();
            if (usuario!=null)
            {
                return Ok(usuario);
            }
            return NotFound();
        }
        //WS consumido al momento de consultar la lista de usuarios
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return context.Usuarios.ToList();
        }
        //WS consumido al momento de consultar un usuario por su identificador
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
        //WS consumido al momento de registrar un usuario
        // POST: api/Usuario
        [HttpPost]
        public IActionResult AgregarUsuario([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var user = context.Usuarios.FirstOrDefault(x => x.UsuarioLogin == usuario.UsuarioLogin);
                if (user == null)
                {
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();
                    return new CreatedAtRouteResult("establecimientoCreado", new { id = usuario.Id }, usuario);
                }
                return Conflict();
                
            }
            return BadRequest(ModelState);
        }
        //WS consumido al momento de modificar un usuario identificado por su id
        // PUT: api/Usuario/1
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
        //WS consumido al momento de eliminar un usuario identificado por su id
        // DELETE: api/Usuario/1
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
    }
