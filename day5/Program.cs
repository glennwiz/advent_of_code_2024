// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var xx = """
    47|53
    97|13
    97|61
    97|47
    75|29
    61|13
    75|53
    29|13
    97|29
    53|29
    61|53
    97|53
    61|29
    47|13
    75|47
    97|75
    47|61
    75|61
    47|29
    75|13
    53|13

    75,47,61,53,29
    97,61,53,29,13
    75,29,13
    75,97,47,61,53
    61,13,29
    97,13,75,29,47
    """;

var dr = new Tools.DataReader();

var x = await dr.read_data("https://adventofcode.com/2024/day/5/input");

//this is the input string, split in to two parts,,, we split after the fist empty line

var parts = x.Split("\r\n\r\n");


//parse the first part
var rules = parts[0].Split("\n").Select(r => r.Split("|").Select(int.Parse).ToArray()).ToArray();

var dict = new Dictionary<int, List<int>>();
foreach (var rule in rules)
{
    if (!dict.ContainsKey(rule[0]))
    {
        dict[rule[0]] = new List<int>();
    }
    dict[rule[0]].Add(rule[1]);
}

var lines = parts[1].Split("\r\n");

var correctLines = new List<List<int>>();
var errorLines = new List<List<int>>();

var listOfNumbers = new List<List<int>>();
foreach (var item in lines)
{
   var nums = item.Split(",").Select(int.Parse).ToList();
   listOfNumbers.Add(nums);
}

for (int i = 0; i < listOfNumbers.Count(); i++)
{
    var nummerList = listOfNumbers[i];
    Console.WriteLine("----");
    var doWeIntersect = false;
    for (int n = 0; n < nummerList.Count(); n++)
    {
        if (n == 0 || doWeIntersect) continue;
        
        if (dict.ContainsKey(nummerList[n]))
        {
            var nummer = nummerList[n];
            var list = dict[nummer];
            //we need to check that all the numbers up to this point is not in the list of numbers
            var previousNumbers = nummerList.Take(n).ToList();
            
            //previuousNumbers is not allowd to be in list
            var z = list.Intersect(previousNumbers).Any();
            doWeIntersect = z;
            Console.WriteLine("result " + z);
        }
    }

    if (!doWeIntersect)
    {
        correctLines.Add(nummerList);
    }
    else
    {
        errorLines.Add(nummerList);
    }


}

//let find the center number in the lists
var centerNumbers = new List<int>();
foreach (var item in correctLines)
{
    var length = item.Count();
    var center = item[length / 2];
    centerNumbers.Add(center);
}

var result = centerNumbers.Aggregate((a, b) => a + b);

Console.WriteLine(result);

List<int> BubbleOrderer(List<int> line, Dictionary<int, List<int>> dict)
{
    var change = true;
    while (change)
    {
        change = false;
        for (int i = 0; i < line.Count - 1; i++)
        {
            var n = line[i];
            var n_n = line[i + 1];

            if (dict.ContainsKey(n_n) && dict[n_n].Contains(n))
            {
                line[i] = n_n;
                line[i + 1] = n;
                change = true;
            }
        }
    }

    return line;
}
var reorderedLines = errorLines.Select(line => BubbleOrderer(line, dict)).ToList();

centerNumbers = new List<int>();
foreach (var line in reorderedLines)
{
    var center = line[line.Count / 2];
    centerNumbers.Add(center);
    Console.WriteLine($"Line: {string.Join(",", line)} - center: {center}");
}

var finalSum = centerNumbers.Sum();
Console.WriteLine($"Final sum: {finalSum}");    