using System;

var dr = new Tools.DataReader();
var resultText = await dr.read_data("https://adventofcode.com/2024/day/4/input");

Console.WriteLine("Hello, World!");

var input = """
        MMMSXXMASM
        MSAMXMSMSA
        AMXSXMAAMM
        MSAMASMSMX
        XMASAMXAMM
        XXAMMXXAMA
        SMSMSASXSS
        SAXAMASAAA
        MAMMMXMMMM
        MXMXAXMASX
        """;

part1();
part2();

void part1()
{

    var TheConvayGrid = CreateGrid(resultText);
    var count = CountXMAS(TheConvayGrid);
    Console.WriteLine($"\nFinal Count: 'XMAS' found {count} times.");

    char[,] CreateGrid(string data)
    {
        var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var rows = lines.Length;
        var cols = lines[0].Trim().Length;

        var grid = new char[rows, cols];
        for (var i = 0; i < rows; i++)
        {
            var line = lines[i].Trim();
            for (var j = 0; j < cols; j++)
                grid[i, j] = line[j];
        }
        return grid;
    }

    int CountXMAS(char[,] grid)
    {
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);
        var target = "XMAS";
        var count = 0;

        int[] dirX = { 0, 1, 1, 1, 0, -1, -1, -1 };
        int[] dirY = { 1, 1, 0, -1, -1, -1, 0, 1 };

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                // xxx
                // xNx
                // xxx
                for (var delta = 0; delta < 8; delta++)
                {
                    if (CheckDirection(grid, i, j, dirX[delta], dirY[delta], target))
                    {
                        count++;
                        Console.WriteLine($"Match #{count}: 'XMAS' idx ({i},{j}) vector ({dirX[delta]},{dirY[delta]})");
                    }
                }
            }
        }
        return count;
    }

    bool CheckDirection(char[,] grid, int x, int y, int dirX, int dirY, string target)
    {
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);

        for (var letterIndex = 0; letterIndex < target.Length; letterIndex++)
        {
            var locX = x + letterIndex * dirX;
            var locY = y + letterIndex * dirY;

            // bounds and letter checks
            if (locX < 0 || locX >= rows || locY < 0 || locY >= cols || grid[locX, locY] != target[letterIndex])
            {
                return false;
            }
        }
        return true;
    }

}



void part2()
{

    var TheConvayGrid = CreateGrid(resultText);

    DisplayGrid(TheConvayGrid);
    //       M M
    // Count  A patterns
    //       S S
    var AIndexes = GetAindexes(TheConvayGrid);

    var count = 0;

    //lets loop the A's and check the 4 corners

    //legal states
    // if -1,-1 == M then +1,+1 == S
    // if -1,+1 == M then +1,-1 == S
    // if +1,-1 == M then -1,+1 == S
    // if +1,+1 == M then -1,-1 == S

    //if all 4 corners are legal then we have a count

    //        (-1,-1) (0,-1) (1,-1)
    //        (-1,0)  (0,0)  (1,0)
    //        (-1,1)  (0,1)  (1,1)

    for (var i = 0; i < AIndexes.Count; i++)
    {
        if (TheConvayGrid[AIndexes[i].Item1 - 1, AIndexes[i].Item2 - 1] == 'M' && TheConvayGrid[AIndexes[i].Item1 + 1, AIndexes[i].Item2 + 1] == 'S')
        {
            if (TheConvayGrid[AIndexes[i].Item1 - 1, AIndexes[i].Item2 + 1] == 'M' && TheConvayGrid[AIndexes[i].Item1 + 1, AIndexes[i].Item2 - 1] == 'S')
            {
                count++;
                continue;
            }
        }

        if (TheConvayGrid[AIndexes[i].Item1 - 1, AIndexes[i].Item2 + 1] == 'M' && TheConvayGrid[AIndexes[i].Item1 + 1, AIndexes[i].Item2 - 1] == 'S')
        {
            if (TheConvayGrid[AIndexes[i].Item1 + 1, AIndexes[i].Item2 + 1] == 'M' && TheConvayGrid[AIndexes[i].Item1 - 1, AIndexes[i].Item2 - 1] == 'S')
            {
                count++;
                continue;
            }
        }

        if (TheConvayGrid[AIndexes[i].Item1 + 1, AIndexes[i].Item2 + 1] == 'M' && TheConvayGrid[AIndexes[i].Item1 - 1, AIndexes[i].Item2 - 1] == 'S')
        {
            if (TheConvayGrid[AIndexes[i].Item1 + 1, AIndexes[i].Item2 - 1] == 'M' && TheConvayGrid[AIndexes[i].Item1 - 1, AIndexes[i].Item2 + 1] == 'S')
            {
                count++;
                continue;
            }
        }

        if (TheConvayGrid[AIndexes[i].Item1 + 1, AIndexes[i].Item2 - 1] == 'M' && TheConvayGrid[AIndexes[i].Item1 - 1, AIndexes[i].Item2 + 1] == 'S')
        {
            if (TheConvayGrid[AIndexes[i].Item1 - 1, AIndexes[i].Item2 - 1] == 'M' && TheConvayGrid[AIndexes[i].Item1 + 1, AIndexes[i].Item2 + 1] == 'S')
            {
                count++;
                continue;
            }
        }
    }

    Console.WriteLine("c = " + count);


    static char[,] CreateGrid(string data)
    {
        var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var rows = lines.Length;
        var cols = lines[0].Trim().Length;

        var grid = new char[rows, cols];
        for (var i = 0; i < rows; i++)
        {
            var line = lines[i].Trim();
            for (var j = 0; j < cols; j++)
                grid[i, j] = line[j];
        }
        return grid;
    }


    static List<(int, int)> GetAindexes(char[,] grid)
    {
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);
        var count = 0;


        var AIndexes = new List<(int, int)>();

        //loop the grid
        for (var x = 1; x < rows - 1; x++)
        {
            for (var y = 1; y < cols - 1; y++)
            {
                //look for all A's
                if (grid[x, y] == 'A')
                {
                    AIndexes.Add((x, y));
                }
            }
        }
        return AIndexes;
    }

    static void DisplayGrid(char[,] grid)
    {
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);
        Console.WriteLine("Grid:");
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                Console.Write(grid[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}