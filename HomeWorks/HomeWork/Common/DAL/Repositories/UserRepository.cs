
using Common.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecureDev.HomeWork.DAL.Context;
using SecureDev.HomeWork.DAL.Models;

namespace Common.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ILogger<UserRepository> _logger;
    private readonly ContextDB _db;

    protected DbSet<UserModel> Set { get; }

    public UserRepository(ILogger<UserRepository> logger, ContextDB db)
    {
        _logger = logger;
        _logger.LogDebug(1, "логгер всроен в UserRepository.");
        _db = db;
        Set = _db.Set<UserModel>();
    }

    public async Task<List<UserModel>> GetAllAsync(CancellationToken Cancel = default)
    {
        return await Set.ToListAsync(Cancel).ConfigureAwait(false);
    }

    public async Task<bool> Delete(int id)
    {
        var itemRemove = await Set.Where(i => i.Id == id).FirstOrDefaultAsync();
        if (itemRemove is null) return false;

        Set.Remove(itemRemove);
        _db.SaveChanges();
        return true;
    }
}
