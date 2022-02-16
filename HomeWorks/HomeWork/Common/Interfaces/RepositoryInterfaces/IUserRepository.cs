using SecureDev.HomeWork.DAL.Models;

namespace Common.Interfaces.RepositoryInterfaces;

public interface IUserRepository
{
    public Task<List<UserModel>> GetAllAsync(CancellationToken Cancel = default);
    public Task<bool> DeleteAsync(int id);
    public Task<UserModel> GetById(int id);
    public Task<bool> UpdateAsync(int id, int robotTypeIndex);
}
