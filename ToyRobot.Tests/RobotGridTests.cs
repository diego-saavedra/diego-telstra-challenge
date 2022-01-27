using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Models;

namespace ToyRobot.Tests
{
    [TestClass]
    public class RobotGridTests
    {
        //Verify right dimensions
        [TestMethod]
        public void GridBuildsCorrectly()
        {
            var grid = new RobotGrid(6, 6);
            grid.Place(5, 5, RobotEnum.North);

            //Test
            var firstResult = grid.Move();

            Assert.AreEqual("Invalid command, Location outside of grid", firstResult);

            grid.Right();
            var secondResult = grid.Move();

            Assert.AreEqual("Invalid command, Location outside of grid", secondResult);
        }

        [TestMethod]
        public void GridBlocksMovingOutsideGrid()
        {
            var grid = new RobotGrid(6, 6);
            grid.Place(5, 5, RobotEnum.North);

            //Test
            var result = grid.Move();

            Assert.AreEqual("Invalid command, Location outside of grid", result);
        }

        [TestMethod]
        public void GridCorrectlyDetectsPlacedRobot()
        {
            var grid = new RobotGrid(6, 6);
            grid.Place(5, 5, RobotEnum.North);

            //Test
            var result = grid.HasRobotBeenPlaced();

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GridBlocksOtherCommandsBeforePlace()
        {
            var grid = new RobotGrid(5, 5);

            //Test
            var result = grid.Move();

            Assert.AreEqual("Invalid command, Robot has not been placed yet", result);
        }

        [TestMethod]
        public void GridBlocksFirstPlaceWithoutDirection()
        {
            var grid = new RobotGrid(5, 5);

            //Test
            var result = grid.Place(0, 0, null);

            Assert.AreEqual("Invalid command, First Place command has to include direction", result);
        }

        [TestMethod]
        public void GridReportsCorrectly()
        {
            var grid = new RobotGrid(5, 5);
            grid.Place(0, 0, RobotEnum.North);

            //Test
            var result = grid.Report();

            Assert.AreEqual("Output: 0, 0, North", result);
        }

        [TestMethod]
        public void GridBlocksReportIfNotPlaced()
        {
            var grid = new RobotGrid(5, 5);

            //Test
            var result = grid.Report();

            Assert.AreEqual("Invalid command, Robot has not been placed yet", result);
        }

    }
}
