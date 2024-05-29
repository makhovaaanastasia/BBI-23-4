using System;
using System.IO;//классы и методы для работы с файлами и потоками ввода/вывода
using System.Linq;// классы и методы для работы с коллекциями данных (списки, массивы и т.д.) в стиле запросов к базам данных
using System.Text.RegularExpressions;//поиск и обработка текстовых данных
using System.Collections.Generic;//list, dictionary
using System.Threading.Tasks;//для параллельных задач
using System.Globalization;//различные калькуляторы
using System.Text;//текстовые данные

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
        string[] words = message.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = ReverseWord(words[i]);
        }
        return string.Join(" ", words);
    }

    private string ReverseWord(string word)
    {
        char[] charArray = word.ToCharArray();//из слова в массив символов
        int left = 0;
        int right = charArray.Length - 1;//последний элемент имеет индекс = длине массива минус 1
        while (left < right)
        {
            if (!char.IsLetter(charArray[left]))//является ли текущий символ в charArray (на позиции left) буквой
            {
                left++;
            }
            else if (!char.IsLetter(charArray[right]))
            {
                right--;
            }
            else //left и right буквы
            {
                char temp = charArray[left];
                charArray[left] = charArray[right];
                charArray[right] = temp;
                left++;
                right--;
            }
        }
        return new string(charArray); //создает новую строку из массива символов charArray
    }

    public string Decrypt(string encryptedMessage)
    {
        return Encrypt(); // шифрование и дешифрование одно и то же в данном случае
    }

    public override string ToString() //строковое представление объекта
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

    public int Complexity()// кол-о знаков препинания и слов
    {
        return sentence.Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length + Regex.Matches(sentence, @"[.,;:!?]").Count;
    }                    //   делит на слова и знаки препинания по указанным разделителям, удаление пустых элементов, подсчет кол-а знаков препинания
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
        //слово извлекается из строки и сохраняется в переменной word
        {
            if (word.Length > 0)
            {
                char firstChar = word.ToLower()[0]; //первую букву в нижний регистр
                if (char.IsLetter(firstChar))//является ли первый символ буквой
                {
                    if (frequencyDict.ContainsKey(firstChar)) //существует ли уже буква в словаре frequencyDict
                        frequencyDict[firstChar]++;
                    else
                        frequencyDict[firstChar] = 1; //добавляет ее в словарь с начальным значением 1
                }
            }
        }

        var sortedFrequency = frequencyDict.OrderByDescending(pair => pair.Value); //отсортированный по убыванию,  LINQ-метод сравнения значений пар ключ-значение в словаре при сортировке

        string result = "Частота букв в порядке убывания:\n";
        foreach (var pair in sortedFrequency)//отсортированный словарь
        {
            result += $"{pair.Key}: {pair.Value}\n"; //слово+значение
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
        this.sequence = sequence.ToLower(); //в нижний регистр
    }

    public override string ToString()
    {
        string text = File.ReadAllText(filePath);
        string[] words = text.Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries); //разделяет и удаляет пустые
        List<string> matchingWords = new List<string>(); //список строк для хранения найденных слов, содержащих последовательность символов

        foreach (string word in words)
        {
            if (word.ToLower().Contains(sequence)) //содержит ли строка word подстроку sequence, игнорируя регистр
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
        CustomSort(surnames);

        StringBuilder result = new StringBuilder();
        foreach (string surname in surnames)
        {
            result.AppendLine($"{surname},");//добавление фамилии
        }

        return $"Отсортированный список фамилий:\n{result}";
    }

    private void CustomSort(string[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (CustomCompare(array[j], array[j + 1]) > 0)
                {
                    string temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    private int CustomCompare(string a, string b)
    {
        int minLength = Math.Min(a.Length, b.Length);//определение минимальной длины между строками

        for (int i = 0; i < minLength; i++)
        {
            if (a[i] < b[i])// символ строки a меньше символа строки b, возвращаем -1
            {
                return -1;
            }
            else if (a[i] > b[i])
            {
                return 1;
            }
        }

        if (a.Length < b.Length)// строки равны до длины minLength, сравниваем их длины
        {
            return -1;
        }
        else if (a.Length > b.Length)
        {
            return 1;
        }

        return 0;
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
        // CurrentCulture - свойство потока, определяющее его культуру (язык, формат чисел)
        // CultureInfo.GetCultureInfo("en-us") - объект культуры для английского языка

        string text = File.ReadAllText(filePath);
        string[] parts = text.Split(new char[] { ' ', '\t', '\n', '\r', ',', ';', ':', '!', '?', '(', ')', '[', ']', '{', '}', '"', '\'' }, StringSplitOptions.RemoveEmptyEntries);
        // Разделяем текст на части, используя множество разделителей и удаляя пустые элементы

        double sum = 0.0;

        foreach (string part in parts) // перебор всех частей текста
        {
            if (double.TryParse(part, NumberStyles.Float, CultureInfo.InvariantCulture, out double number)) // пытаемся преобразовать часть в число
            {
                sum += number; // если преобразование успешно, добавляем число к сумме
            }
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
