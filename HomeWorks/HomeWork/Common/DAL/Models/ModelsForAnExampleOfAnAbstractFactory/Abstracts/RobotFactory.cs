

namespace Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;

public abstract class RobotFactory
{
    public abstract MovementAbstract CreateMovement();
    public abstract ToolAbstract CreateTool();
}
