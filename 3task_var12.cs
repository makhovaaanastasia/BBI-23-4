using System;
using System.IO;

class Program
{
    static void Main()
    {
        string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string answerFolder = Path.Combine(userFolder, "Answer");

        if (!Directory.Exists(answerFolder))
        {
            Directory.CreateDirectory(answerFolder);
            Console.WriteLine("Папка 'Answer' создана.");
        }
        else
        {
            Console.WriteLine("Папка 'Answer' уже существует.");
        }

        string filePath1 = Path.Combine(answerFolder, "cw2_1.json");
        string filePath2 = Path.Combine(answerFolder, "cw2_2.json");

        if (!File.Exists(filePath1))
        {
            File.WriteAllText(filePath1, "{}"); 
            Console.WriteLine("Файл 'cw2_1.json' создан.");
        }
        else
        {
            Console.WriteLine("Файл 'cw2_1.json' уже существует.");
        }

        if (!File.Exists(filePath2))
        {
            File.WriteAllText(filePath2, "{}"); 
            Console.WriteLine("Файл 'cw2_2.json' создан.");
        }
        else
        {
            Console.WriteLine("Файл 'cw2_2.json' уже существует.");
        }
    }
}