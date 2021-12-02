using NUnit.Framework;

namespace AdventOfCode20221
{
    [TestFixture]
    internal class DayOneTests
    {
        [Test]
        public void Test_the_number_of_times_a_depth_measurement_increases()
        {
            //the number of times a depth measurement increases 
            var sut = new SonarSweeper();
            var measurements = new[] {199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var numberOfIncreases = sut.GetNumberOfIncreases(measurements);
            Assert.AreEqual(7, numberOfIncreases);
        }

        [Test]
        public void Test_real_day_one_input()
        {
            int[] numbers = GetNumbersFromFile();
            var sut = new SonarSweeper();
            var numberOfIncreases = sut.GetNumberOfIncreases(numbers);
            Console.WriteLine($"Number of increases: {numberOfIncreases}");
        }

        [Test]
        public void Test_number_of_sum_of_increases()
        {
            //the number of times a depth measurement increases 
            var sut = new SonarSweeper();
            var measurements = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var numberOfSumOfIncreases = sut.GetNumberOfSumOfIncreases(measurements);
            Assert.AreEqual(5, numberOfSumOfIncreases);
        }

        [Test]
        public void Test_real_day_one_input_part_two()
        {            
            int[] numbers = GetNumbersFromFile();
            var sut = new SonarSweeper();
            var numberOfSumOfIncreases = sut.GetNumberOfSumOfIncreases(numbers);
            Console.WriteLine($"Number of increases: {numberOfSumOfIncreases}");
            
        }


        private int[] GetNumbersFromFile()
        {
            var lines = File.ReadAllLines("input-day-one.txt");
            var numberList = new List<int>();
            foreach (var line in lines)
            {
                var currentNumber = int.Parse(line);
                numberList.Add(currentNumber);
            }

            return numberList.ToArray();
        }
    }
}
