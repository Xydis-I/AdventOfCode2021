using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day6_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day6_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var fishText = text.Split(',');

                    List<int> listOfFish = new List<int>();

                    foreach (var fish in fishText)
                        listOfFish.Add(int.Parse(fish));

                    //int[] water = Array.ConvertAll(fishText, l => int.Parse(l));

                    for (int i = 0; i < 80; i++)
                    {
                        var fishCounter = 0;

                        while (fishCounter < listOfFish.Count)
                        {
                            if (listOfFish[fishCounter] == 0)
                            {
                                listOfFish[fishCounter] = 6;
                                listOfFish.Add(9);
                                fishCounter++;
                            }
                            else
                            {
                                listOfFish[fishCounter] -= 1;
                                fishCounter++;
                            }
                        }
                    }

                    Console.WriteLine(listOfFish.Count);
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
