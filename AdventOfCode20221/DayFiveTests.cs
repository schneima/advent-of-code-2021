using System.Drawing;
using NUnit.Framework;
namespace AdventOfCode20221
{
    [TestFixture]
    internal class DayFiveTests
    {

        [Test]
        public void Get_number_of_points_overlap_at_least_two_lines_by_sample_data()
        {
            var sampleData = GetSampleData();
            VentsCalculator sut = new VentsCalculator(sampleData);
            sut.ProcessData();
            var calculatedNumberOfOverlappingLines = sut.GetNumberOfPointsWithOverlappingLines();
            int expectedNumberOfOverlappingLines = 5;
            Assert.AreEqual(expectedNumberOfOverlappingLines, calculatedNumberOfOverlappingLines);
        }

        [Test]
        public void Get_number_of_points_overlap_at_least_two_lines_by_task_data()
        {
            const string fileToRead = "input-day-five.txt";
            var taskData = TestHelper.GetLinesFromFile(fileToRead);
            var sut = new VentsCalculator(taskData);
            sut.ProcessData();
            var calculatedNumberOfOverlappingLines = sut.GetNumberOfPointsWithOverlappingLines();
            Console.WriteLine($"calculatedNumberOfOverlappingLines: {calculatedNumberOfOverlappingLines}");
        }

        [Test]
        public void Get_point_by_line_part()
        {
            var p = VentsCalculator.GetPointByLinePart("9,4");
            var expectedPoint = new Point(9, 4);
            Assert.AreEqual(expectedPoint, p);
        }

        [Test]
        public void Get_Orientation_by_line()
        {
            var lineData = "692,826 -> 692,915";
            var line = VentsCalculator.GetLineByRawData(lineData);
            Orientation expectedOritentation = Orientation.Vertical;
            Assert.AreEqual(expectedOritentation, line.LineOrientation);
        }

        private string[] GetSampleData()
        {
            var sampleData = new[]
            {
                "0,9 -> 5,9",
                "8,0 -> 0,8",
                "9,4 -> 3,4",
                "2,2 -> 2,1",
                "7,0 -> 7,4",
                "6,4 -> 2,0",
                "0,9 -> 2,9",
                "3,4 -> 1,4",
                "0,0 -> 8,8",
                "5,5 -> 8,2"
            };

            return sampleData;
        }
    }
}
