namespace SecureDev.HomeWork.ViewModels
{
    public interface IRegistrationViewModel
    {
        string Password { get; set; }
        string RepeatPassword { get; set; }
        string ReturnUrl { get; set; }
        string Role { get; set; }
        string UserName { get; set; }
    }
}