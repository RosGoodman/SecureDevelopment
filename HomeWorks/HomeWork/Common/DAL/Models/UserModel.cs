using System.ComponentModel.DataAnnotations;

namespace SecureDev.HomeWork.DAL.Models;

/// <summary> Модель пользователя аккаунтом. </summary>
public class UserModel : IUserModel
{
    /// <summary> ID пользователя. </summary>
    [Key]
    public int Id { get; set; }
    /// <summary> Логин. </summary>
    public string Login { get; set; }
    /// <summary> Роль. </summary>
    public string Role { get; set; }
    /// <summary> Пароль. </summary>
    public string UserPassword { get; set; }

    public UserModel() { }
}
