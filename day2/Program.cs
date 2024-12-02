// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var dr = new Tools.DataReader();

//var resultText = File.ReadAllText("C:\\dev\\advent_of_code_2024\\data\\day2_test");
var resultText = await dr.read_data("https://adventofcode.com/2024/day/2/input");

Console.WriteLine(resultText);

var lines = resultText.Split("\n");

var safeConter = 0;

foreach (var line in lines)
{
    if(string.IsNullOrEmpty(line))
        continue;

    var numbers = line.Split(" ");
    
    var nums = numbers.Select(x => int.Parse(x)).ToList();
    var NotSafe = false; 
    int? previousNum = null;
    
    bool breakerUp = false;
    bool breakerDown = false;
    
    for (int i = 0; i < numbers.Length -1; i++)
    {
        if (nums[i] == nums[i + 1])
        {
            NotSafe = true;
            break;
        }
        
        if (nums[i] < nums[i + 1])
        { 
            breakerUp = true;
            var n = nums[i] - nums[i + 1];
            if (n > 3)
            {
                NotSafe = true;
                break;
            }
            
            if (n < -3)
            {
                NotSafe = true;
            }
        }
        
        if (nums[i] > nums[i + 1])
        {
            breakerDown = true;
            
            var n = nums[i] - nums[i + 1];
            if (n > 3)
            {
                NotSafe = true;
                break;
            }

            if (n < -3)
            {
                NotSafe = true;
            }
        }
        
        if(breakerUp && breakerDown)
        {
            NotSafe = true;
            break;
        }
    }
    
    if (NotSafe)
    {
        Console.WriteLine(line);
        continue;
    }
    
    safeConter++;
}

Console.WriteLine(safeConter);