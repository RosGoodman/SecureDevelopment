
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;

namespace ProgramLogic.Factories;

public class EmptyFrameRobotFactory : RobotFactory
{
    public override MovementAbstract CreateMovement() => null;

    public override ToolAbstract CreateTool() => null;
}
