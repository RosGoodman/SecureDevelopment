using System.ComponentModel.DataAnnotations;

namespace SecureDev.HomeWork.DAL.Models;

public class UserModel : IUserModel
{
    [Key]
    public int Id { get; set; }
    public string Login { get; set; }
    public string Role { get; set; }
}
