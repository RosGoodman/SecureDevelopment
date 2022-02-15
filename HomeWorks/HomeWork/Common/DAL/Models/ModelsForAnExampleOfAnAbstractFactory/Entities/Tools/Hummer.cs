
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;

namespace Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Entities.Tools;

public class Hummer : ToolAbstract
{
    public override string Use()
    {
        return "Бьет молотом.";
    }

    public override string Position()
    {
        return "Размещает в нужное положение молот.";
    }
}
