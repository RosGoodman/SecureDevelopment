using Lesson1.SQL_Injecrion.DAL.Context;
using Lesson1.SQL_Injecrion.DAL.Models;
using Lesson1.SQL_Injecrion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lesson1.SQL_Injecrion.DAL.Repositories
{
    public class DbRepository<T> : IRepository<T> where T : class, ICardEntity
    {
        private readonly CardDB _db;
        protected DbSet<T> Set { get; }

        public DbRepository(CardDB db)
        {
            _db = db;
            Set = _db.Set<T>();
        }

        public Task<int> AddAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetAsync(T item, CancellationToken Cancel = default)
        {
            //тут при запуске через докер вылетает ошибка, об отсутствии поддержки на данной платформе. В причинах пока не разобрался
            var foundCard = await Set.FirstOrDefaultAsync(i => i.NumbCard == item.NumbCard, Cancel).ConfigureAwait(false);
            if (foundCard != null) return foundCard;

            await Set.AddAsync(item, Cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(Cancel);
            return item;
        }

        public Task<bool> UpdateAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
