using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day2_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day2_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var lines = text.Split('\n');
                    //int[] depths = Array.ConvertAll(lines, l => int.Parse(l));

                    var depth = 0;
                    var position = 0;

                    foreach (var command in lines)
                    {
                        if (command.Contains("forward"))
                            position += int.Parse((command[command.Length-1]).ToString());

                        if (command.Contains("up"))
                            depth -= int.Parse((command[command.Length-1]).ToString());

                        if (command.Contains("down"))
                            depth += int.Parse((command[command.Length-1]).ToString());
                    }

                    Console.WriteLine("Depth: " + depth);
                    Console.WriteLine("Position: " + position);
                    Console.WriteLine(depth * position);
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
