
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Abstracts;

namespace Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Entities;

public class Robot
{
    private MovementAbstract _movement;
    private ToolAbstract _tool;
    private string _name;

    public string Name { get; set; }

    public Robot(RobotFactory factory)
    {
        _movement = factory.CreateMovement();
        _tool = factory.CreateTool();
    }

    public string Move() => _movement.Move();

    public string Position() => _tool.Position();
    public string UseTool() => _tool.Use();
}
