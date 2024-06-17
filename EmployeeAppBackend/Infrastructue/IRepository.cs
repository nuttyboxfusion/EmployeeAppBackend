namespace EmployeeAppBackend.Infrastructue
{
    /// <summary>
    /// Generic interface repository for CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByStringIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(string id);
    }
}
