using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public string Apellido{ get; set; }
        public string UsuarioLogin { get; set; }
        public string Contrasena { get; set; }
        public List<Establecimiento> Establecimientos { get; set; }
    }
}
