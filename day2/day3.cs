using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace day2
{
    internal class day3
    {
        public async void part2()
        {
            Console.WriteLine("Hello, World!");
            var dr = new Tools.DataReader();
            //var resultText = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
            var resultText = await dr.read_data("https://adventofcode.com/2024/day/3/input");
           
            
            
            var result = GetSumPart2(resultText);        
            
            Console.WriteLine(result);
        }

        private int GetSumPart2(string resultText)
        {
            int theSum = 0;
            bool mulEnabled = true;
            int index = 0;

            while (index < resultText.Length)
            {
                if (resultText.Substring(index).StartsWith("do()"))
                {
                    mulEnabled = true;
                }


                if (resultText.Substring(index).StartsWith("don't()"))
                {
                    mulEnabled = false;
                }
                
                if(mulEnabled)
                {
                    var match = Regex.Match(resultText.Substring(index), @"^mul\((\d+),(\d+)\)");
                    
                    if (match.Success)
                    {
                        if (mulEnabled)
                        {
                            int num1 = int.Parse(match.Groups[1].Value);
                            int num2 = int.Parse(match.Groups[2].Value);
                            theSum += num1 * num2;
                        }                        
                    }                  
                }

                index++;
            }

            return theSum;
        }

        public async void part1()
        {
            Console.WriteLine("Hello, World!");
            var dr = new Tools.DataReader();
            //var resultText = File.ReadAllText("C:\\dev\\advent_of_code_2024\\data\\day3_test");
            var resultText = await dr.read_data("https://adventofcode.com/2024/day/3/input");
            var result = GetSumPart1(resultText);
            Console.WriteLine(result);
        }

        private int GetSumPart1(string resultText)
        {
           var matches = Regex.Matches(resultText, @"mul\((\d+),(\d+)\)");
           
           int theSum = 0;
           foreach (Match VARIABLE in matches)
           {
                Console.WriteLine(VARIABLE.Groups[1].Value);
                Console.WriteLine(VARIABLE.Groups[2].Value); 
                
                var num1 = int.Parse(VARIABLE.Groups[1].Value);
                var num2 = int.Parse(VARIABLE.Groups[2].Value);

                int localSum = num1 * num2;
                
                theSum += localSum;
               
           }

           Console.WriteLine(theSum);
           
            return 0;
        }
    }
}
