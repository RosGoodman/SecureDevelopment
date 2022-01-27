using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SecureDev.HomeWork.DAL.Models;

public class UserModel : IUserModel
{
    [Key]
    public int Id { get; set; }
    [BindProperty]
    public string Login { get; set; }
    [BindProperty]
    public string Role { get; set; }
    [BindProperty]
    public string UserPassword { get; set; }

    public UserModel() { }
}
