using RutasAPI.Data;
using Rutas.Domain;
using RutasAPI.Repositories.Interfaces;

namespace RutasAPI.Repositories.Implementacion
{
    public class AutobusRutaRepo : RepositorioGenerico<AutobusRutaDto, string>, IAutobusRutaRepo
    {
        private readonly AppDbContext dbContext;
        private readonly string storeProcedure = "spAutobuses_Ruta";

        public AutobusRutaRepo(AppDbContext dbContext) : base (dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Create(AutobusRutaDto entity)
        {
            entity.Opcion = (int) Opciones.Crear;
            return await Crear(entity, storeProcedure);
        }

        public async Task<bool> Delete(AutobusRutaDto entity)
        {
            entity.Opcion = (int)Opciones.Eliminar;
            return await Eliminar(entity, storeProcedure);
        }

        public async Task<List<AutobusRutaDto>> GetAll()
        {
            AutobusRutaDto entity = new AutobusRutaDto { Opcion = (int)Opciones.TraerTodo };
            return await LeerTodos<AutobusRutaDto>(entity, storeProcedure);
        }

        public async Task<bool> Update(AutobusRutaDto entity)
        {
            entity.Opcion = (int)Opciones.Actualizar;
            return await Actualizar(entity, storeProcedure);
        }
    }
}
