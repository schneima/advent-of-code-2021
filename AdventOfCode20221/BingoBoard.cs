using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AdventOfCode20221
{
    internal class BingoBoard
    {
        private readonly List<BingoBoardNumber> _numbers;
        private bool _hasBingo;
        private readonly int _boardDimension;

        public BingoBoard(List<BingoBoardNumber> numbers)
        {
            _numbers = numbers;
            _hasBingo = false;

            var maxIndex = numbers.Max(n => n.Column);
            _boardDimension = maxIndex + 1;
        }

        public bool HasBingo => _hasBingo;

        public void CheckNumber(int currentNumberToCheck)
        {
            // mark all equal numbers which ar not marked yet
            foreach (var bingoBoardNumber in _numbers.Where(n => n.State.Equals(NumberState.Unmarked)))
            {
                if (bingoBoardNumber.NumberValue.Equals(currentNumberToCheck))
                {
                    bingoBoardNumber.SetNumberMarked();
                }
            }

            // check if there is a full row or column of marked numbers
            for (var i = 0; i < _boardDimension; i++)
            {
                // rows check
                var indexToCheck = i;
                var numbersInCurrentRow = _numbers.Where(n => n.Row == indexToCheck);
                var numbersInCurrentColumn = _numbers.Where(n => n.Column == indexToCheck);
                var foundFullRow = numbersInCurrentRow.All(n => n.State == NumberState.Marked); 
                var foundFullColumn = numbersInCurrentColumn.All(n => n.State == NumberState.Marked); 

                if (foundFullColumn || foundFullRow)
                {
                    _hasBingo = true;
                    return;
                }
            }
        }

        public int GetSumOfUnmarkedNumbers()
        {
            var unmarkedNumbers = _numbers.Where(n => n.State == NumberState.Unmarked);
            return unmarkedNumbers.Sum(bingoBoardNumber => bingoBoardNumber.NumberValue);
        }
    }
}