using NUnit.Framework;

namespace AdventOfCode20221
{
    [TestFixture]
    internal class DayFourTests
    {
        [Test]
        public void Get_bingo_score_by_sample_data()
        {
            var sampleData = GetSampleData();

            var sut = new BingoSubsystem();
            sut.ProcessData(sampleData);

            sut.StartGame();
            var winnerBoard = sut.GetWinnerBoard();
            var sumOfUnmarkedNumbers = winnerBoard.GetSumOfUnmarkedNumbers();
            var lastTakenNumber = sut.GetLastTakenNumber();

            var calculatedScore = sumOfUnmarkedNumbers * lastTakenNumber;
            const int expectedScore = 4512;
            Assert.AreEqual(expectedScore, calculatedScore);
        }

        [Test]
        public void Get_bingo_score_by_task_data()
        {
            var taskData = GetBingoLines();

            var sut = new BingoSubsystem();
            sut.ProcessData(taskData);

            sut.StartGame();
            var winnerBoard = sut.GetWinnerBoard();
            var sumOfUnmarkedNumbers = winnerBoard.GetSumOfUnmarkedNumbers();
            var lastTakenNumber = sut.GetLastTakenNumber();

            var calculatedScore = sumOfUnmarkedNumbers * lastTakenNumber;
            Console.WriteLine($"sumOfUnmarkedNumbers: {sumOfUnmarkedNumbers}");
            Console.WriteLine($"lastTakenNumber: {lastTakenNumber}");
            Console.WriteLine($"calculatedScore: {calculatedScore}");
        }

        // returns sample data the same way we will get the task data
        string GetSampleData()
        {
            var sampleData = new[]
            {
                "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
                "",
                "22 13 17 11  0",
                " 8  2 23  4 24",
                "21  9 14 16  7",
                " 6 10  3 18  5",
                " 1 12 20 15 19",
                                "",
                " 3 15  0  2 22",
                " 9 18 13 17  5",
                "19  8  7 25 23",
                "20 11 10 24  4",
                "14 21 16 12  6",
                                "",
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7"
            };

            var entireGameData = string.Join(Environment.NewLine, sampleData);

            return entireGameData;
        }

        private string GetBingoLines()
        {
            var lines = File.ReadAllText("input-day-four.txt");
            return lines;
        }
    }
}
