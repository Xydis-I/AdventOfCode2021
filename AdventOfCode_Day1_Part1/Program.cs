using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day1_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day1_Input.txt";

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

                    foreach (var depth in depths)
                    {
                        position++;
                        if (lastDepth == null)
                            lastDepth = depth;

                        else
                            if (depth > lastDepth)
                            increases++;

                        lastDepth = depth;
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
