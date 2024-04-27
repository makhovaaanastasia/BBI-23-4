using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;

abstract class Task
{
    public abstract override string ToString();
    protected Task() { }
}

class Task2 : Task
{
    private string message;

    public Task2(string message)
    {
        this.message = message;
    }

    public string Encrypt()
    {
        char[] charArray = message.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public string Decrypt(string encryptedMessage)
    {
        char[] charArray = encryptedMessage.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public override string ToString()
    {
        return $"Зашифрованное сообщение: {Encrypt()}\nРасшифрованное сообщение: {Decrypt(Encrypt())}";
    }

}
class Task4 : Task
{
    private string sentence;

    public Task4(string sentence)
    {
        this.sentence = sentence;
    }

    public int Complexity()
    {
        return sentence.Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length + Regex.Matches(sentence, @"[.,;:!?]").Count;
    }

    public override string ToString()
    {
        return $"Предложение: {sentence}\nСложность: {Complexity()}";
    }
}
class Task5 : Task
{
    private string filePath;

    public Task5(string filePath)
    {
        this.filePath = filePath;
    }

    public override string ToString()
    {
        string text = File.ReadAllText(filePath);
        var frequencyDict = new Dictionary<char, int>();

        foreach (string word in text.Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries))
        {
            if (word.Length > 0)
            {
                char firstChar = word.ToLower()[0];
                if (char.IsLetter(firstChar))
                {
                    if (frequencyDict.ContainsKey(firstChar))
                        frequencyDict[firstChar]++;
                    else
                        frequencyDict[firstChar] = 1;
                }
            }
        }

        var sortedFrequency = frequencyDict.OrderByDescending(pair => pair.Value);

        string result = "Частота букв в порядке убывания:\n";
        foreach (var pair in sortedFrequency)
        {
            result += $"{pair.Key}: {pair.Value}\n";
        }

        return result;
    }
}

class Task7 : Task
{
    private string filePath;
    private string sequence;

    public Task7(string filePath, string sequence)
    {
        this.filePath = filePath;
        this.sequence = sequence.ToLower(); 
    }

    public override string ToString()
    {
        string text = File.ReadAllText(filePath);
        string[] words = text.Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> matchingWords = new List<string>();

        foreach (string word in words)
        {
            if (word.ToLower().Contains(sequence)) 
                matchingWords.Add(word);
        }

        return $"Слова, содержащие последовательность '{sequence}':\n{string.Join(", ", matchingWords)}";
    }
}
class Task11 : Task
{
    private string filePath;

    public Task11(string filePath)
    {
        this.filePath = filePath;
    }

    public override string ToString()
    {
        string[] surnames = File.ReadAllText(filePath).Split(',');
        Array.Sort(surnames);
        return $"Отсортированный список фамилий: {string.Join(", ", surnames)}";
    }
}
class Task14 : Task
{
    private string filePath;

    public Task14(string filePath)
    {
        this.filePath = filePath;
    }

    public override string ToString()
    {
        string text = File.ReadAllText(filePath);
        MatchCollection numbers = Regex.Matches(text, @"\b[1-9]|10\b");
        int sum = 0;

        foreach (Match number in numbers)
        {
            sum += int.Parse(number.Value);
        }

        return $"Сумма чисел в тексте: {sum}";
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание 2:");
        Task task2 = new Task2("Привет, мир!");
        Console.WriteLine(task2);
        Console.WriteLine();
        Console.WriteLine("Задание 4:");
        Task task4 = new Task4("Это предложение имеет среднюю сложность.");
        Console.WriteLine(task4);
        Console.WriteLine();
        Console.WriteLine("Задание 5:");
        Task task5 = new Task5(@"/Users/anastastasiamahova/Desktop/proga/laba8/5.txt");
        Console.WriteLine(task5);
        Console.WriteLine();
        Console.WriteLine("Задание 7:");
        Task task7 = new Task7(@"/Users/anastastasiamahova/Desktop/proga/laba8/7.txt", "движ");
        Console.WriteLine(task7);
        Console.WriteLine();
        Console.WriteLine("Задание 11:");
        Task task11 = new Task11(@"/Users/anastastasiamahova/Desktop/proga/laba8/11.txt");
        Console.WriteLine(task11);
        Console.WriteLine();
        Console.WriteLine("Задание 14:");
        Task task14 = new Task14(@"/Users/anastastasiamahova/Desktop/proga/laba8/14.txt");
        Console.WriteLine(task14);
    }
}
