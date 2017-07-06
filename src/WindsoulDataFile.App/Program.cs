using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace WindsoulDataFile.App
{
    class Program
    {
        private const string TestFile = @"../../data/file.wdf";

        static void Main(string[] args)
        {
            using (var windsoul = new WindsoulFile(TestFile))
            {
                Console.WriteLine("Valid Windsoul file.");

                Console.WriteLine("File count: {0}", windsoul.Count);
                Console.WriteLine("Files :");
                foreach (var fileEntry in windsoul.Files)
                {
                    Console.WriteLine("- {0}", fileEntry.Id);
                }
            }

            Console.ReadLine();
        }
    }
}