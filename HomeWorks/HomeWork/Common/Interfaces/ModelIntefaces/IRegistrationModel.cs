namespace SecureDev.HomeWork.ViewModels;

public interface IRegistrationModel
{
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
    public string ReturnUrl { get; set; }
    public string Role { get; set; }
    public string UserName { get; set; }
}
