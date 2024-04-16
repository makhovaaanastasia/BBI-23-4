// using System;

// public abstract class Competition
// {
//     protected string lastName;
//     protected double[] styleScores;
//     protected double jumpDistance;
//     protected double totalScore;

//     // конструктор класса
//     public Competition(string lastName, double[] styleScores, double jumpDistance)
//     {
//         this.lastName = lastName;
//         this.styleScores = styleScores;
//         this.jumpDistance = jumpDistance;
//         this.totalScore = 0;
//         CalculateTotalScore();
//     }

//     // абстрактный метод для расчета общего балла
//     protected abstract void CalculateTotalScore();

//     // методы доступа к данным участника
//     public string GetLastName()
//     {
//         return this.lastName;
//     }

//     public double GetTotalScore()
//     {
//         return this.totalScore;
//     }
// }

// // Класс для соревнований по прыжкам в длину на лыжах
// public class SkiJumpCompetition : Competition
// {
//     public SkiJumpCompetition(string lastName, double[] styleScores, double jumpDistance)
//         : base(lastName, styleScores, jumpDistance)
//     {
//     }

//     protected override void CalculateTotalScore()
//     {
//         const int NumJudges = 5;
//         const double BaseDistance = 120.0;
//         const double BaseScore = 60.0;
//         const double ScorePerMeter = 2.0; // за каждый метр превышения
//         const double PenaltyPerMeter = -2.0; // за каждый метр уменьшения

//         double sum = 0;
//         for (int k = 1; k < styleScores.Length - 1; k++)
//         {
//             sum += styleScores[k];
//         }

//         double distanceDifference = jumpDistance - BaseDistance;
//         double distanceScore = distanceDifference > 0
//             ? BaseScore + distanceDifference * ScorePerMeter
//             : BaseScore + distanceDifference * PenaltyPerMeter;

//         totalScore = sum + distanceScore;
//     }
// }

// // Класс для соревнований по прыжкам в длину на коньках
// public class LongJumpCompetition : Competition
// {
//     public LongJumpCompetition(string lastName, double[] styleScores, double jumpDistance)
//         : base(lastName, styleScores, jumpDistance)
//     {
//     }

//     protected override void CalculateTotalScore()
//     {
//         const int NumJudges = 5;
//         const double BaseDistance = 120.0;
//         const double BaseScore = 60.0;
//         const double ScorePerMeter = 2.0; // за каждый метр превышения
//         const double PenaltyPerMeter = -2.0; // за каждый метр уменьшения

//         double sum = 0;
//         for (int k = 1; k < styleScores.Length - 1; k++)
//         {
//             sum += styleScores[k];
//         }

//         double distanceDifference = jumpDistance - BaseDistance;
//         double distanceScore = distanceDifference > 0
//             ? BaseScore + distanceDifference * ScorePerMeter
//             : BaseScore + distanceDifference * PenaltyPerMeter;

//         totalScore = sum + distanceScore;
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Пример использования:
//         Competition[] competitions = new Competition[5];
//         competitions[0] = new SkiJumpCompetition("Семенов", new double[] { 18.5, 17.5, 19.0, 20.0, 18.0 }, 122.0);
//         competitions[1] = new LongJumpCompetition("Иванов", new double[] { 19.0, 18.0, 17.0, 16.5, 18.5 }, 118.0);
//         competitions[2] = new SkiJumpCompetition("Смирнов", new double[] { 20.0, 19.5, 19.0, 18.5, 20.0 }, 125.0);
//         competitions[3] = new LongJumpCompetition("Галков", new double[] { 17.5, 17.0, 18.5, 19.0, 18.0 }, 121.5);
//         competitions[4] = new SkiJumpCompetition("Добров", new double[] { 19.5, 20.0, 19.0, 18.5, 19.5 }, 123.5);

//         // сортировка участников по общему баллу (примерно как в предыдущем коде)
//         for (int i = 0; i < competitions.Length - 1; i++)
//         {
//             for (int j = i + 1; j < competitions.Length; j++)
//             {
//                 if (competitions[j].GetTotalScore() > competitions[i].GetTotalScore())
//                 {
//                     var temp = competitions[i];
//                     competitions[i] = competitions[j];
//                     competitions[j] = temp;
//                 }
//             }
//         }

//         // Вывод результатов (аналогично предыдущему коду)
//         Console.WriteLine("Соревнования по прыжкам в длину");
//         Console.WriteLine("----------------------------------------");
//         Console.WriteLine("Результаты:");
//         for (int i = 0; i < competitions.Length; i++)
//         {
//             Console.WriteLine($"{i + 1}. {competitions[i].GetLastName()}: {competitions[i].GetTotalScore()} очков");
//         }
//     }
// }
