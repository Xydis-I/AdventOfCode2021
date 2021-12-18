using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day9_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day9_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    
                    var lines = text.Split(new char[] { '\r', '\n' }).ToList();
                    lines.RemoveAll(l => l == "");

                    var map = new int[100, 100];

                    for (int i = 0; i < 100; i++)
                        for (int j = 0; j < 100; j++)
                            map[i, j] = int.Parse(lines[i][j].ToString());

                    var riskLevel = 0;

                    for (int i = 0; i < 100; i++)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            if (i == 0 && j == 0)
                                if (map[i,j+1] > map[i,j] && map[i,j] < map[i+1,j])
                                    riskLevel += (1 + map[i, j]);

                            if (i == 99 && j == 0)
                                if (map[i, j + 1] > map[i, j] && map[i, j] < map[i - 1, j])
                                    riskLevel += (1 + map[i, j]);

                            if (i == 0 && j == 99)
                                if (map[i, j - 1] > map[i, j] && map[i, j] < map[i + 1, j])
                                    riskLevel += (1 + map[i, j]);

                            if (i == 99 && j == 99)
                                if (map[i, j - 1] > map[i, j] && map[i, j] < map[i - 1, j])
                                    riskLevel += (1 + map[i, j]);

                            if (i == 0 && j != 0 && j != 99)
                                if (map[i, j - 1] > map[i, j] && map[i, j + 1] > map[i, j] && map[i, j] < map[i + 1, j])
                                    riskLevel += (1 + map[i, j]);

                            if (j == 0 && i != 0 && i != 99)
                                if (map[i, j + 1] > map[i, j] && map[i, j] < map[i - 1, j] && map[i, j] < map[i + 1, j])
                                    riskLevel += (1 + map[i, j]);

                            if (j == 99 && i != 0 && i != 99)
                                if (map[i, j - 1] > map[i, j] && map[i, j] < map[i - 1, j] && map[i, j] < map[i + 1, j])
                                    riskLevel += (1 + map[i, j]);

                            if (i == 99 && j != 0 && j != 99)
                                if (map[i, j - 1] > map[i, j] && map[i, j + 1] > map[i, j] && map[i, j] < map[i - 1, j])
                                    riskLevel += (1 + map[i, j]);

                            if (i != 0 && i != 99 && j != 0 && j != 99)
                                if (map[i, j - 1] > map[i, j] && map[i, j + 1] > map[i, j] && map[i, j] < map[i - 1, j] && map[i, j] < map[i + 1, j])
                                    riskLevel += (1 + map[i, j]);
                        }
                    }

                    Console.WriteLine(riskLevel);
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
