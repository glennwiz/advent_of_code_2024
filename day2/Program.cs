// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var dr = new Tools.DataReader();

var result = await dr.read_data("https://adventofcode.com/2024/day/2/input");