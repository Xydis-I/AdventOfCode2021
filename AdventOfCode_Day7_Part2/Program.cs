using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day7_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day7_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var lines = text.Split(new char[] { ',' }).ToList();

                    var numbers = lines.Select(l => int.Parse(l));

                    var fuelTotals = new List<int>();

                    for (int i = 0; i <= 1000; i++) //numbers.Max() adds 10-11 seconds, further reading on Time Complexity needed I guess
                    {
                        var fuelUsage = new List<int>();

                        foreach (var number in numbers)
                        {
                            if (number > i)
                                for (int j = 1; j <= number - i; j++)
                                    fuelUsage.Add(j);

                            if (number < i)
                                for (int j = 1; j <= i - number; j++)
                                    fuelUsage.Add(j);
                        }
                        fuelTotals.Add(fuelUsage.Sum());
                    }
                    Console.WriteLine(fuelTotals.Min());
                    Console.WriteLine(startTime-DateTime.Now);
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
