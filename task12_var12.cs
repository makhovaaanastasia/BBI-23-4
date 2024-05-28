using System;
using System.Text;

public abstract class Task
{
    public abstract double Execute(string input);
}

public class MostFrequentLetterTask : Task
{
    public override double Execute(string input)
    {
        string cleanedInput = input.ToLower();
        int[] letterCounts = new int[33]; 
        int totalLetters = 0;

        foreach (char c in cleanedInput)
        {
            if (c >= 'a' && c <= 'z')
            {
                letterCounts[c - 'a']++;
                totalLetters++;
            }
            else if (c >= 'а' && c <= 'я')
            {
                letterCounts[c - 'а' + 26]++; 
                totalLetters++;
            }
        }

        int maxCount = 0;
        for (int i = 0; i < letterCounts.Length; i++)
        {
            if (letterCounts[i] > maxCount)
            {
                maxCount = letterCounts[i];
            }
        }

        return totalLetters > 0 ? (double)maxCount / totalLetters : 0;
    }
}

public class AverageNumbersTask : Task
{
    public override double Execute(string input)
    {
        int sum = 0;
        int count = 0;
        StringBuilder numberBuilder = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsDigit(c) || (c == '-' && numberBuilder.Length == 0) || (c == '+' && numberBuilder.Length == 0))
            {
                numberBuilder.Append(c);
            }
            else
            {
                if (numberBuilder.Length > 0)
                {
                    sum += int.Parse(numberBuilder.ToString());
                    count++;
                    numberBuilder.Clear();
                }
            }
        }

        if (numberBuilder.Length > 0)
        {
            sum += int.Parse(numberBuilder.ToString());
            count++;
        }

        return count > 0 ? (double)sum / count : 0;
    }
}

public class task12_var12
{
    public static void Main(string[] args)
    {
        string input = "Привет, Мир! 12345"; 

        Task mostFrequentTask = new MostFrequentLetterTask();
        double mostFrequentResult = mostFrequentTask.Execute(input);

        Task averageNumbersTask = new AverageNumbersTask();
        double averageNumbersResult = averageNumbersTask.Execute(input);

        Console.WriteLine($"Частота наиболее часто встречающейся буквы: {mostFrequentResult}, Среднее число: {averageNumbersResult}");
    }
}