
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;

namespace ProgramLogic.RobotMovements;

public class CrawlMovement : MovementAbstract
{
    public override string Move()
    {
        return "Ползет";
    }
}
