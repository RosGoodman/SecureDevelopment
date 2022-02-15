
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Entities.Tools;
using ProgramLogic.RobotMovements;

namespace ProgramLogic.Factories;

public class RideHummerRobotFactory : RobotFactory
{
    public override MovementAbstract CreateMovement()
    {
        return new RideMovement();
    }

    public override ToolAbstract CreateTool()
    {
        return new Hummer();
    }
}
