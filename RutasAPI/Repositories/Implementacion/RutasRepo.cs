using RutasAPI.Data;
using Rutas.Domain;
using RutasAPI.Repositories.Interfaces;

namespace RutasAPI.Repositories.Implementacion
{
    public class RutasRepo : RepositorioGenerico<RutaDto, string>, IRutasRepo
    {
        private readonly AppDbContext dbContext;
        private readonly string storeProcedure = "spRutas";

        public RutasRepo(AppDbContext dbContext) : base (dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Create(RutaDto entity)
        {
            entity.Opcion = (int) Opciones.Crear;
            return await Crear(entity, storeProcedure);
        }

        public async Task<bool> Delete(RutaDto entity)
        {
            entity.Opcion = (int)Opciones.Eliminar;
            return await Eliminar(entity, storeProcedure);
        }

        public async Task<List<RutaDto>> GetAll()
        {
            RutaDto entity = new RutaDto { Opcion = (int)Opciones.TraerTodo };
            return await LeerTodos<RutaDto>(entity, storeProcedure);
        }

        public async Task<bool> Update(RutaDto entity)
        {
            entity.Opcion = (int)Opciones.Actualizar;
            return await Actualizar(entity, storeProcedure);
        }
    }
}
