using ToyRobot.Models;

namespace ToyRobot.Interfaces
{
    public interface IRobotGrid
    {
        string Place(int x, int y, RobotEnum? direction);
        string Right();
        string Left();
        string Move();
        string Report();
    }
}
