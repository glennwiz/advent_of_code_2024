using System;

var dr = new Tools.DataReader();
var resultText = await dr.read_data("https://adventofcode.com/2024/day/6/input");


Console.WriteLine("testing22");
Console.WriteLine(resultText);

var testset = """....#..............#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...
""";


var locationOfGuard = findGuard(testset);

int findGuard(string testset) { }
