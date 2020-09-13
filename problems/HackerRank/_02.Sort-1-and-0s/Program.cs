using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sort_1_and_0s
{
    class Program
    {
        // This problem really looks like a bubblesort to me
        // or at least the brute force solution. The only issue
        // is that we have to determine in which direction to sort
        // so that we actually get the least amount of swaps
        static int BubbleSort(List<int> arr)
        {
            var count = 0;
            var n = arr.Count;

            var comparer = GetComparer(arr);

            for (var i = 0; i < n - 1; i++)
            {
                for (var j = 0; j < n - i - 1; j++)
                {
                    if (comparer(arr[j], arr[j + 1])) // arr[j] < arr[j + 1]
                    { 
                        var temp = arr[j]; 
                        arr[j] = arr[j + 1]; 
                        arr[j + 1] = temp;
                        count++;
                    } 
                }
            }

            return count;
        }

        static Func<int, int, bool> GetComparer(List<int> arr)
        {
            var take = (int) Math.Ceiling((decimal) (arr.Count - 1) / 2);
            var leftPart = arr.GetRange(0, take);

            var startIndex = take;
            var rightPart = arr.GetRange(startIndex, arr.Count - take);

            if (leftPart.Sum() > rightPart.Sum())
                return (i, i1) => i < i1; // descending 111 -> 000

            return (i, i1) => i > i1; // ascending 000 -> 111
        }

        static void Main(string[] args)
        {
            var inputs = new List<List<int>>
            {
                /*new List<int>{ 0, 1 },
                new List<int> {1, 1, 1, 1, 0, 0, 0, 0},
                new List<int> {1, 1, 1, 1, 0, 0, 1, 0},
                new List<int> {0, 1, 1, 1, 1, 0, 0, 1, 0},*/
                new List<int> {0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1},
                /*new List<int> {0, 0, 0, 0, 0, 0, 1, 1},*/
            };

            foreach (var input in inputs)
            {
                var res = BubbleSort(input);
                Console.WriteLine(res);
            }
        }
    }
}
