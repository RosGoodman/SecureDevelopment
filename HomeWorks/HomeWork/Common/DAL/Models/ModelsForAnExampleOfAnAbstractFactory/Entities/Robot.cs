
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

    public void Move() => _movement.Move();

    public void Position() => _tool.Position();
    public void UseTool() => _tool.Use();
}
