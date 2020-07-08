using System;
using System.Collections.Generic;
using System.Linq;

namespace _205.Isomorphic_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AreIsomorphic("ab", "aa"));

            /*
               Runtime: 120 ms, faster than 21.31% of C# online submissions for Isomorphic Strings.
                Memory Usage: 23.4 MB, less than 66.39% of C# online submissions for Isomorphic Strings.
             */
        }

        public static bool AreIsomorphic(string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1) &&
                string.IsNullOrWhiteSpace(str2))
                return true;

            if (str1?.Length != str2.Length) return false;

            var map = new Dictionary<char, char>();
            var reverseMap = new Dictionary<char, char>();
            var length = str1.Length;
            for (int i = 0; i < length; i++)
            {
                var key = str1[i];
                var value = str2[i];

                if (map.ContainsKey(key) && value != map[key])
                    return false;

                if (reverseMap.ContainsKey(value) && key != reverseMap[value])
                    return false;

                map.TryAdd(key, value);
                reverseMap.TryAdd(value, key);
            }

            return true;
        }
    }
}
