using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace WindsoulDataFile.App
{
    public static class Program
    {
        private const string TestFile = @"../../data/file.wdf";

        static void Main(string[] args)
        {
            using (var windsoul = new WindsoulFile(TestFile))
            {
                Console.WriteLine("File count: {0}", windsoul.Count);
                foreach (var fileEntry in windsoul.Files)
                {
                    Console.WriteLine("====== {0} ======", fileEntry.Id);
                    Console.WriteLine("Size : {0}", fileEntry.Size);
                    Console.WriteLine("Offset: {0}", fileEntry.Offset);
                    Console.WriteLine("Reserved: {0}", fileEntry.Reserved);
                }
            }

            Console.ReadLine();
        }
    }
}