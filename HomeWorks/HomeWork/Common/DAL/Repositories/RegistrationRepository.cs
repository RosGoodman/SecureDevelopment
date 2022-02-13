using Microsoft.Extensions.Logging;
using SecureDev.HomeWork.DAL.Context;
using SecureDev.HomeWork.DAL.Models;
using SecureDev.HomeWork.ViewModels;

namespace SecureDev.HomeWork.DAL.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ILogger<RegistrationRepository> _logger;
        private readonly IContextDB _context;
        public RegistrationRepository(ILogger<RegistrationRepository> logger, IContextDB context)
        {
            _logger = logger;
            _logger.LogDebug(1, "логгер всроен в RegistrationRepository.");
            _context = context;
        }

        /// <summary> Зарегистрировать нового пользователя. </summary>
        /// <param name="vm"> Модель с данными нового пользователя. </param>
        /// <returns> Зрегистрироване/не зарегистрирован. </returns>
        public async Task<bool> TryRegisterAsync(IRegistrationModel vm)
        {
            try
            {
                //проверка существования логина. для упрощения запихнул сюда, как и пароль
                UserModel user = _context.Users.Where(l => l.Login == vm.UserName).FirstOrDefault();
                if (user != null) return false;

                user = new UserModel() { Login = vm.UserName, Role = vm.Role, UserPassword = vm.Password };
                await _context.Users.AddAsync(user);
                _context.SaveChangesDB();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(1, "Ошибка при попытке зарегистрировать пользователя.");
                return false;
            }
        }
    }
}
