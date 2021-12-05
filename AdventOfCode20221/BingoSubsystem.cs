namespace AdventOfCode20221
{
    internal class BingoSubsystem
    {
        private Random _random;
        private int[] _randomNumbers;

        public BingoSubsystem()
        {
            _random = new Random();
        }

        // random  number between 1 and 99
        internal int GetRandomBingoNumber()
        {
            return _random.Next(100);
        }

        internal BingoBoard[] GetBoards()
        {
            throw new NotImplementedException();
        }

        internal void GetWinnerBoard()
        {
            throw new NotImplementedException();
        }

        internal void StartGame()
        {
            throw new NotImplementedException();
        }

        internal int[] GetRandomBingoNumbers()
        {
            return RandomNumbers;
        }

        public int[] RandomNumbers
        {
            get { return _randomNumbers; }
        }

        internal void ProcessData(string[] dataLines)
        {
            foreach (var currentLine in dataLines)
            {
                //TBD seperate random numbers and boards by empty lines
            }
        }
    }
}