using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SecureDev.HomeWork.ViewModels
{
    /// <summary> Модель, описвыающая вводимые пользователем данные при входе. </summary>
    public class LoginViewModel : ILoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [ValidateNever]
        public string ReturnUrl { get; set; }
        [ValidateNever]
        public string Id { get; set; }
    }
}
