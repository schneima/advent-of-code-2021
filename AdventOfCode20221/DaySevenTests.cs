using NUnit.Framework;

namespace AdventOfCode20221
{
    [TestFixture]
    internal class DaySevenTests
    {
        [TestCase(2, 37)]
        public void Crab_position_optimization_by_sample_data(int expectedOptimalPosition, int expectedLeastFuelCosts)
        {
            var initialCrabPositions = GetSampleCrabPositions();

            var sut = new FuelOptimizer(initialCrabPositions);

            var optimizedAlignedMovement = sut.GetOptimizedAlignedMovement();

            Assert.AreEqual(expectedOptimalPosition, optimizedAlignedMovement.HorizontalPosition);
            Assert.AreEqual(expectedLeastFuelCosts, optimizedAlignedMovement.FuelCost);
        }

        [Test]
        public void Crab_position_optimization_by_task_data()
        {
            var initialCrabPositions = TestHelper.GetStringFromFile("input-day-seven.txt");
            var sut = new FuelOptimizer(initialCrabPositions);
            var optimizedAlignedMovement = sut.GetOptimizedAlignedMovement();

            Console.WriteLine($"Position: {optimizedAlignedMovement.HorizontalPosition}");
            Console.WriteLine($"FuelCost: {optimizedAlignedMovement.FuelCost}");

            // 342736 is too high
        }

        private static string GetSampleCrabPositions()
        {
            var sampleCrabPositions = "16,1,2,0,4,2,7,1,2,14";
            return sampleCrabPositions;
        }
    }
}
