using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode_Day8_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            var fileLocation = @"C:\Users\ccb99\source\repos\AdventOfCode\AdventOfCode_Day08_Input.txt";

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    var lines = text.Split(new char[] { '\r', '\n' }).ToList();
                    lines.RemoveAll(l => l == "");

                    var outputSum = 0;

                    foreach (var line in lines)
                    {
                        var signalPattern = line.Split('|')[0].TrimEnd(' ').Split(' ');
                        var output = line.Split('|')[1].TrimStart(' ').Split(' ');

                        var signalDictionary = SignalDictionary(signalPattern);

                        StringBuilder sb = new StringBuilder();

                        foreach (var s in output)
                        {
                            var sBuffer = new HashSet<char>();
                            foreach (var c in s)
                                sBuffer.Add(c);
                            for (int i = 0; i < 10; i++)
                                if (sBuffer.SetEquals(signalDictionary[i.ToString()]))
                                    sb.Append(i);
                        }
                        outputSum += int.Parse(sb.ToString());
                        signalDictionary.Clear();
                    }
                    Console.WriteLine(outputSum);
                    Console.WriteLine(startTime - DateTime.Now);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static Dictionary<string, HashSet<char>> SignalDictionary(string[] signalStrings)
        {
            var signalBuffer = signalStrings.ToList();
            var zeroHash = new HashSet<char>();
            var oneHash = new HashSet<char>();
            var twoHash = new HashSet<char>();
            var threeHash = new HashSet<char>();
            var fourHash = new HashSet<char>();
            var fiveHash = new HashSet<char>();
            var sixHash = new HashSet<char>();
            var sevenHash = new HashSet<char>();
            var eightHash = new HashSet<char>();
            var nineHash = new HashSet<char>();
            for (var i = 0; i < signalBuffer.Count; i++)
            {
                switch (signalBuffer[i].Length)
                {
                    case 2:
                        foreach (var c in signalBuffer[i])
                            oneHash.Add(c);
                        break;
                        
                    case 3:
                        foreach (var c in signalBuffer[i])
                            sevenHash.Add(c);
                        break;

                    case 4:
                        foreach (var c in signalBuffer[i])
                            fourHash.Add(c);
                        break;

                    case 5:
                        if ((!oneHash.Any()))
                        {
                            var buffer = signalBuffer[i];
                            signalBuffer.RemoveAt(i);
                            signalBuffer.Add(buffer);
                            i--;
                        }
                        else if (oneHash.Any() && signalBuffer[i].Contains(oneHash.ToList()[0]) && signalBuffer[i].Contains(oneHash.ToList()[1]))
                            foreach (var c in signalBuffer[i])
                                threeHash.Add(c);
                        else
                        {
                            var fiveBuffer = new HashSet<char>();
                            foreach (var c in signalBuffer[i])
                                fiveBuffer.Add(c);

                            if ((!nineHash.Any()))
                            {
                                var buffer = signalBuffer[i];
                                signalBuffer.RemoveAt(i);
                                signalBuffer.Add(buffer);
                                i--;
                            }
                            else if (fiveBuffer.IsSubsetOf(nineHash))
                                foreach (var c in signalBuffer[i])
                                    fiveHash.Add(c);
                            else
                                foreach (var c in signalBuffer[i])
                                    twoHash.Add(c);
                        }
                        break;

                    case 6:
                        if ((!oneHash.Any()))
                        {
                            var buffer = signalBuffer[i];
                            signalBuffer.RemoveAt(i);
                            signalBuffer.Add(buffer);
                            i--;
                        }
                        else if (oneHash.Any() && !(signalBuffer[i].Contains(oneHash.ToList()[0]) && signalBuffer[i].Contains(oneHash.ToList()[1])))
                            foreach (var c in signalBuffer[i])
                                sixHash.Add(c);
                        else if ((!threeHash.Any()))
                        {
                            var buffer = signalBuffer[i];
                            signalBuffer.RemoveAt(i);
                            signalBuffer.Add(buffer);
                            i--;
                        }
                        else if (oneHash.Any() && signalBuffer[i].Contains(threeHash.ToList()[0]) && signalBuffer[i].Contains(threeHash.ToList()[1]) && signalBuffer[i].Contains(threeHash.ToList()[2]) && signalBuffer[i].Contains(threeHash.ToList()[3]) && signalBuffer[i].Contains(threeHash.ToList()[4]))
                            foreach (var c in signalBuffer[i])
                                nineHash.Add(c);
                        else
                            foreach (var c in signalBuffer[i])
                                zeroHash.Add(c);
                        break;
                        
                    case 7:
                        foreach (var c in signalBuffer[i])
                            eightHash.Add(c);
                        break;
                }
            }
            return new Dictionary<string, HashSet<char>>
            {
                {"0", zeroHash},
                {"1", oneHash},
                {"2", twoHash},
                {"3", threeHash},
                {"4", fourHash},
                {"5", fiveHash},
                {"6", sixHash},
                {"7", sevenHash},
                {"8", eightHash},
                {"9", nineHash}
            };
        }
    }
}
