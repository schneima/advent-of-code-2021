namespace AdventOfCode20221
{
    internal class BingoSubsystem
    {
        private int[] _randomNumbers;
        private List<BingoBoard> _boards;
        private BingoBoard _winnerBoard;
        private int _currentNumberIndex;
        private int _lastTakenNumber;
        public bool StillLookingForWinner => _winnerBoard == null;

        internal BingoBoard GetWinnerBoard()
        {
            return _winnerBoard;
        }

        internal void StartRegularGame()
        {
            _currentNumberIndex = 0;
            bool regularGameVersion = true;
            while (StillLookingForWinner)
            {
                var currentNumber = TakeNextNumber();
                CheckBoardsForCurrentNumber(currentNumber, regularGameVersion);
            }
        }

        public int GetLastTakenNumber()
        {
            return _lastTakenNumber;
        }

        private void CheckBoardsForCurrentNumber(int currentNumber, bool regularGameVersion)
        {
            var currentBoards = _boards.ToArray();
            foreach (var bingoBoard in currentBoards)
            {
                bingoBoard.CheckNumber(currentNumber);
                if (bingoBoard.HasBingo)
                {
                    _winnerBoard = bingoBoard;
                    if (regularGameVersion)
                    {
                        return;
                    }

                    // in case trying to find last winning board we wait until one board is left to get bingo
                    if (_boards.Count > 1)
                    {
                        _boards.Remove(bingoBoard);
                    }
                }
            }
        }

        public BingoBoard GetLastWinningBoard()
        {
            _currentNumberIndex = 0;
            var regularGameVersion = false;
            while (_boards.Any(b => b.HasBingo == false))
            {
                var currentNumber = TakeNextNumber();
                CheckBoardsForCurrentNumber(currentNumber, regularGameVersion);
            }

            return _boards[0];
        }

        internal void ProcessData(string dataLines)
        {
            // split data to random numbers and boards by using double new line

            var separator = Environment.NewLine+Environment.NewLine;
            var gameData = dataLines.Split(separator);

            var randomNumbersString = gameData[0];

            _randomNumbers = GetRandomNumbersBy(randomNumbersString);

            _boards = new List<BingoBoard>();
            for (int i = 1; i < gameData.Length; i++)
            {
                BingoBoard board = GetBoardByString(gameData[i]);
                _boards.Add(board);
            }
        }

        private int[] GetRandomNumbersBy(string randomNumbersString)
        {
            var numberStrings = randomNumbersString.Split(",");
            var randomNumbers = new int[numberStrings.Length];

            for (int i = 0; i < numberStrings.Length; i++)
            {
                var currentNumberString = numberStrings[i];
                randomNumbers[i] = int.Parse(currentNumberString);
            }

            return randomNumbers;
        }

        private BingoBoard GetBoardByString(string boardData)
        {
            var lines = boardData.Split(Environment.NewLine);
            var numberOfLines = lines.Length;

            var bingoBoardNumbers = new List<BingoBoardNumber>();

            for (int row = 0; row < numberOfLines; row++)
            {
                var cleanedUpLine = lines[row].Replace("  ", " ");
                cleanedUpLine = cleanedUpLine.Trim();
                var currentStringNumbers = cleanedUpLine.Split(' ');

                for (int column = 0; column < currentStringNumbers.Length; column++)
                {
                    var currentStringNumber = currentStringNumbers[column];
                    
                    var numberValue = int.Parse(currentStringNumber);
                    var currentBingoBoardNumber = new BingoBoardNumber(row, column, numberValue);
                    bingoBoardNumbers.Add(currentBingoBoardNumber);
                }
            }

            var bingoBoard = new BingoBoard(bingoBoardNumbers);
            return bingoBoard;
        }

        public int TakeNextNumber()
        {
            _lastTakenNumber =  _randomNumbers[_currentNumberIndex];
            _currentNumberIndex++;
            return _lastTakenNumber;
        }
    }
}