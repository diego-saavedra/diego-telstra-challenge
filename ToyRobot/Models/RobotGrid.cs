using ToyRobot.Interfaces;

namespace ToyRobot.Models
{
    public class RobotGrid : IRobotGrid
    {
        private readonly int _gridHeight;
        private readonly int _gridWidth;
        private readonly string _locationError = "Invalid command, Location outside of grid";
        private readonly string _notPlacedError = "Invalid command, Robot has not been placed yet";
        private bool _robotPlaced = false;
        private int _x;
        private int _y;
        private RobotEnum? _currentDirection;

        public RobotGrid(int height, int width)
        {
            _gridHeight = height;
            _gridWidth = width;
        }

        public bool HasRobotBeenPlaced()
        {
            return _robotPlaced;
        }

        public string Place(int x, int y, RobotEnum? direction)
        {
            if (!_robotPlaced && direction == null)
            {
                return "Invalid command, First Place command has to include direction";
            }

            if (x >= _gridWidth || y >= _gridHeight || x < 0 || y < 0)
            {
                return _locationError;
            }

            _currentDirection = direction ?? _currentDirection;

            _x = x;
            _y = y;

            _robotPlaced = true;

            return null;
        }

        public string Right()
        {
            if (!_robotPlaced || _currentDirection == null)
            {
                return _notPlacedError;
            }

            var result = (int)_currentDirection;

            result++;

            if (result > 3)
            {
                _currentDirection = RobotEnum.North;
            }
            else
            {
                _currentDirection = (RobotEnum)result;
            }

            return null;
        }

        public string Left()
        {
            if (!_robotPlaced || _currentDirection == null)
            {
                return _notPlacedError;
            }

            var result = (int)_currentDirection;

            result--;

            if (result < 0)
            {
                _currentDirection = RobotEnum.West;
            }
            else
            {
                _currentDirection = (RobotEnum)result;
            }

            return null;
        }

        public string Move()
        {
            if (!_robotPlaced || _currentDirection == null)
            {
                return _notPlacedError;
            }

            switch (_currentDirection)
            {
                case RobotEnum.North:
                    if ((_y + 1) >= _gridHeight)
                    {
                        return _locationError;
                    }
                    _y++;
                    break;
                case RobotEnum.South:
                    if ((_y - 1) < 0)
                    {
                        return _locationError;
                    }
                    _y--;
                    break;
                case RobotEnum.East:
                    if ((_x + 1) >= _gridWidth)
                    {
                        return _locationError;
                    }
                    _x++;
                    break;
                case RobotEnum.West:
                    if ((_x - 1) < 0)
                    {
                        return _locationError;
                    }
                    _x--;
                    break;
            }

            return null;
        }

        public string Report()
        {
            if (!_robotPlaced || _currentDirection == null)
            {
                return _notPlacedError;
            }

            return $"Output: {_x}, {_y}, {_currentDirection}";
        }
    }
}
