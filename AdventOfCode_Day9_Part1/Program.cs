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
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day09_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    
                    var lines = text.Split(new char[] { '\r', '\n' }).ToList();
                    lines.RemoveAll(l => l == "");

                    var map = new int[102, 102];

                    for (int i = 0; i < 102; i++)
                    {
                        map[0, i] = 9;
                        map[101, i] = 9;
                        map[i, 0] = 9;
                        map[i, 101] = 9;
                    }

                    for (int i = 0; i < 100; i++)
                        for (int j = 0; j < 100; j++)
                            map[i+1, j+1] = int.Parse(lines[i][j].ToString());

                    List<int> basinSizes = new List<int>();

                    var lowPoints = FindLowest(text);

                    foreach (var (i,j) in lowPoints)
                    {
                        Queue<(int, int)> currentQueue = new Queue<(int, int)>();

                        currentQueue.Enqueue((i, j));

                        List<(int, int)> proxList = new List<(int, int)> {(0, 0), (0, -1), (-1, 0), (1, 0), (0, 1)};

                        HashSet<(int, int)> pointHistory = new HashSet<(int, int)>();

                        while (currentQueue.Count > 0)
                        {
                            var (q1, q2) = currentQueue.Dequeue();

                            foreach (var (p1, p2) in proxList)
                            {
                                try
                                {
                                    if (map[q1 + p1, q2 + p2] != 9 && !pointHistory.Contains((q1 + p1, q2 + p2)))
                                        currentQueue.Enqueue((q1 + p1, q2 + p2));
                                }
                                catch (IndexOutOfRangeException) {}
                            }
                            pointHistory.Add((q1, q2));
                        }
                        basinSizes.Add(pointHistory.Count);
                    }

                    basinSizes.Sort();

                    Console.WriteLine((basinSizes[basinSizes.Count-1])*(basinSizes[basinSizes.Count-2])*(basinSizes[basinSizes.Count-3]));
                    Console.WriteLine(startTime - DateTime.Now);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static List<(int,int)> FindLowest(string text)
        {
            var lines = text.Split(new char[] { '\r', '\n' }).ToList();
            lines.RemoveAll(l => l == "");

            var map = new int[100, 100];

            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                    map[i, j] = int.Parse(lines[i][j].ToString());

            List<(int, int)> lowPoints = new List<(int, int)>();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (i == 0 && j == 0)
                        if (map[i, j + 1] > map[i, j] && map[i, j] < map[i + 1, j])
                            lowPoints.Add((i+1, j+1));

                    if (i == 99 && j == 0)
                        if (map[i, j + 1] > map[i, j] && map[i, j] < map[i - 1, j])
                            lowPoints.Add((i+1, j+1));

                    if (i == 0 && j == 99)
                        if (map[i, j - 1] > map[i, j] && map[i, j] < map[i + 1, j])
                            lowPoints.Add((i+1, j+1));

                    if (i == 99 && j == 99)
                        if (map[i, j - 1] > map[i, j] && map[i, j] < map[i - 1, j])
                            lowPoints.Add((i+1, j+1));

                    if (i == 0 && j != 0 && j != 99)
                        if (map[i, j - 1] > map[i, j] && map[i, j + 1] > map[i, j] && map[i, j] < map[i + 1, j])
                            lowPoints.Add((i+1, j+1));

                    if (j == 0 && i != 0 && i != 99)
                        if (map[i, j + 1] > map[i, j] && map[i, j] < map[i - 1, j] && map[i, j] < map[i + 1, j])
                            lowPoints.Add((i+1, j+1));

                    if (j == 99 && i != 0 && i != 99)
                        if (map[i, j - 1] > map[i, j] && map[i, j] < map[i - 1, j] && map[i, j] < map[i + 1, j])
                            lowPoints.Add((i+1, j+1));

                    if (i == 99 && j != 0 && j != 99)
                        if (map[i, j - 1] > map[i, j] && map[i, j + 1] > map[i, j] && map[i, j] < map[i - 1, j])
                            lowPoints.Add((i+1, j+1));

                    if (i != 0 && i != 99 && j != 0 && j != 99)
                        if (map[i, j - 1] > map[i, j] && map[i, j + 1] > map[i, j] && map[i, j] < map[i - 1, j] && map[i, j] < map[i + 1, j])
                            lowPoints.Add((i+1, j+1));
                }
            }

            return lowPoints;
        }
    }
}
