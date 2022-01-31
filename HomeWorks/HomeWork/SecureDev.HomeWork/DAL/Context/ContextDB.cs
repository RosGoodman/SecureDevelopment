
using SecureDev.HomeWork.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace SecureDev.HomeWork.DAL.Context
{
    /// <summary> Контекст базы данных. </summary>
    public class ContextDB : DbContext, IContextDB
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public ContextDB(DbContextOptions<ContextDB> Options) : base(Options) { }

        /// <summary> "Завернутый метод для использования в DI. </summary>
        public void SaveChangesDB() => SaveChanges();
    }
}
