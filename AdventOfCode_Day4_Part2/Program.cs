using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_Day4_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day04_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var (cards, numbers) = Bingo(text);

                    var (x, y, z, number) = BingoSolution(cards, numbers);

                    int? total = 0;

                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 5; j++)
                            if (cards[x, i, j] != null)
                                total += cards[x, i, j];

                    Console.WriteLine(total * number);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static (int?[,,], List<int>) Bingo(string text)
        {
            var lines = text.Split(new char[] { '\r', '\n' }).ToList();
            var temp = lines[0].Split(',');
            var numbers = (Array.ConvertAll(temp, s => int.Parse(s))).ToList();

            lines.RemoveAll(l => l == "");
            lines.RemoveAt(0);

            var tCardLines = new List<string>();

            foreach (var line in lines)
                tCardLines.Add(line.Replace("\r", ""));

            int?[,,] cards = new int?[100, 5, 5];

            var sCardLines = new List<List<string>>();

            foreach (var line in tCardLines)
                sCardLines.Add((line.Split(' ')).ToList());

            for (int i = 0; i < sCardLines.Count; i++)
                for (int j = 0; j < sCardLines[i].Count; j++)
                    if (sCardLines[i][j] == "")
                    {
                        sCardLines[i].RemoveAt(j);
                        j--;
                    }

            var buffer = 0;
            for (int i = 0; i < sCardLines.Count / 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    for (int k = 0; k < 5; k++)
                        cards[i, j, k] = int.Parse(sCardLines[j + buffer][k]);

                buffer += 5;
            }

            return (cards, numbers);
        }

        public static (int x, int y, int z, int number) BingoSolution(int?[,,] cards, List<int> numbers)
        {
            List<(int, int, int, int)> winOrder = new List<(int, int, int, int)>();

            List<int> cardTracker = new List<int>();

            foreach (var number in numbers)
            {
                for (int i = 0; i < 100; i++)
                    for (int j = 0; j < 5; j++)
                        for (int k = 0; k < 5; k++)
                            if (cards[i, j, k] == number)
                                cards[i, j, k] = null;

                for (int i = 0; i < 100; i++)
                {
                    var jCount = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (cards[i, j, k] == null)
                                jCount++;

                            if ((jCount == 5) && !cardTracker.Contains(i))
                            {
                                cardTracker.Add(i);
                                winOrder.Add((i, j, k, number));
                            }
                        }

                        jCount = 0;
                    }

                    var kCount = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (cards[i, j, k] == null)
                                kCount++;

                            if ((kCount == 5) && !cardTracker.Contains(i))
                            {
                                cardTracker.Add(i);
                                winOrder.Add((i, j, k, number));
                            }
                        }

                        kCount = 0;
                    }
                }

                if (cardTracker.Count >= 100)
                    break;
            }

            return  winOrder[winOrder.Count-1];
        }
    }
}
