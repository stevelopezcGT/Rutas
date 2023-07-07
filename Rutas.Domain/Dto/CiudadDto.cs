using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rutas.Domain
{
    public class CiudadDto
    {
        public int Opcion { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre Invalido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Dirección Invalido")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Teléfono Invalido")]
        public string? Telefono { get; set; }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
