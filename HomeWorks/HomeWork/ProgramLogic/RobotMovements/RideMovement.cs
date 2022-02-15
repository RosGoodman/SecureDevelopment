
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;

namespace ProgramLogic.RobotMovements;

public class RideMovement : MovementAbstract
{
    public override string Move()
    {
       return "Едет";
    }
}
