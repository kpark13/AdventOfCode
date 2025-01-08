using System.Collections.Immutable;
using System.Text.RegularExpressions;
//DAY 1
/*Console.WriteLine("DAY 1");
//PART 1
Console.WriteLine("PART 1:");
string filePath = "TextFile2.txt";
string[] lines = File.ReadAllLines(filePath);
int[] firstArray = new int[lines.Length];
int[] secondArray = new int[lines.Length];

for (int i = 0; i < lines.Length; i++)
{
    var numbers = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    firstArray[i] = int.Parse(numbers[0]);
    secondArray[i] = int.Parse(numbers[1]);
}

Array.Sort(firstArray);
Array.Sort(secondArray);

int count = 0;
for (int i = 0; i < firstArray.Length; i++)
{
    count += Math.Abs(firstArray[i] - secondArray[i]);
}
Console.WriteLine(count);

//PART 2
Console.WriteLine("PART 2:");
int similarityScore = 0;
for (int i = 0; i < firstArray.Length; i++)
{
    for (int j = 0; j < secondArray.Length; j++)
    {
        if(firstArray[i] == secondArray[j])
        {
            similarityScore += firstArray[i];
        }
    }
}
Console.WriteLine(similarityScore);

Console.WriteLine();*/

//DAY 2
/*Console.WriteLine("DAY 2");
//PART 1
Console.WriteLine("PART 1:");
string filePath = "TextFile3.txt";
string[] lines = File.ReadAllLines(filePath);
int count = 0;

for (int i = 0; i < lines.Length; i++)
{
    string[] numStrings = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    int[] nums = Array.ConvertAll(numStrings, int.Parse);

    bool increasing = true;
    bool decreasing = true;

    for (int j = 0; j < nums.Length - 1; j++) 
    {
        int diff = nums[j + 1] - nums[j];

        if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
        {
            increasing = false;
            decreasing = false;
            break;
        }

        if (diff > 0)
            decreasing = false;
        if (diff < 0)
            increasing = false;
    }

    if (increasing || decreasing)
    {
        count++;
    }
}
Console.WriteLine(count);
// PART 2
Console.WriteLine("PART 2:");
int safeCount = 0;

foreach (string line in lines)
{
    string[] numStrings = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    int[] nums = Array.ConvertAll(numStrings, int.Parse);

    if (IsSafe(nums))
    {
        safeCount++;
    }
    else
    {
        // Try removing one level at a time
        for (int i = 0; i < nums.Length; i++)
        {
            int[] reducedNums = RemoveElement(nums, i);
            if (IsSafe(reducedNums))
            {
                safeCount++;
                break;
            }
        }
    }
}

Console.WriteLine(safeCount);

bool IsSafe(int[] nums)
{
    bool increasing = true;
    bool decreasing = true;

    for (int i = 0; i < nums.Length - 1; i++)
    {
        int diff = nums[i + 1] - nums[i];

        if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            return false;

        if (diff > 0) decreasing = false; 
        if (diff < 0) increasing = false;
    }

    return increasing || decreasing;
}

int[] RemoveElement(int[] array, int index)
{
    int[] result = new int[array.Length - 1];
    int resultIndex = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (i != index)
        {
            result[resultIndex] = array[i];
            resultIndex++;
        }
    }

    return result;
}*/

//DAY 3
/*Console.WriteLine("DAY 3");
//PART 1
Console.WriteLine("PART 1");
string filePath = "TextFile4.txt";
string input = File.ReadAllText(filePath);
string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
Regex regex = new Regex(pattern);

int sum = 0;

// Match all valid `mul(X,Y)` patterns
MatchCollection matches = regex.Matches(input);

foreach (Match match in matches)
{
    // Extract the two numbers
    int x = int.Parse(match.Groups[1].Value);
    int y = int.Parse(match.Groups[2].Value);

    // Calculate the product and add it to the sum
    sum += x * y;
}

// Output the result
Console.WriteLine($"The sum of all valid multiplications is: {sum}");*/
string filePath = "TextFile4.txt";

// Read the input from the file
string input = File.ReadAllText(filePath);

// Regex patterns
string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
string doPattern = @"\bdo\(\)";
string dontPattern = @"\bdon't\(\)";

// Initialize variables
int sum = 0;
bool isEnabled = true; // Start with `mul` instructions enabled

// Process input character by character
var matches = Regex.Matches(input, $"{mulPattern}|{doPattern}|{dontPattern}");

foreach (Match match in matches)
{
    if (Regex.IsMatch(match.Value, doPattern))
    {
        isEnabled = true;
    }
    else if (Regex.IsMatch(match.Value, dontPattern))
    {
        isEnabled = false;
    }
    else if (isEnabled && Regex.IsMatch(match.Value, mulPattern))
    {
        // Extract numbers from the `mul` instruction
        var mulMatch = Regex.Match(match.Value, mulPattern);
        int x = int.Parse(mulMatch.Groups[1].Value);
        int y = int.Parse(mulMatch.Groups[2].Value);

        // Add the result of multiplication to the sum
        sum += x * y;
    }
}

// Output the result
Console.WriteLine($"The sum of all enabled multiplications is: {sum}");
