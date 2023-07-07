using RutasAPI.Data;
using Rutas.Domain;
using RutasAPI.Repositories.Interfaces;

namespace RutasAPI.Repositories.Implementacion
{
    public class AutobusesRepo : RepositorioGenerico<AutobusDto, string>, IAutobusRepo
    {
        private readonly AppDbContext dbContext;
        private readonly string storeProcedure = "spAutobuses";

        public AutobusesRepo(AppDbContext dbContext) : base (dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Create(AutobusDto entity)
        {
            entity.Opcion = (int) Opciones.Crear;
            return await Crear(entity, storeProcedure);
        }

        public async Task<bool> Delete(AutobusDto entity)
        {
            entity.Opcion = (int)Opciones.Eliminar;
            return await Eliminar(entity, storeProcedure);
        }

        public async Task<List<AutobusDto>> GetAll()
        {
            AutobusDto entity = new AutobusDto { Opcion = (int)Opciones.TraerTodo };
            return await LeerTodos<AutobusDto>(entity, storeProcedure);
        }

        public async Task<bool> Update(AutobusDto entity)
        {
            entity.Opcion = (int)Opciones.Actualizar;
            return await Actualizar(entity, storeProcedure);
        }
    }
}
