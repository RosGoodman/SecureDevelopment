namespace SecureDev.HomeWork.ViewModels
{
    public interface ILoginViewModel
    {
        string Password { get; set; }
        string ReturnUrl { get; set; }
        string UserName { get; set; }
    }
}