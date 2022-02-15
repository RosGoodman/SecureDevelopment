
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Entities.Tools;
using ProgramLogic.RobotMovements;

namespace Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Factories;

public class CrawScrewdriverRobotFactory : RobotFactory
{
    public override MovementAbstract CreateMovement()
    {
        return new CrawlMovement();
    }

    public override ToolAbstract CreateTool()
    {
        return new Screwdriver();
    }
}
