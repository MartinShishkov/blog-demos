using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MininumSum
{
    class Program
    {
        static int MinSum(List<int> input, int k)
        {
            input.Sort();

            // we know that the last element is the largest
            // since we've sorted the input
            var largestNumIndex = input.Count - 1;
            int largestNum;

            void CompareToPrev()
            {
                var prevIndex = largestNumIndex - 1;
                var prev = input[prevIndex];
                if (largestNum < prev)
                {
                    largestNum = prev;
                    largestNumIndex = prevIndex;
                }
            }

            void CompareToNext()
            {
                var nextIndex = largestNumIndex + 1;
                var next = input[nextIndex];

                if (largestNum < next)
                {
                    largestNum = next;
                    largestNumIndex = nextIndex;
                }
            }

            for (int i = 0; i < k; i++)
            {
                largestNum = input[largestNumIndex];
                if (largestNumIndex == input.Count - 1)
                {
                    // largest num is the last element
                    // so compare it with the previous element
                    CompareToPrev();
                }
                else if (largestNumIndex == 0)
                {
                    // largest num is the first element
                    // so compare it to the next
                    CompareToNext();
                }
                else
                {
                    // largest num is somewhere in the middle
                    // compare it with the elements from both sides
                    CompareToNext();
                    CompareToPrev();
                }

                var valueToInsert = (int) Math.Ceiling((decimal)largestNum / 2);
                input[largestNumIndex] = valueToInsert;
            }

            return input.Sum();
        }

        static void Main(string[] args)
        {
            var input = new List<int> { 10, 20, 7 };
            var k = 4;

            Console.WriteLine(MinSum(input, k));
        }
    }
}
