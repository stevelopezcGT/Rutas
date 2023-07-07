using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rutas.Domain
{
    public class ConductorDto : DtoBase
    {        
        public int Id { get; set; }

        public string? Nombre { get; set; }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
