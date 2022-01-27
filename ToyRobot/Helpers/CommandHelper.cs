using System;
using ToyRobot.Interfaces;
using ToyRobot.Models;

namespace ToyRobot.Helpers
{
    public static class CommandHelper
    {
        public static string ParseCommand(IRobotGrid grid, string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return "Invalid command";
            }

            var commandStr = command.Trim();

            if (string.Equals(commandStr, "report", StringComparison.InvariantCultureIgnoreCase))
            {
                return grid.Report();
            }

            if (string.Equals(commandStr, "left", StringComparison.InvariantCultureIgnoreCase))
            {
                return grid.Left();
            }

            if (string.Equals(commandStr, "right", StringComparison.InvariantCultureIgnoreCase))
            {
                return grid.Right();
            }

            if (string.Equals(commandStr, "move", StringComparison.InvariantCultureIgnoreCase))
            {
                return grid.Move();
            }

            if (commandStr.StartsWith("place", StringComparison.InvariantCultureIgnoreCase))
            {
                var args = commandStr.Split(" ");

                if (args.Length == 2 && !string.IsNullOrWhiteSpace(args[1]))
                {
                    var placeArgs = args[1].Split(",");

                    if (placeArgs.Length > 1 && int.TryParse(placeArgs[0], out var x) && int.TryParse(placeArgs[1], out var y))
                    {
                        RobotEnum? direction = null;
                        if (placeArgs.Length == 3)
                        {
                            if (!string.IsNullOrWhiteSpace(placeArgs[2]) && Enum.TryParse(placeArgs[2].Trim(), out RobotEnum tempDirection))
                            {
                                direction = tempDirection;
                            }
                        }
                        return grid.Place(x, y, direction);
                    }
                }
            }

            return "Invalid command";
        }
    }
}
