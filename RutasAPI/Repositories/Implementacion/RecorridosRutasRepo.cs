using RutasAPI.Data;
using Rutas.Domain;
using RutasAPI.Repositories.Interfaces;

namespace RutasAPI.Repositories.Implementacion
{
    public class RecorridosRutasRepo : RepositorioGenerico<RecorridoRutaDto, string>, IRecorridosRutaRepo
    {
        private readonly AppDbContext dbContext;
        private readonly string storeProcedure = "spRecorridosRuta";

        public RecorridosRutasRepo(AppDbContext dbContext) : base (dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Create(RecorridoRutaDto entity)
        {
            entity.Opcion = (int) Opciones.Crear;
            return await Crear(entity, storeProcedure);
        }

        public async Task<bool> Delete(RecorridoRutaDto entity)
        {
            entity.Opcion = (int)Opciones.Eliminar;
            return await Eliminar(entity, storeProcedure);
        }

        public async Task<List<RecorridoRutaDto>> GetAll()
        {
            RecorridoRutaDto entity = new RecorridoRutaDto { Opcion = (int)Opciones.TraerTodo };
            return await LeerTodos<RecorridoRutaDto>(entity, storeProcedure);
        }

        public async Task<bool> Update(RecorridoRutaDto entity)
        {
            entity.Opcion = (int)Opciones.Actualizar;
            return await Actualizar(entity, storeProcedure);
        }
    }
}
