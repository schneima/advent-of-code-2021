using NUnit.Framework;

namespace AdventOfCode20221
{
    [TestFixture]
    internal class DayThreeTests
    {
        [Test]
        public void Get_position_after_sample_commands()
        {
            var sut = new SonarSweeper();
            var diagnosticReport = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            var reportAnalysis = sut.GetReportAnalysisBy(diagnosticReport);

            Assert.AreEqual(198, reportAnalysis.PowerConsumption);
        }
    }
}
