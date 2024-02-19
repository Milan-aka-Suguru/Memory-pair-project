using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] uniqueNumbers = GenerateUniqueRandomNumbers(1, 9, 9); 
        int[] numbersTwice = uniqueNumbers.Concat(uniqueNumbers).ToArray();
        ShuffleArray(numbersTwice);

        
        Console.WriteLine("Array with each number appearing twice:");
        foreach (var number in numbersTwice)
        {
            Console.Write(number + " ");
        }
        
        Console.ReadKey();
    }

    static int[] GenerateUniqueRandomNumbers(int min, int max, int count)
    {
        Random random = new Random();
        return Enumerable.Range(min, max - min + 1)
                         .OrderBy(x => random.Next())
                         .Take(count)
                         .ToArray();
    }

    static void ShuffleArray(int[] array)
    {
        Random random = new Random();
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
          
            int randomIndex = i + random.Next(n - i);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
