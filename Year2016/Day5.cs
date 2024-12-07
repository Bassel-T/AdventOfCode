using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016
{
    public static class Day5
    {
        private static MD5 Hasher = MD5.Create();

        private static bool CheckBytesPart1(byte[] bytes)
        {
            return bytes[0] == 0 && bytes[1] == 0 && (bytes[2] < 16);
        }

        public static void Part1()
        {
            string input = "reyedfim";
            string password = "";
            int i = 0;
            for (int j = 0; j < 8; j++)
            {
                for (; !CheckBytesPart1(Hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input + i.ToString()))); i++) ;
                input = ((char)(Hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input + i.ToString()))[2])).ToString();
                password += input;
            }

            Console.WriteLine(password);

        }

        public static void Part2()
        {

        }
    }
}
