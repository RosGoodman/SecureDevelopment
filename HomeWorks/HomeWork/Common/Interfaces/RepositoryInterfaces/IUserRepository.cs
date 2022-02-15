using SecureDev.HomeWork.DAL.Models;

namespace Common.Interfaces.RepositoryInterfaces;

public interface IUserRepository
{
    public Task<List<UserModel>> GetAllAsync(CancellationToken Cancel = default);
    public Task<bool> Delete(int id);
    public UserModel GetById(int id);
}
