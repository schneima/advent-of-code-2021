using NUnit.Framework;

namespace AdventOfCode20221
{
    [TestFixture]
    internal class DayTwoTests
    {
        [Test, Ignore("Not valid any more after second part adjustments.")]
        public void Get_position_after_sample_commands()
        {
            //the number of times a depth measurement increases 
            var sut = new SonarSweeper();
            var commands = new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
            var position = sut.GetPositionResultBy(commands);

            // After following these instructions, you would have a horizontal position of 15 and a depth of 10. (Multiplying these together produces 150.)

            Assert.AreEqual(10, position.Depth);
            Assert.AreEqual(15, position.HorizontalPosition);
            Assert.AreEqual(150, position.MultipliedValue);
        }

        [Test]
        public void Test_real_day_two_input()
        {
            string[] commandsFromFile = GetCommandsFromFile();
            var sut = new SonarSweeper();
            var position = sut.GetPositionResultBy(commandsFromFile);
            Console.WriteLine($"Depth: {position.Depth}");
            Console.WriteLine($"Horizontal position: {position.HorizontalPosition}");
            Console.WriteLine($"Multiplied result: {position.MultipliedValue}");
        }

        [Test]
        public void Get_position_including_aim()
        {
            // After following these new instructions, you would have a horizontal position of 15 and a depth of 60. (Multiplying these produces 900.)
            var sut = new SonarSweeper();
            var commands = new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
            var position = sut.GetPositionResultBy(commands);
            Assert.AreEqual(60, position.Depth);
            Assert.AreEqual(15, position.HorizontalPosition);
            Assert.AreEqual(900, position.MultipliedValue);
        }

        [Test]
        public void Get_position_including_aim_real_input()
        {
            string[] commandsFromFile = GetCommandsFromFile();
            var sut = new SonarSweeper();
            var position = sut.GetPositionResultBy(commandsFromFile);

            Console.WriteLine($"Depth: {position.Depth}");
            Console.WriteLine($"Horizontal position: {position.HorizontalPosition}");
            Console.WriteLine($"Multiplied result: {position.MultipliedValue}");
        }

        private string[] GetCommandsFromFile()
        {
            var lines = File.ReadAllLines("input-day-two.txt");
            return lines;
        }
    }
}
