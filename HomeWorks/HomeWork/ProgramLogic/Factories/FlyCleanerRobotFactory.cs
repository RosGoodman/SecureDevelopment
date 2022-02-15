
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Entities.Tools;
using ProgramLogic.RobotMovements;

namespace ProgramLogic.Factories;

public class FlyCleanerRobotFactory : RobotFactory
{
    public override MovementAbstract CreateMovement()
    {
        return new FlyMovement();
    }

    public override ToolAbstract CreateTool()
    {
        return new VacuumCleaner();
    }
}
