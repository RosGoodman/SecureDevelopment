using SecureDev.HomeWork.ViewModels;

namespace SecureDev.HomeWork.DAL.Repositories
{
    public class RegistrationRepository
    {
        private readonly ILogger<RegistrationRepository> _logger;
        public RegistrationRepository(ILogger<RegistrationRepository> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "логгер всроен в RegistrationRepository.");
        }

        public async Task<bool> TryRegisterAsync(IRegistrationViewModel vm)
        {

        }
    }
}
