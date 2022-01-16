using Lesson1.SQL_Injecrion.DAL.Models;

namespace Lesson1.SQL_Injecrion.Interfaces
{
    /// <summary> Интерфейс репозитория. </summary>
    /// <typeparam name="T"> Класс. </typeparam>
    public interface IRepository<T> where T : class, ICardEntity
    {
        /// <summary> Получить список экземпляров. </summary>
        /// <param name="Cancel"></param>
        /// <returns> Список экземпляров.</returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken Cancel = default);

        /// <summary> Получить (проверить наличие) экземпляр класса. </summary>
        /// <param name="item"> Экземпляр класса. </param>
        /// <param name="Cancel"></param>
        /// <returns> Экземпляр класса. </returns>
        Task<T?> GetAsync(T item, CancellationToken Cancel = default);

        /// <summary> Добавить экземпляр класса в БД. </summary>
        /// <param name="item"> Экземпляр класса. </param>
        /// <param name="Cancel"></param>
        void AddAsync(T item, CancellationToken Cancel = default);

        /// <summary> Обновить. </summary>
        /// <param name="item"> Экземпляр класса. </param>
        /// <param name="Cancel"></param>
        /// <returns> Результат действия. </returns>
        Task<bool> UpdateAsync(T item, CancellationToken Cancel = default);

        /// <summary> Удалить экземпляр класса. </summary>
        /// <param name="item"> Экземпляр класса. </param>
        /// <param name="Cancel"></param>
        /// <returns> Результат действия. </returns>
        Task<bool> DeleteAsync(T item, CancellationToken Cancel = default);
    }
}
