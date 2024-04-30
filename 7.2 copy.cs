using System;

public abstract class Competition
{
    protected string lastName;
    protected double[] styleScores;
    protected double jumpDistance;
    protected double totalScore;

    // конструктор класса
    public Competition(string lastName, double[] styleScores, double jumpDistance)
    {
        this.lastName = lastName;
        this.styleScores = styleScores;
        this.jumpDistance = jumpDistance;
        this.totalScore = 0;
        CalculateTotalScore();
    }

    // абстрактный метод для расчета общего балла
    protected abstract void CalculateTotalScore();

    // методы доступа к данным участника
    public string GetLastName()
    {
        return this.lastName;
    }

    public double GetTotalScore()
    {
        return this.totalScore;
    }

    // Метод для сортировки массива участников по общему баллу слиянием
    public static void MergeSort(Competition[] a, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(a, left, mid);
            MergeSort(a, mid + 1, right);
            Merge(a, left, mid, right);
        }
    }

    // метод слияния
    private static void Merge(Competition[] a, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        Competition[] L = new Competition[n1];
        Competition[] R = new Competition[n2];

        Array.Copy(a, left, L, 0, n1);
        Array.Copy(a, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (L[i].GetTotalScore() >= R[j].GetTotalScore())
            {
                a[k] = L[i];
                i++;
            }
            else
            {
                a[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            a[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            a[k] = R[j];
            j++;
            k++;
        }
    }
}

// Класс для соревнований по прыжкам в длину на лыжах
public class SkiJumpCompetition : Competition
{
    public SkiJumpCompetition(string lastName, double[] styleScores, double jumpDistance)
        : base(lastName, styleScores, jumpDistance)
    {
    }

    protected override void CalculateTotalScore()
    {
        const int NumJudges = 5;
        const double BaseDistance = 120.0;
        const double BaseScore = 60.0;
        const double ScorePerMeter = 2.0; // за каждый метр превышения
        const double PenaltyPerMeter = -2.0; // за каждый метр уменьшения

        double sum = 0;
        for (int k = 1; k < styleScores.Length - 1; k++)//сумма оценок за стиль каждого участника
        {
            sum += styleScores[k];
        }

        double distanceDifference = jumpDistance - BaseDistance;
        double distanceScore = distanceDifference > 0
            ? BaseScore + distanceDifference * ScorePerMeter
            : BaseScore + distanceDifference * PenaltyPerMeter;

        totalScore = sum + distanceScore;
    }
}

// класс для соревнований по прыжкам в длину на коньках
public class LongJumpCompetition : Competition
{
    public LongJumpCompetition(string lastName, double[] styleScores, double jumpDistance)
        : base(lastName, styleScores, jumpDistance)
    {
    }

    protected override void CalculateTotalScore()
    {
        const int NumJudges = 5;
        const double BaseDistance = 120.0;
        const double BaseScore = 60.0;
        const double ScorePerMeter = 2.0; // за каждый метр превышения
        const double PenaltyPerMeter = -2.0; // за каждый метр уменьшения

        double sum = 0;
        for (int k = 1; k < styleScores.Length - 1; k++)
        {
            sum += styleScores[k];
        }

        double distanceDifference = jumpDistance - BaseDistance;
        double distanceScore = distanceDifference > 0
            ? BaseScore + distanceDifference * ScorePerMeter
            : BaseScore + distanceDifference * PenaltyPerMeter;

        totalScore = sum + distanceScore;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример использования:
        Competition[] competitions = new Competition[5];
        competitions[0] = new SkiJumpCompetition("Семенов", new double[] { 18.5, 17.5, 19.0, 20.0, 18.0 }, 122.0);
        competitions[1] = new LongJumpCompetition("Иванов", new double[] { 19.0, 18.0, 17.0, 16.5, 18.5 }, 118.0);
        competitions[2] = new SkiJumpCompetition("Смирнов", new double[] { 20.0, 19.5, 19.0, 18.5, 20.0 }, 125.0);
        competitions[3] = new LongJumpCompetition("Галков", new double[] { 17.5, 17.0, 18.5, 19.0, 18.0 }, 121.5);
        competitions[4] = new SkiJumpCompetition("Добров", new double[] { 19.5, 20.0, 19.0, 18.5, 19.5 }, 123.5);

        // сортировка участников по общему баллу с использованием сортировки слиянием
        Competition.MergeSort(competitions, 0, competitions.Length - 1);

        //Вывод результатов (аналогично предыдущему коду)
        Console.WriteLine("Соревнования по прыжкам в длину");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Результаты:");
        for (int i = 0; i < competitions.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {competitions[i].GetLastName()}: {competitions[i].GetTotalScore()} очков");
        }
    }
}
