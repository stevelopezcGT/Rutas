using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rutas.Domain
{
    public class AutobusRutaDto
    {
        public int Opcion { get; set; }
        public int Id { get; set; }

        public int? IdAutobus { get; set; }

        public int? IdRuta { get; set; }

        public bool? AutobusActivo { get; set; }
        public string? Matricula { get; set; }

        public string? Modelo { get; set; }
        public string? Codigo { get; set; }
        public decimal? Km_Recorridos { get; set; }
        public string? NombreConductor { get; set; }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
