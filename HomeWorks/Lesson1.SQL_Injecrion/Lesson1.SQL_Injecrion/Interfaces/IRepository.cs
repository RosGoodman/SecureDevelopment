using Lesson1.SQL_Injecrion.DAL.Models;

namespace Lesson1.SQL_Injecrion.Interfaces
{
    public interface IRepository<T> where T : class, ICardEntity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken Cancel = default);

        Task<T?> GetAsync(T item, CancellationToken Cancel = default);

        Task<int> AddAsync(T item, CancellationToken Cancel = default);

        Task<bool> UpdateAsync(T item, CancellationToken Cancel = default);

        Task<bool> DeleteAsync(T item, CancellationToken Cancel = default);
    }
}
