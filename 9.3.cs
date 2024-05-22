using System;
using System.IO;
using System.Text.Json;
using MySerializeLibrary;

class SkiRace
{
    class Athlete
    {
        public string LastName { get; set; }
        public double Time { get; set; }

        public Athlete(string lastName, double time)
        {
            LastName = lastName;
            Time = time;
        }

        public virtual void Print() //может быть переопределен в наследниках
        {
            Console.WriteLine("{0, -10} {1, -10}", LastName, Time);
        }
    }

    class Skier : Athlete //наследуется от Athlete
    {
        public Skier(string lastName, double time) : base(lastName, time)
        {
        }
    }

    class SkierWoman : Athlete
    {
        public SkierWoman(string lastName, double time) : base(lastName, time)
        {
        }
    }

    static void Main(string[] args)
    {
        Athlete[] skierMenGroup1 = {
            new Skier("Иванов", 30.5),
            new Skier("Петров", 29.8),
            new Skier("Сидоров", 31.2),
        };

        Athlete[] skierMenGroup2 = {
            new Skier("Смирнов", 28.7),
            new Skier("Васильев", 30.1),
            new Skier("Николаев", 29.5),
        };

        Athlete[] skierWomenGroup1 = {
            new SkierWoman("Семенова", 28.7),
            new SkierWoman("Козлова", 30.1),
            new SkierWoman("Михайлова", 29.5),
        };

        Athlete[] skierWomenGroup2 = {
            new SkierWoman("Петрова", 27.5),
            new SkierWoman("Сидорова", 29.9),
            new SkierWoman("Иванова", 28.3),
        };

        SortResults(skierMenGroup1);
        SortResults(skierMenGroup2);
        SortResults(skierWomenGroup1);
        SortResults(skierWomenGroup2);

        // объединение результатов лыжников мужчин и женщин в один массив
        Athlete[] combinedResultsMen = new Athlete[skierMenGroup1.Length + skierMenGroup2.Length];
        Array.Copy(skierMenGroup1, 0, combinedResultsMen, 0, skierMenGroup1.Length);
        Array.Copy(skierMenGroup2, 0, combinedResultsMen, skierMenGroup1.Length, skierMenGroup2.Length);

        Athlete[] combinedResultsWomen = new Athlete[skierWomenGroup1.Length + skierWomenGroup2.Length];
        Array.Copy(skierWomenGroup1, 0, combinedResultsWomen, 0, skierWomenGroup1.Length);
        Array.Copy(skierWomenGroup2, 0, combinedResultsWomen, skierWomenGroup1.Length, skierWomenGroup2.Length);

        // объединение результатов лыжников мужчин и женщин в один общий массив
        Athlete[] combinedResults = new Athlete[combinedResultsMen.Length + combinedResultsWomen.Length];
        Array.Copy(combinedResultsMen, 0, combinedResults, 0, combinedResultsMen.Length);
        Array.Copy(combinedResultsWomen, 0, combinedResults, combinedResultsMen.Length, combinedResultsWomen.Length);

        SortResults(combinedResults);

        Console.WriteLine("Результаты гонок:");
        Console.WriteLine("Лыжники Мужчины:");
        PrintResults(combinedResultsMen);
        Console.WriteLine("Лыжницы Женщины:");
        PrintResults(combinedResultsWomen);
        Console.WriteLine("Общие результаты:");
        PrintResults(combinedResults);

        // Сериализация и десериализация
        string savePath = @"C:\YourPath\ski_results.json";
        MySerializeJson.Serialize(combinedResults, savePath);

        Athlete[] loadedResults = MySerializeJson.Deserialize<Athlete[]>(savePath);

        Console.WriteLine("Загруженные результаты:");
        PrintResults(loadedResults);
    }

    static void SortResults(Athlete[] results) //по возрастанию, наибольший в конце
    {
        for (int i = 0; i < results.Length - 1; i++) //контролирует количество проходов по массиву
        {
            for (int j = 0; j < results.Length - 1 - i; j++) //сравнивает элементы
            {
                if (results[j].Time > results[j + 1].Time)
                {
                    Athlete temp = results[j];
                    results[j] = results[j + 1];
                    results[j + 1] = temp;
                }
            }
        }
    }

    static void PrintResults(Athlete[] results)
    {
        Console.WriteLine("{0, -10} {1, -10}", "Фамилия:", "Время:");
        foreach (var result in results)
        {
            result.Print();
        }
        Console.WriteLine();
    }
}
