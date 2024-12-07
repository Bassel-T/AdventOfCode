using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day4
    {
        private static MD5 MD5Hasher = MD5.Create();

        private static bool CheckBytesPart1(byte[] bytes)
        {
            return bytes[0] == 0 && bytes[1] == 0 && (bytes[2] < 16);
        }

        private static bool CheckBytesPart2(byte[] bytes)
        {
            return bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0;
        }
        
        public static void Part1()
        {
            string input = "ckczppom";
            int i = 0;

            for (; !CheckBytesPart1(MD5Hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input + i.ToString()))); i++) ;

            Console.WriteLine(i);

        }

        public static void Part2()
        {
            string input = "ckczppom";
            int i = 0;

            for (; !CheckBytesPart2(MD5Hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input + i.ToString()))); i++) ;

            Console.WriteLine(i);
        }
    }
}
