
using SecureDev.HomeWork.ViewModels;

namespace SecureDev.HomeWork.DAL.Repositories;

public interface IRegistrationRepository
{
    Task<bool> TryRegisterAsync(IRegistrationModel vm);
}
