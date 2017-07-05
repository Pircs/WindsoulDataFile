using System;

namespace WindsoulDataFile.App
{
    class Program
    {
        private const string TestFile = @"C:\Users\gomes\Desktop\config.wdf";

        static void Main(string[] args)
        {
            using (var windsoul = new WindsoulFile(TestFile))
            {
                Console.WriteLine("Valid Windsoul file.");
            }

            Console.ReadLine();
        }
    }
}