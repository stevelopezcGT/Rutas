using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rutas.Domain
{
    public class RecorridoRutaDto
    {
        public int Opcion { get; set; }
        public int Id { get; set; }

        public int? IdRuta { get; set; }

        public int? IdCiudad { get; set; }

        public int? Orden { get; set; }

        public bool? EsInicio { get; set; }

        public bool? EsFinal { get; set; }
        public string? Codigo { get; set; }
        public string? NombreCiudad { get; set; }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
