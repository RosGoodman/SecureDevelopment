
using System.ComponentModel.DataAnnotations;

namespace SecureDev.HomeWork.ViewModels;

public class RegistrationViewModel : IRegistrationViewModel
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string RepeatPassword { get; set; }
    [Required]
    public string Role { get; set; }
    [Required]
    public string ReturnUrl { get; set; }

    public RegistrationViewModel() { }
}
