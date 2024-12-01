using Tools;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var dr = new Tools.DataReader();

var result  = await dr.read_data("https://adventofcode.com/2024/day/1/input");

Console.WriteLine(result);




string test_data = """
                   3   4
                   4   3
                   2   5
                   1   3
                   3   9
                   3   3
                   """;

string test_result = "11";