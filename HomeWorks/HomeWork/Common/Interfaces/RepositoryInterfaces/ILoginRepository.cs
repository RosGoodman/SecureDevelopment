using SecureDev.HomeWork.DAL.Models;
using SecureDev.HomeWork.ViewModels;

namespace SecureDev.HomeWork.DAL.Repositories
{
    public interface ILoginRepository
    {
        Task<UserModel> ChekUserIdDB(ILoginViewModel vm);
    }
}