using System;
using System.Collections.Generic;

namespace _217.Contains_Duplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] {1,1,1,3,3,4,3,2,4,2};
            Console.WriteLine(ContainsDuplicate(input));
        }

        static bool ContainsDuplicate(int[] nums)
        {
            var set = new HashSet<int>(nums);

            return set.Count != nums.Length;
        }
    }
}
