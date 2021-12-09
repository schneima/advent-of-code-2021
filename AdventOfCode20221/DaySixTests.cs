using System.Diagnostics;
using NUnit.Framework;

namespace AdventOfCode20221
{
    [TestFixture]
    internal class DaySixTests
    {
        [Test]
        public void Test_timer_for_new_laternfish()
        {
            var sut = new Laternfish();

            for (int i = 0; i < Laternfish.InitialNewTimerValue; i++)
            {
                sut.ProcessNextDay();
            }

            int expectedTimerValue = 0;
            Assert.AreEqual(expectedTimerValue, sut.CurrentTimerValue);

            for (int i = 0; i < Laternfish.DefaultNewTimerValue + 1; i++)
            {
                sut.ProcessNextDay();
            }
            Assert.AreEqual(expectedTimerValue, sut.CurrentTimerValue);
        }

        [TestCase(18, 26)]
        [TestCase(80, 5934)]
        [Ignore("TBD: a more performant solution required"), TestCase(256, 26984457539)]
        public void Laternfish_swarm_test(int daysTest, Int64 expectedNumberOfFishes)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var initialLaternfishTimerSequence = GetInitialSampleLaternfishTimerSequence();
            var initialLaternfishes = GetLaternfishesByInitSequence(initialLaternfishTimerSequence);
            var sut = new LaternfishSwarm(initialLaternfishes);

            Console.WriteLine($"Initial state: {initialLaternfishTimerSequence}");
            for (int i = 0; i < daysTest; i++)
            {
                sut.ProcessNextDay();
                // sut.LogCurrentState();
            }

            var calculatedNumberOfFishes = sut.GetCurrentNumberOfFishes();
            sw.Stop();
            var testDuration = sw.Elapsed;
            Console.WriteLine($"{testDuration:G}");

            Assert.AreEqual(expectedNumberOfFishes, calculatedNumberOfFishes);
        }

        [Test]
        public void Laternfish_swarm_population_task_Part_one()
        {
            var initialLaternfishTimerSequence = TestHelper.GetStringFromFile("input-day-six.txt");
            var initialLaternfishes = GetLaternfishesByInitSequence(initialLaternfishTimerSequence);
            var sut = new LaternfishSwarm(initialLaternfishes);

            Console.WriteLine($"Initial state: {initialLaternfishTimerSequence}");
            int daysTest = 80;
            for (int i = 0; i < daysTest; i++)
            {
                sut.ProcessNextDay();
                // sut.LogCurrentState();
            }

            var calculatedNumberOfFishes = sut.GetCurrentNumberOfFishes();
            Console.WriteLine($"calculatedNumberOfFishes: {calculatedNumberOfFishes}");
        }

        private List<Laternfish> GetLaternfishesByInitSequence(string initialLaternfishTimerSequence)
        {
            var timerValues = initialLaternfishTimerSequence.Split(',');
            var fishes = new List<Laternfish>();
            foreach (var timerValue in timerValues)
            {
                var fish = new Laternfish(timerValue);
                fishes.Add(fish);
            }

            return fishes;
        }

        private static string GetInitialSampleLaternfishTimerSequence()
        {
            var initialLaternfishSequence = "3,4,3,1,2";
            return initialLaternfishSequence;
        }
    }
}
