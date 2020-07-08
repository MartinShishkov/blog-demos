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
               Runtime: 112 ms, faster than 25.00% of C# online submissions for Isomorphic Strings.
               Memory Usage: 24.8 MB, less than 15.97% of C# online submissions for Isomorphic Strings.
             */
        }

        public static bool AreIsomorphic(string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1) &&
                string.IsNullOrWhiteSpace(str2))
                return true;

            if (str1?.Length != str2.Length) return false;

            var map = new Dictionary<char, char>();
            var length = str1.Length;
            for (int i = 0; i < length; i++)
            {
                var key = str1[i];
                var value = str2[i];

                if (map.ContainsKey(key))
                {
                    if (value != map[key]) return false;

                    continue;
                }

                if (map.Values.Any(v => v == value)) return false;

                map.Add(key, value);
            }

            return true;
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
