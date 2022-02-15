
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;

namespace Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Entities.Tools;

public class Screwdriver : ToolAbstract
{
    public override string Use()
    {
        return "Вращает отверткой.";
    }

    public override string Position()
    {
        return "Размещает в нужное положение отвертку.";
    }
}
