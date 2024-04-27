using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;
using System.Text;

abstract class Task
{
    public abstract override string ToString();

    // Добавляем конструктор без параметров
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
        string[] words = message.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = ReverseWord(words[i]);
        }
        return string.Join(" ", words);
    }

    private string ReverseWord(string word)
    {
        char[] charArray = word.ToCharArray();
        int left = 0;
        int right = charArray.Length - 1;
        while (left < right)
        {
            if (!char.IsLetter(charArray[left]))
            {
                left++;
            }
            else if (!char.IsLetter(charArray[right]))
            {
                right--;
            }
            else
            {
                char temp = charArray[left];
                charArray[left] = charArray[right];
                charArray[right] = temp;
                left++;
                right--;
            }
        }
        return new string(charArray);
    }

    public string Decrypt(string encryptedMessage)
    {
        return Encrypt(); // шифрование и дешифрование одно и то же в данном случае
    }

    public override string ToString()
    {
        return $"Исходное сообщение: {message}\nЗашифрованное сообщение: {Encrypt()}";
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
class Task5 : Task //
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
        string[] surnames = File.ReadAllText(filePath).Split(new char[] { ',', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(surnames);

        StringBuilder result = new StringBuilder();
        foreach (string surname in surnames)
        {
            result.AppendLine($"{surname},");
        }

        return $"Отсортированный список фамилий:\n{result}";
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
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");

        string text = File.ReadAllText(filePath);
        var matches = Regex.Matches(text, @"[-+]?\d+(?:\.\d+)?(?:[eE][-+]?\d+)?");
        var sum = 0.0;

        foreach (Match item in matches)
        {
            sum += double.Parse(item.Value, CultureInfo.GetCultureInfo("en-us"));
        }

        return $"Сумма включенных в текст чисел: {sum.ToString()}";
    }
}
class Program
{
    static void Main(string[] args)//Вызываем рещшения наших задачек
    {
        Console.WriteLine("Задание 2");
        Task task2 = new Task2("Привет, дорогой, мир!");
        Console.WriteLine(task2);
        Console.WriteLine();
        Console.WriteLine("Задание 4");
        Task task4 = new Task4("Москва очень красивый город!");
        Console.WriteLine(task4);
        Console.WriteLine();
        Console.WriteLine("Задание 5");
        Task task5 = new Task5(@"/Users/anastastasiamahova/Desktop/proga/laba8/5.txt");
        Console.WriteLine(task5);
        Console.WriteLine();
        Console.WriteLine("Задание 7");
        Task task7 = new Task7(@"/Users/anastastasiamahova/Desktop/proga/laba8/7.txt", "движ");
        Console.WriteLine(task7);
        Console.WriteLine();
        Console.WriteLine("Задание 11");
        Task task11 = new Task11(@"/Users/anastastasiamahova/Desktop/proga/laba8/11.txt");
        Console.WriteLine(task11);
        Console.WriteLine();
        Console.WriteLine("Задание 14");
        Task task14 = new Task14(@"/Users/anastastasiamahova/Desktop/proga/laba8/14.txt");
        Console.WriteLine(task14);
    }
}
