// See https://aka.ms/new-console-template for more information
using System.Net.WebSockets;
using day2;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var dr = new Tools.DataReader();
        var day3= new day3();
        //day3.part1();
        day3.part2();

        return;
       // var resultText = File.ReadAllText("C:\\dev\\advent_of_code_2024\\data\\day2_test");
        var resultText = await dr.read_data("https://adventofcode.com/2024/day/3/input");

        Console.WriteLine(resultText);


        var lines = resultText.Split("\n");

        var safeCounter = 0;
        //part1();
        //part2();

        void part2() 
        { 
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;
                if (Damp(line))
                    safeCounter++;
            }

            Console.WriteLine(safeCounter);       

            static bool Damp(string line)
            {
                var nums = line.Split(" ").Select(x => int.Parse(x)).ToList();

                if (GreenLight(nums))
                    return true;

                for (int i = 0; i < nums.Count; i++)
                {
                    if (GreenLight(nums, i))
                        return true;
                }

                return false;
            }

            static bool GreenLight(List<int> nums, int? errorSlot = null)
            {
                var checkNodes = errorSlot.HasValue ? GetNewList(nums, errorSlot.Value) : nums;

                bool? isIncreasing = null;

                for (int i = 0; i < checkNodes.Count - 1; i++)
                {
                    int diff = checkNodes[i + 1] - checkNodes[i];
                
                    if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                        return false;
                              
                    if (isIncreasing == null)
                        isIncreasing = diff > 0;

                    else if ((diff > 0) != isIncreasing)
                        return false;
                }

                return true;
            }
            
            static List<int> GetNewList(List<int> numbers, int value)
            {
                var returnList = new List<int>();
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i == value)
                        continue;

                    returnList.Add(numbers[i]);
                }

                return returnList;
            }
        }


        void part1()
        {
            foreach (var line in lines)
            {

                if (string.IsNullOrEmpty(line))
                    continue;

                var numbers = line.Split(" ");

                var nums = numbers.Select(x => int.Parse(x)).ToList();
                var NotSafe = false;

                var breakerUp = false;
                var breakerDown = false;

                for (var i = 0; i < numbers.Length - 1; i++)
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

                    if (breakerUp && breakerDown)
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

                safeCounter++;
            }

            Console.WriteLine(safeCounter);
            safeCounter = 0;
        }
    }    
}