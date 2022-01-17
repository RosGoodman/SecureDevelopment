using Lesson1.SQL_Injecrion.DAL.Models;
using Lesson1.SQL_Injecrion.Interfaces;
using System.Data.SqlClient;

namespace Lesson1.SQL_Injecrion.DAL.Repositories;

/// <summary> Репозиторий БД. </summary>
/// <typeparam name="T"> Класс. </typeparam>
public class DbRepository<T> : IRepository<T> where T : class, ICardEntity
{
    private ILogger _logger;

    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Cards.db";

    /// <summary> Контруктор репозиторя БД. </summary>
    /// <param name="db"> Контекст БД. </param>
    public DbRepository(ILogger<DbRepository<T>> logger)
    {
        _logger = logger;
    }

    /// <summary> Добавить экземпляр класса в БД. </summary>
    /// <param name="item"> Экземпляр класса. </param>
    /// <param name="Cancel"></param>
    public async void AddAsync(Card item, CancellationToken Cancel = default)
    {
        string format = "dd-MM-yyyy";
        string command = $"INSERT INTO Cards (CardOwner, NumbCard, CVV_CVC, Validity) VALUES ({item.CardOwner}, {item.NumbCard}, {item.CVV_CVC}, '{item.Validity.ToString(format)}')";

        SqlConnection connection = new SqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync();
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex) { _logger.LogError(ex, "ошибка при попытке подключения к БД."); }
    }

    /// <summary> Получить данные о item по номеру. </summary>
    /// <param name="item"> Экземпляр класса. </param>
    /// <param name="Cancel"></param>
    /// <returns> Item, найденный в БД. </returns>
    public async Task<Card?> GetAsync(Card item, CancellationToken Cancel = default)
    {
        string command = $"SELECT * FROM Cards WHERE NumbCard={item.NumbCard}";
        Card card = new Card();

        SqlConnection connection = new SqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync();
            SqlCommand cmd = new SqlCommand(command, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                card.CardOwner = reader.GetValue(1).ToString();
                card.NumbCard = (long)reader.GetValue(2);
                card.CVV_CVC = (int)reader.GetValue(3);
                card.Validity = Convert.ToDateTime(reader.GetValue(4));
            }
            if (card.NumbCard == 0) card = null;
            return card;
        }
        catch (Exception ex) { _logger.LogError(ex, "ошибка при попытке подключения к БД."); }

        return null;
    }

    public Task<bool> UpdateAsync(T item, CancellationToken Cancel = default) => throw new NotImplementedException();
    public Task<bool> DeleteAsync(T item, CancellationToken Cancel = default) => throw new NotImplementedException();

    public Task<IEnumerable<T>> GetAllAsync(CancellationToken Cancel = default) => throw new NotImplementedException();
}
