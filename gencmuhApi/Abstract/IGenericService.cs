namespace gencmuhApi.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<string> AddAsync(T t);
        Task DeleteAsync(T t);
        Task UpdateAsync(T t);
        T GetById(int id);
        Task<List<T>> AllListAsync();
    }
}