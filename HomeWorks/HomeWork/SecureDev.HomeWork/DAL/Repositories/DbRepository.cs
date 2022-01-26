using Lesson1.SQL_Injecrion.DAL.Context;
using Lesson1.SQL_Injecrion.DAL.Models;
using Lesson1.SQL_Injecrion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lesson1.SQL_Injecrion.DAL.Repositories;

/// <summary> Репозиторий БД. </summary>
/// <typeparam name="T"> Класс. </typeparam>
internal class DbRepository<T> : IRepository<T> where T : class, ICardEntity
{
    private readonly CardDB _db;
    protected DbSet<T> Set { get; }

    /// <summary> Контруктор репозиторя БД. </summary>
    /// <param name="db"> Контекст БД. </param>
    public DbRepository(CardDB db)
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
