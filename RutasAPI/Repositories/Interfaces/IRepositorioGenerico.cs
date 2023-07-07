namespace RutasAPI.Repositories.Interfaces
{
    public interface IRepositorioGenerico<T, Y> where T : class
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task <bool> Delete(T entity);
        Task<List<T>> GetAll();
    }
}
