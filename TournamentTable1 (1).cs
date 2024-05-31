using System;
using System.Collections.Generic;

namespace ЛР_10_1
{
    public partial class TournamentTable : ITable
    {
        public string Name { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();

        public TournamentTable() { }  // Parameterless constructor for serialization

        public TournamentTable(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            string info = $"Tournament: {Name}\nTeams:\n";
            foreach (var team in Teams)
            {
                info += team.ToString() + "\n";
            }
            return info;
        }

        public void AddMatch(Team team1, Team team2)
        {
            Random random = new Random();
            int result = random.Next(3); // Random result: 0 = draw, 1 = team1 wins, 2 = team2 wins

            if (result == 0)
            {
                team1.Draws++;
                team2.Draws++;
            }
            else if (result == 1)
            {
                team1.Wins++;
                team2.Losses++;
            }
            else
            {
                team1.Losses++;
                team2.Wins++;
            }
        }

        public void Sort(string criteria)
        {
            if (criteria == "points")
            {
                BubbleSortByPoints();
            }
            else if (criteria == "name")
            {
                BubbleSortByName();
            }
        }

        public void Sort(int dummy)
        {
            // Sort by points if dummy is 0, otherwise sort by name
            if (dummy == 0)
            {
                BubbleSortByPoints();
            }
            else
            {
                BubbleSortByName();
            }
        }

        private void BubbleSortByPoints()
        {
            int n = Teams.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Teams[j].CalculatePoints() < Teams[j + 1].CalculatePoints())
                    {
                        // swap temp and Teams[j]
                        var temp = Teams[j];
                        Teams[j] = Teams[j + 1];
                        Teams[j + 1] = temp;
                    }
                }
            }
        }

        private void BubbleSortByName()
        {
            int n = Teams.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(Teams[j].Name, Teams[j + 1].Name, StringComparison.Ordinal) > 0)
                    {
                        // swap temp and Teams[j]
                        var temp = Teams[j];
                        Teams[j] = Teams[j + 1];
                        Teams[j + 1] = temp;
                    }
                }
            }
        }
    }
}
