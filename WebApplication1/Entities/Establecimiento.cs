using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Establecimiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("NombreDueno")]
        public int IdDueno { get; set; }
        public Usuario NombreDueno { get; set; }
        public int Cantidad { get; set; }
    }
}
