using Microsoft.EntityFrameworkCore;
using SecureDev.HomeWork.DAL.Models;

namespace SecureDev.HomeWork.DAL.Context
{
    /// <summary> Интерфейс контекста БД. </summary>
    public interface IContextDB
    {
        DbSet<Card> Cards { get; set; }
        DbSet<UserModel> Users { get; set; }

        void SaveChangesDB();
    }
}