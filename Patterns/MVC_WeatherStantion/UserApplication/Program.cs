using System;
using System.Data;

namespace UserApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine(rand.NextDouble());
            Console.WriteLine(rand.NextDouble() * 100);
        }
    }
}