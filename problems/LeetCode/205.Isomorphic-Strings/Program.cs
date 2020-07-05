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
               Runtime: 180 ms, faster than 5.18% of C# online submissions for Isomorphic Strings.
               Memory Usage: 24 MB, less than 16.54% of C# online submissions for Isomorphic Strings.
             */
        }

        public static bool AreIsomorphic(string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1) &&
                string.IsNullOrWhiteSpace(str2))
                return true;

            if (str1?.Length != str2.Length) return false;

            var mask1 = GetStringMask(str1);
            var mask2 = GetStringMask(str2);

            return mask1.SequenceEqual(mask2);
        }

        public static int[] GetStringMask(string str)
        {
            if(string.IsNullOrEmpty(str)) return new int[0];

            var count = 0;
            var map = new Dictionary<char,int>();
            var mask = new int[str.Length];
            
            for (int i = 0; i < str.Length; i++)
            {
                if (map.ContainsKey(str[i]) == false)
                {
                    map[str[i]] = ++count;
                }

                mask[i] = map[str[i]];
            }

            return mask;
        }
    }
}
