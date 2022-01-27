using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SecureDev.HomeWork.ViewModels
{
    public class LoginViewModel : ILoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [ValidateNever]
        public string ReturnUrl { get; set; }
    }
}
