using System;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace PalindromeC
{
    class Program
    {
        public static void Main()
        {
            string[] str =
            {
                "12022021",
                "nitin",
                "1",
                "madam",
                "level",
                "NewYork",
            };
            BenchmarkRunner.Run<BenchT>();
        }
    }

    public static class Palindrome
    {
        public static bool Func0(string str)
        {
            if (str.Length <= 1)
                return true;
            else
            {
                for (int i = 0; i < str.Length; i++)
                    if (str[i] != str[str.Length - i - 1]) return false;
                return true;
            }
        }
        public static bool Func1(string str)
        {
            if (str.Length <= 1)
                return true;
            else
            {
                var newStr = new string(str.Reverse().ToArray());
                return newStr.Equals(str);
            }
        }

        public static bool Func2(string str)
        {
            string reverseStr = string.Empty; 
            if (str.Length <= 1)
                return true;
            else
            {
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    reverseStr += str[i].ToString();
                }
                if (reverseStr == str) return true;
                return false;
            }
        }
    }
    public class BenchT
    {
        private readonly string _str = string.Empty;
        [Benchmark]
        public bool Func0() => Palindrome.Func0(_str);

        [Benchmark]
        public bool Func1() => Palindrome.Func1(_str);

        [Benchmark]
        public bool Func2() => Palindrome.Func2(_str);

    }
}