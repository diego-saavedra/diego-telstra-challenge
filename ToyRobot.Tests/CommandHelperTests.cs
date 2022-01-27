using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ToyRobot.Helpers;
using ToyRobot.Interfaces;

namespace ToyRobot.Tests
{
    [TestClass]
    public class CommandHelperTests
    {
        [TestMethod]
        public void ParseCommandReturnInvalidWhenNull()
        {
            var grid = Substitute.For<IRobotGrid>();

            //Test
            var result = CommandHelper.ParseCommand(grid, string.Empty);

            //Assert
            Assert.AreEqual("Invalid command", result);
        }

        [TestMethod]
        public void ParseCommandReturnInvalidWhenUnknown()
        {
            var grid = Substitute.For<IRobotGrid>();

            //Test
            var result = CommandHelper.ParseCommand(grid, "Blah");

            //Assert
            Assert.AreEqual("Invalid command", result);
        }

        [TestMethod]
        public void ParseCommandCallsLeftWhenRequested()
        {
            var grid = Substitute.For<IRobotGrid>();

            //Test
            var result = CommandHelper.ParseCommand(grid, "Left");

            //Assert
            Assert.AreEqual(string.Empty, result);
            grid.Received(1).Left();
        }

        [TestMethod]
        public void ParseCommandCallsRightWhenRequested()
        {
            var grid = Substitute.For<IRobotGrid>();

            //Test
            var result = CommandHelper.ParseCommand(grid, "Right");

            //Assert
            Assert.AreEqual(string.Empty, result);
            grid.Received(1).Right();
        }

        [TestMethod]
        public void ParseCommandCallsMoveWhenRequested()
        {
            var grid = Substitute.For<IRobotGrid>();

            //Test
            var result = CommandHelper.ParseCommand(grid, "Move");

            //Assert
            Assert.AreEqual(string.Empty, result);
            grid.Received(1).Move();
        }

        [TestMethod]
        public void ParseCommandReturnInvalidWhenPlaceIsWrong()
        {
            var grid = Substitute.For<IRobotGrid>();

            //Test
            var result = CommandHelper.ParseCommand(grid, "Place u");

            //Assert
            Assert.AreEqual("Invalid command", result);
        }

        [TestMethod]
        public void ParseCommandCallsPlaceWith2Params()
        {
            var grid = Substitute.For<IRobotGrid>();

            //Test
            var result = CommandHelper.ParseCommand(grid, "Place 0,0");

            //Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void ParseCommandCallsPlaceWith3Params()
        {
            var grid = Substitute.For<IRobotGrid>();

            //Test
            var result = CommandHelper.ParseCommand(grid, "Place 0,0,North");

            //Assert
            Assert.AreEqual(string.Empty, result);
        }
    }
}