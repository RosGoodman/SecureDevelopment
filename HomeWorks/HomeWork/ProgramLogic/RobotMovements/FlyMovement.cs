
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;

namespace ProgramLogic.RobotMovements;

public class FlyMovement : MovementAbstract
{
    public override string Move()
    {
        return "Летит";
    }
}
