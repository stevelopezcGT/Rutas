using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rutas.Domain
{
    public class RutaDto
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public decimal? Km_Recorridos { get; set; }
        public int IdCiudadInicio { get; set; }
        public int IdCiudadFinal { get; set; }
        public string? CiudadInicio { get; set; }
        public string? CiudadFinal { get; set; }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
