
namespace SecureDev.HomeWork.DAL.Models;

public interface IUserModel
{
    int Id { get; set; }
    string Login { get; set; }
    string Role { get; set; }
    string UserPassword { get; set; }

    int RobotId { get; set; }
}