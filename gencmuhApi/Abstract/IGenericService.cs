namespace gencmuhApi.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task AddAsync(T t);
        Task DeleteAsync(T t);
        Task UpdateAsync(T t);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> AllListAsync();
    }
}