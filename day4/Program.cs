// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

char[,] CreateGrid(string data)
{
    string[] lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries); // Remove empty lines
    int rows = lines.Length;
    int cols = lines[0].Trim().Length;

    char[,] grid = new char[rows, cols];
    for (int i = 0; i < rows; i++)
    {        
        for (int j = 0; j < cols - 1; j++)
            grid[i, j] = lines[i][j];
    }
    return grid;
}

string input = """
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

char[,] TheConvayGrid = CreateGrid(input);
int rows = TheConvayGrid.GetLength(0);
int cols = TheConvayGrid.GetLength(1);
Console.WriteLine("Convay rows" + rows);
Console.WriteLine("Convay cols" + cols);
foreach (var item in TheConvayGrid)
{
    Console.Write(item);
}

//this is convay game of life but we keep going and looking in the snowflake pattern from the center 0(X) + 1(M) + 2(A) + 3(S) in all directions

