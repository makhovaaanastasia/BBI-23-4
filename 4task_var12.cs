using System;
using System.IO;

class Program
{
    static void Main()
    {
        //  путь к папке пользователя
        string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        // путь к папке "Answer" внутри папки пользователя
        string answerFolderPath = Path.Combine(userFolder, "Answer");

        // проверка на существование папки "Answer"
        if (Directory.Exists(answerFolderPath))
        {
            Console.WriteLine("Папка 'Answer' уже существует.");

            //  путь к первому файлу "cw2_1.json"
            string firstFilePath = Path.Combine(answerFolderPath, "cw2_1.json");

            // проверка на существование файла "cw2_1.json"
            if (File.Exists(firstFilePath))
            {
                // читаем данные из файла
                string jsonData = File.ReadAllText(firstFilePath);
                Console.WriteLine($"Содержимое файла 'cw2_1.json': {jsonData}");
            }
            else
            {
                Console.WriteLine("Файл 'cw2_1.json' не существует.");
            }

            // создаем путь ко второму файлу "cw2_2.json"
            string secondFilePath = Path.Combine(answerFolderPath, "cw2_2.json");

            // проверяем существование файла "cw2_2.json"
            if (File.Exists(secondFilePath))
            {
                // читаем данные из файла
                string jsonData = File.ReadAllText(secondFilePath);
                Console.WriteLine($"Содержимое файла 'cw2_2.json': {jsonData}");
            }
            else
            {
                Console.WriteLine("Файл 'cw2_2.json' не существует.");
            }
        }
        else
        {
            Console.WriteLine("Папка 'Answer' не существует.");
        }
    }
}