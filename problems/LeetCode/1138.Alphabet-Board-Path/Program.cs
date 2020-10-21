using System;

namespace _1138.Alphabet_Board_Path
{
    class Program
    {
        public static readonly string[] _board = new string[] {
            "abcde", 
            "fghij", 
            "klmno", 
            "pqrst", 
            "uvwxy", 
            "z"
        };

        static void Main(string[] args)
        {
            Console.WriteLine(3 - -3);
            Console.WriteLine(AlphabetBoardPath("leet"));
        }

        public static string AlphabetBoardPath(string target) {
            string path = string.Empty;
            int curCol = 0, curRow = 0;

            string GetHorizontalPath(int colsDiff)
            {
                if(colsDiff == 0) return string.Empty;
                var ch = colsDiff > 0 ? 'R' : 'L';

                return new string(ch, Math.Abs(colsDiff));
            }

            string GetVerticalPath(int rowsDiff)
            {
                if(rowsDiff == 0) return string.Empty;
                var ch = rowsDiff > 0 ? 'D' : 'U';

                return new string(ch, Math.Abs(rowsDiff));
            }

            string ProcessHorizontalDir(char direction, int rowsDiff, int colsDiff){
                if(direction == 'U')
                {
                    if(curCol - colsDiff < 0)
                    {
                        rowsDiff++;
                        colsDiff = 5 - colsDiff;
                    }

                    return GetVerticalPath(rowsDiff) + GetHorizontalPath(colsDiff);
                }
                else
                {

                }

                return string.Empty;
            };

            void ProcessVerticalDir(char direction, int rowsDiff, int colsDiff){
                
            };

            foreach(char targetCh in target)
            {
                var currentCh = _board[curRow][curCol];
                if(currentCh == targetCh)
                {
                    path += '!';
                    continue;
                }

                var diff = (int)targetCh - (int)currentCh;
                var shouldSearchForward = diff > 0;
                var rowsDiff = Math.Abs(diff / 5);
                var colsDiff = Math.Abs(diff % 5);

                if(!shouldSearchForward)
                {
                    if(curCol - colsDiff < 0)
                    {
                        rowsDiff++;
                        colsDiff = 5 - colsDiff;
                    }

                }
                else
                {
                    // target char is ahead relative to the current char
                }

                var directionV = diff > 0 ? 'D' : 'U';
                var directionH = diff > 0 ? 'R' : 'L';

                ProcessVerticalDir(directionV, rowsDiff, colsDiff);
                ProcessHorizontalDir(directionH, rowsDiff, colsDiff);
            }

            return path;
        }
    }
}
