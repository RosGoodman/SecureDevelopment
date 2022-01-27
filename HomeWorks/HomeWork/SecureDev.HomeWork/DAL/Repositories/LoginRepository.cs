using SecureDev.HomeWork.DAL.Context;
using SecureDev.HomeWork.DAL.Models;
using SecureDev.HomeWork.ViewModels;

namespace SecureDev.HomeWork.DAL.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ILogger<LoginRepository> _logger;
        private readonly IContextDB _context;
        public LoginRepository(ILogger<LoginRepository> logger, IContextDB context)
        {
            _logger = logger;
            _logger.LogDebug(1, "логгер всроен в LoginRepository.");
            _context = context;
        }

        public async Task<UserModel> ChekUserIdDB(ILoginViewModel vm)
        {
            try
            {
                UserModel user = _context.Users.Where(l => (l.Login == vm.UserName) && (l.UserPassword == vm.Password)).FirstOrDefault();
                if (user != null) return user;
                
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(1, "Ошибка при попытке зарегистрировать пользователя.");
                return null;
            }
        }
    }
}
