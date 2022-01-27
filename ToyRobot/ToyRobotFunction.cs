using Microsoft.Extensions.Options;
using System;
using ToyRobot.Helpers;
using ToyRobot.Models;

namespace ToyRobot
{
    public class ToyRobotFunction
    {
        private readonly AppSettings _settings;

        public ToyRobotFunction(
            IOptions<AppSettings> options)
        {
            _settings = options.Value;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the Toy Robot Simulator");
            var grid = new RobotGrid(_settings.Height, _settings.Width);
            Console.WriteLine($"We are using a {_settings.Height}x{_settings.Width} grid");
            Console.WriteLine("Please use the PLACE command to start or EXIT");
            var action = Console.ReadLine();

            while (!string.Equals(action, "exit", StringComparison.InvariantCultureIgnoreCase))
            {
                var message = CommandHelper.ParseCommand(grid, action);
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Console.WriteLine(message);
                }
                action = Console.ReadLine();
            }
        }


    }
}
