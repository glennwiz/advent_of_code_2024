// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

part1();
part2();

async void part2()
{
    var dr = new Tools.DataReader();
    var resultText = await dr.read_data("https://adventofcode.com/2024/day/3/input");

    GetSumPart2(resultText);
}

void GetSumPart2(string resultText)
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

        if (mulEnabled)
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

    Console.WriteLine(theSum);
}

async void part1()
{
    var dr = new Tools.DataReader();
    //var resultText = File.ReadAllText("C:\\dev\\advent_of_code_2024\\data\\day3_test");
    var resultText = await dr.read_data("https://adventofcode.com/2024/day/3/input");
    GetSumPart1(resultText);
}

void  GetSumPart1(string resultText)
{
    var matches = Regex.Matches(resultText, @"mul\((\d+),(\d+)\)");

    int theSum = 0;
    foreach (Match VARIABLE in matches)
    {
        var num1 = int.Parse(VARIABLE.Groups[1].Value);
        var num2 = int.Parse(VARIABLE.Groups[2].Value);

        int localSum = num1 * num2;

        theSum += localSum;

    }

    Console.WriteLine(theSum);
}