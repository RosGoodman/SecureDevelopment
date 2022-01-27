using Microsoft.AspNetCore.Mvc;

namespace SecureDev.HomeWork.DAL.Models
{
    public interface IUserModel
    {
        int Id { get; set; }
        [BindProperty]
        string Login { get; set; }
        [BindProperty]
        string Role { get; set; }
        [BindProperty]
        string UserPassword { get; set; }
    }
}