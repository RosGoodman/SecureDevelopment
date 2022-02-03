using SecureDev.HomeWork.DAL.Context;
using SecureDev.HomeWork.DAL.Models;
using SecureDev.HomeWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SecureDev.HomeWork.DAL.Repositories;

/// <summary> Репозиторий БД. </summary>
/// <typeparam name="T"> Класс. </typeparam>
internal class DbRepository<T> : IRepository<T> where T : class, ICardEntity
{
    private readonly ContextDB _db;
    protected DbSet<T> Set { get; }

    /// <summary> Контруктор репозиторя БД. </summary>
    /// <param name="db"> Контекст БД. </param>
    public DbRepository(ContextDB db)
    {
        _db = db;
        Set = _db.Set<T>();
    }

    /// <summary> Добавить экземпляр класса в БД. </summary>
    /// <param name="item"> Экземпляр класса. </param>
    /// <param name="Cancel"></param>
    public async Task AddAsync(T item, CancellationToken Cancel = default)
    {
        await Set.AddAsync(item, Cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(Cancel);
    }

    /// <summary> Получить данные о item по номеру. </summary>
    /// <param name="item"> Экземпляр класса. </param>
    /// <param name="Cancel"></param>
    /// <returns> Item, найденный в БД. </returns>
    public async Task<T> GetAsync(T item, CancellationToken Cancel = default)
    {
        //тут при запуске через докер вылетает ошибка, об отсутствии поддержки на данной платформе. В причинах пока не разобрался
        return await Set.FirstOrDefaultAsync(i => i.NumbCard == item.NumbCard, Cancel);

    }

    public Task<bool> UpdateAsync(T item, CancellationToken Cancel = default) => throw new NotImplementedException();
    public Task<bool> DeleteAsync(T item, CancellationToken Cancel = default) => throw new NotImplementedException();
    public Task<IEnumerable<T>> GetAllAsync(CancellationToken Cancel = default) => throw new NotImplementedException();
}
