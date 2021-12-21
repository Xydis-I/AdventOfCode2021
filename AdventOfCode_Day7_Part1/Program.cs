using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day7_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day07_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var lines = text.Split(new char[] { ',' }).ToList();

                    var numbers = lines.Select(l => int.Parse(l));
                        
                    var fuelTotals = new List<int>();
                    

                    for (int i = 0; i <= numbers.Max(); i++)
                    {
                        var fuelUsage = new List<int>();

                        foreach (var number in numbers)
                        {
                            if (number > i)
                                fuelUsage.Add(number - i);

                            if (number < i)
                                fuelUsage.Add(i - number);
                        }
                        fuelTotals.Add(fuelUsage.Sum());
                    }
                    Console.WriteLine(fuelTotals.Min());
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
