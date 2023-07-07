using RutasAPI.Data;
using Rutas.Domain;
using RutasAPI.Repositories.Interfaces;

namespace RutasAPI.Repositories.Implementacion
{
    public class CiudadesRepo : RepositorioGenerico<CiudadDto, string>, ICiudadesRepo
    {
        private readonly AppDbContext dbContext;
        private readonly string storeProcedure = "spCiudades";

        public CiudadesRepo(AppDbContext dbContext) : base (dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Create(CiudadDto entity)
        {
            entity.Opcion = (int) Opciones.Crear;
            return await Crear(entity, storeProcedure);
        }

        public async Task<bool> Delete(CiudadDto entity)
        {
            entity.Opcion = (int)Opciones.Eliminar;
            return await Eliminar(entity, storeProcedure);
        }

        public async Task<List<CiudadDto>> GetAll()
        {
            CiudadDto entity = new CiudadDto { Opcion = (int)Opciones.TraerTodo };
            return await LeerTodos<CiudadDto>(entity, storeProcedure);
        }

        public async Task<bool> Update(CiudadDto entity)
        {
            entity.Opcion = (int)Opciones.Actualizar;
            return await Actualizar(entity, storeProcedure);
        }
    }
}
