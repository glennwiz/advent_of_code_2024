using System;

var dr = new Tools.DataReader();
var resultText = await dr.read_data("https://adventofcode.com/2024/day/6/input");


//Console.WriteLine(resultText);

var testset = """
....#.....
.........#
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

var locationOfallReactorstuff = findReactorstuff(resultText);

Console.WriteLine("guard loc" + locationOfGuard);
foreach (var item in locationOfallReactorstuff)
{
    Console.WriteLine(item);
}

List<(int, int)> findReactorstuff(string resultText)
{
    var returndata = new List<(int, int)>();
    var lines = testset.Split("\n");
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        for (int j = 0; j < line.Length; j++)
        {
            if (line[j] == '#')
            {
                returndata.Add((i, j));
            }
        }
    }

    return returndata;
}

Console.WriteLine(locationOfGuard);

(int,int) findGuard(string testset) {
    var lines = testset.Split("\n");
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        for (int j = 0; j < line.Length; j++)
        {
            if (line[j] == '^')
            {
                return (i,j);
            }
        }
    }   

    return (0,0);
}
