

using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;

namespace Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Entities.Tools;

public class VacuumCleaner : ToolAbstract
{
    public override string Use()
    {
        return "Пылесосит.";
    }

    public override string Position()
    {
        return "Размещает в нужное положение пылесос.";
    }
}
