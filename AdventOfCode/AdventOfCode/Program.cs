using System.Collections.Immutable;
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