using System;
using System.Collections.Generic;

namespace _219.Contains_Duplicate_II
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Runtime: 156 ms, faster than 18.31% of C# online submissions for Contains Duplicate II.
                Memory Usage: 29.3 MB, less than 21.21% of C# online submissions for Contains Duplicate II.
             */

            var input = new int[] {1, 0, 1, 1};
            var k = 1;

            Console.WriteLine(ContainsNearbyDuplicate(input, k));
        }

        static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (k == 0)
                return false;

            var map = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map[nums[i]] = i;
                    continue;
                }

                var index = map[nums[i]];

                if (Math.Abs(i - index) <= k)
                    return true;

                map[nums[i]] = i;
            }

            return false;
        }
    }
}
