using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day3_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day03_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var lines = text.Split('\n').ToList();

                    List<string> test = new List<string>()
                    {
                        "00100","11110",
                        "10110", "10111",
                        "10101", "01111",
                        "00111", "11100",
                        "10000", "11001",
                        "00010", "01010"
                    };

                    Console.WriteLine(OxygenGen(lines) * CO2Scrubber(lines));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static int OxygenGen(List<string> list)
        {
            var lines = list.ToList();

            int[] oxygen = new int[lines[1].Length];

            for (int i = 0; i < oxygen.Length; i++)
            {
                var columnList = lines.Select(x => int.Parse(x[i].ToString())).ToList();
                oxygen[i] = columnList.Where(x => x == 1).Count() >= columnList.Where(x => x == 0).Count() ? 1 : 0;
                lines.RemoveAll(x => x[i].ToString() != oxygen[i].ToString());
            }

            return Convert.ToInt32(lines[0],2);
        }

        public static int CO2Scrubber(List<string> list)
        {
            var lines = list.ToList();

            int[] coTwo = new int[lines[1].Length];
            int i = 0;
            // CO2
            while (lines.Count() > 1)
            {
                var columnList = lines.Select(x => int.Parse(x[i].ToString())).ToList();
                int ones = columnList.Where(x => x == 1).Count();
                int zeros = columnList.Where(x => x == 0).Count();

                if (ones < zeros)
                {
                    coTwo[i] = 1;
                }
                else
                {
                    coTwo[i] = 0;
                }
                lines.RemoveAll(x => x[i].ToString() != coTwo[i].ToString());
                i++;
            }
            
            return Convert.ToInt32(lines[0],2);
        }
    }
}
