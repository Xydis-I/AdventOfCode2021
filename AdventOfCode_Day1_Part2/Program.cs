using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day1_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day01_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var lines = text.Split('\n');
                    int[] depths = Array.ConvertAll(lines, l => int.Parse(l));

                    int? lastDepth = null;
                    var position = 0;
                    var increases = 0;

                    var windowA = 0;
                    var windowB = 1;
                    var windowC = 2;

                    while (windowC < depths.Length)
                    {
                        position++;
                        var currentDepth = depths[windowA] + depths[windowB] + depths[windowC];

                        if (lastDepth == null)
                            lastDepth = currentDepth;

                        else
                            if (currentDepth > lastDepth)
                            increases++;

                        lastDepth = currentDepth;
                        windowA++;
                        windowB++;
                        windowC++;
                    }
                    
                    Console.WriteLine(increases);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
