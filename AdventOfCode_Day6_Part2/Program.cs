using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day6_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day6_Input.txt";
            
            try
            {
                using (var sr = File.OpenText(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var fishText = text.Split(',');

                    long[] listOfFish = {0, 0, 0, 0, 0, 0, 0, 0, 0};
                    long[] fishShuffle = new long[9];

                    foreach (var fish in fishText)
                    {
                        switch (fish)
                        {
                            case "1":
                                listOfFish[1]++;
                                break;
                            case "2":
                                listOfFish[2]++;
                                break;
                            case "3":
                                listOfFish[3]++;
                                break;
                            case "4":
                                listOfFish[4]++;
                                break;
                            case "5":
                                listOfFish[5]++;
                                break;
                        }
                    }

                    for (int i = 0; i < 256; i++)
                    {
                        long buffer = 0;
                        if (listOfFish[0] > 0)
                            buffer = listOfFish[0];

                        for (int f = 0; f < 8; f++)
                            fishShuffle[f] = listOfFish[f + 1];

                        fishShuffle[6] += buffer;
                        fishShuffle[8] += buffer;

                        listOfFish = fishShuffle.ToArray();

                        Array.Clear(fishShuffle, 0, 9);
                    }

                    Console.WriteLine(listOfFish.Sum());
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
