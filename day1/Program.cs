﻿using System.Diagnostics;
using Tools;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string test_data = """
                   3   4
                   4   3
                   2   5
                   1   3
                   3   9
                   3   3
                   """;

string test_result = "11";
var dr = new Tools.DataReader();

var result = await dr.read_data("https://adventofcode.com/2024/day/1/input");

day1_part1();
day1_part2();

void day1_part1()
{ 
    var list1 = new List<int>();
    var list2 = new List<int>();

    var lines = result.Split("\n");
    foreach (var line in lines)
    {
        if(string.IsNullOrEmpty(line))
            continue;
    
        var numbers = line.Split("   ");
        list1.Add(int.Parse(numbers[0]));
        list2.Add(int.Parse(numbers[1]));
    }

    var ordered1 = list1.OrderBy(x => x).ToList();
    var ordered2 = list2.OrderBy(x => x).ToList();
    var sum = 0;
    for (int i = 0; i < ordered1.Count; i++)
    {
        var num1 = ordered1[i];
        var num2 = ordered2[i];
    
        if (num1 == num2)
            continue;
    
        if(num1 > num2)
        {
            sum += num1 - num2;
        }
        else
        {
            sum += num2 - num1;
        }
    }

    Console.WriteLine(sum);
}

void day1_part2()
{ 
    var list1 = new List<int>();
    var list2 = new List<int>();

    var lines = result.Split("\n");
    foreach (var line in lines)
    {
        if(string.IsNullOrEmpty(line))
            continue;
    
        var numbers = line.Split("   ");
        list1.Add(int.Parse(numbers[0]));
        list2.Add(int.Parse(numbers[1]));
    }
    var total = 0;
    for (int i = 0; i < list1.Count; i++)
    {
        var num1 = list1[i];
        int c = list2.Count(n => num1 == n);
        
        if(c == 0)
            continue;

        var r = num1 * c;

        total += r;
    }
    
    Console.WriteLine(total);
}

