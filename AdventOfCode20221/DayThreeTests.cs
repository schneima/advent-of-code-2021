using NUnit.Framework;

namespace AdventOfCode20221
{
    [TestFixture]
    internal class DayThreeTests
    {
        [Test]
        public void Get_power_consumption_after_test_data()
        {
            var sut = new SonarSweeper();

            // 12 reported numbers
            var diagnosticReport = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            var reportAnalysis = sut.GetReportAnalysisBy(diagnosticReport);

            var expectedGammaRate = 22;
            var expectedEpsilonRate = 9;
            var expectedPowerConsumption = 198;

            Assert.AreEqual(expectedGammaRate, reportAnalysis.GammaRate);
            Assert.AreEqual(expectedEpsilonRate, reportAnalysis.EpsilonRate);
            Assert.AreEqual(expectedPowerConsumption, reportAnalysis.PowerConsumption);
        }

        [Test]
        public void Get_power_consumption_using_task_data()
        {
            // 12 reported numbers
            var diagnosticReportByFile = GetDiagnosticLines(); ;
            var sut = new SonarSweeper();
            var reportAnalysis = sut.GetReportAnalysisBy(diagnosticReportByFile);

            Console.WriteLine($"Gamma rate: {reportAnalysis.GammaRate}");
            Console.WriteLine($"Epsilon rate: {reportAnalysis.EpsilonRate}");
            Console.WriteLine($"Power consumption: {reportAnalysis.PowerConsumption}");
        }

        private string[] GetDiagnosticLines()
        {
            var lines = File.ReadAllLines("input-day-three.txt");
            return lines;
        }
    }
}
