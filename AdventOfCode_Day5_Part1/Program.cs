using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day5_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day5_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var lines = text.Split(new char[]{' ','-','>','\r','\n',','}).ToList();
                    lines.RemoveAll(l => l == "");

                    var numbers = new List<int>();

                    foreach (var line in lines)
                        numbers.Add(int.Parse(line));

                    var points = new List<((int x1, int y1), (int x2, int y2))>();

                    for (int i = 0; i < numbers.Count-3; i+=4)
                        points.Add(((numbers[i],numbers[i+1]),(numbers[i+2],numbers[i+3])));

                    var filteredPoints = new List<((int x1, int y1), (int x2, int y2))>();

                    foreach (var point in points)
                        if ((point.Item1.x1 == point.Item2.x2) || (point.Item1.y1 == point.Item2.y2))
                            filteredPoints.Add(point);

                    int[,] grid = new int[1000, 1000];

                    foreach (var point in filteredPoints)
                    {
                        var (x1, y1, x2, y2) = (point.Item1.x1, point.Item1.y1, point.Item2.x2, point.Item2.y2);

                        if (x1 == x2)
                        {
                            if (y2 > y1)
                                for (int i = y1; i <= y2; i++)
                                    grid[x1, i]++;

                            if (y1 > y2)
                                for (int i = y2; i <= y1; i++)
                                    grid[x1, i]++;
                        }

                        if (y1 == y2)
                        {
                            if (x2 > x1)
                                for (int i = x1; i <= x2; i++)
                                    grid[i, y1]++;

                            if (x1 > x2)
                                for (int i = x2; i <= x1; i++)
                                    grid[i, y1]++;
                        }
                    }

                    var total = 0;

                    foreach (var point in grid)
                        if (point > 1)
                            total++;

                    Console.WriteLine(total);
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
