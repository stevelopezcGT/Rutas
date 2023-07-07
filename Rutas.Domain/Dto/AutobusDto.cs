
namespace Rutas.Domain
{
    public class AutobusDto
    {
        public int Opcion { get; set; }
        public int Id { get; set; }

        public string? Matricula { get; set; }

        public string? Modelo { get; set; }

        public int Capacidad { get; set; }

        public int? IdConductor { get; set; }
        public string? NombreConductor { get; set; }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}