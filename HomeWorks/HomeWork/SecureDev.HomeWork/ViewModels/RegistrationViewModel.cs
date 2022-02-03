
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SecureDev.HomeWork.ViewModels;

/// <summary> Модель, описывающая данные вводимые пользователем при регистрации. </summary>
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
    [ValidateNever]
    public string ReturnUrl { get; set; }

    public RegistrationViewModel() { }
}
