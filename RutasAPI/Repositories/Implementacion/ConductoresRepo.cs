using RutasAPI.Data;
using Rutas.Domain;
using RutasAPI.Repositories.Interfaces;

namespace RutasAPI.Repositories.Implementacion
{
    public class ConductoresRepo : RepositorioGenerico<ConductorDto, string>, IConductoresRepo
    {
        private readonly AppDbContext dbContext;
        private readonly string storeProcedure = "spConductores";

        public ConductoresRepo(AppDbContext dbContext) : base (dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Create(ConductorDto entity)
        {
            entity.Opcion = (int) Opciones.Crear;
            return await Crear(entity, storeProcedure);
        }

        public async Task<bool> Delete(ConductorDto entity)
        {
            entity.Opcion = (int)Opciones.Eliminar;
            return await Eliminar(entity, storeProcedure);
        }

        public async Task<List<ConductorDto>> GetAll()
        {
            ConductorDto entity = new ConductorDto { Opcion = (int)Opciones.TraerTodo };
            return await LeerTodos<ConductorDto>(entity, storeProcedure);
        }

        public async Task<bool> Update(ConductorDto entity)
        {
            entity.Opcion = (int)Opciones.Actualizar;
            return await Actualizar(entity, storeProcedure);
        }
    }
}
