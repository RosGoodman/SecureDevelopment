
using Lesson1.SQL_Injecrion.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson1.SQL_Injecrion.DAL.Context
{
    public class CardDB : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        public CardDB(DbContextOptions<CardDB> Options) : base(Options)
        {

        }
    }
}
