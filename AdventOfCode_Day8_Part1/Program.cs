using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day8_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day8_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var lines = text.Split(new char[] { '\r','\n' }).ToList();
                    lines.RemoveAll(l => l == "");
                    var outputValues = new List<string>();

                    foreach (var line in lines)
                        outputValues.Add(line.Split('|')[1].TrimStart(' '));

                    var rawNumbers = new List<string>();

                    foreach (var value in outputValues)
                    {
                        var numbers = value.Split(' ');
                        foreach (var number in numbers)
                            rawNumbers.Add(number);
                    }

                    var one = 0;
                    var four = 0;
                    var seven = 0;
                    var eight = 0;

                    foreach (var number in rawNumbers)
                    {
                        if (number.Length == 2)
                            one++;
                        else if (number.Length == 4)
                            four++;
                        else if (number.Length == 3)
                            seven++;
                        else if (number.Length == 7)
                            eight++;
                    }
                    Console.WriteLine(one+four+seven+eight);
                    Console.WriteLine(startTime - DateTime.Now);
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
