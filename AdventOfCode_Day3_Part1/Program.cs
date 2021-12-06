using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day3_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day3_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var lines = text.Split('\n');
                    string[] test =
                    {
                        "00100","11110",
                        "10110", "10111",
                        "10101", "01111",
                        "00111", "11100",
                        "10000", "11001",
                        "00010", "01010"
                    };

                    var gammaString = "";
                    var epsilonString = "";

                    int[,] binCount = new int[2, 12];

                    for (int i = 0; i < 12; i++)
                    {
                        foreach (var line in lines)
                        {
                            if (line[i] == '0')
                                binCount[0, i]++;

                            if (line[i] == '1')
                                binCount[1, i]++;
                        }
                    }

                    for (int i = 0; i < 12; i++)
                    {
                        if (binCount[0, i] > binCount[1, i])
                            gammaString += "0";

                        else
                            gammaString += "1";
                    }

                    for (int i = 0; i < 12; i++)
                    {
                        if (binCount[0, i] < binCount[1, i])
                            epsilonString += "0";

                        else
                            epsilonString += "1";
                    }

                    Console.WriteLine(gammaString);
                    Console.WriteLine(epsilonString);

                    Console.WriteLine("Power Consumption: {0}",Convert.ToInt32(gammaString,2)*Convert.ToInt32(epsilonString,2));
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
