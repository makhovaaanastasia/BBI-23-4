using System;
using System.Collections.Generic;

namespace ЛР_10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            TournamentTable[] tournaments = new TournamentTable[3];
            tournaments[0] = new TournamentTable("Football Tournament");
            tournaments[1] = new TournamentTable("Basketball Tournament");
            tournaments[2] = new TournamentTable("Volleyball Tournament");

            var footballTeams = new List<Team>
            {
                new FootballTeam("Tottenham"),
                new FootballTeam("Napoli"),
                new FootballTeam("PSG"),
                new FootballTeam("Barcelona"),
                new FootballTeam("Inter Milan"),
                new FootballTeam("Bayern Munich"),
                new FootballTeam("Liverpool"),
                new FootballTeam("Arsenal"),
                new FootballTeam("Real Madrid"),
                new FootballTeam("Manchester City")
            };

            var basketballTeams = new List<Team>
            {
                new BasketballTeam("Boston Celtics"),
                new BasketballTeam("Oklahoma City Thunder"),
                new BasketballTeam("Denver Nuggets"),
                new BasketballTeam("Minnesota Timberwolves"),
                new BasketballTeam("New York Knicks"),
                new BasketballTeam("Dallas Mavericks"),
                new BasketballTeam("Phoenix Suns"),
                new BasketballTeam("LA Clippers"),
                new BasketballTeam("Orlando Magic"),
                new BasketballTeam("Cleveland Cavaliers")
            };

            var volleyballTeams = new List<Team>
            {
                new VolleyballTeam("The Master's"),
                new VolleyballTeam("Park"),
                new VolleyballTeam("Vanguard"),
                new VolleyballTeam("Benedictine Mesa"),
                new VolleyballTeam("Grand View"),
                new VolleyballTeam("OUAZ"),
                new VolleyballTeam("Jamestown"),
                new VolleyballTeam("Menlo"),
                new VolleyballTeam("Penn"),
                new VolleyballTeam("Georgetown")
            };

            tournaments[0].Teams.AddRange(footballTeams);
            tournaments[1].Teams.AddRange(basketballTeams);
            tournaments[2].Teams.AddRange(volleyballTeams);

            MyJsonSerializer jsonSerializer = new MyJsonSerializer();
            jsonSerializer.Write(tournaments, "raw_data.json");

            Random random = new Random();
            foreach (var tournament in tournaments)
            {
                for (int i = 0; i < tournament.Teams.Count; i++)
                {
                    for (int j = i + 1; j < tournament.Teams.Count; j++)
                    {
                        int result = random.Next(3); // 0 = draw, 1 = team1 wins, 2 = team2 wins

                        if (result == 0)
                        {
                            tournament.Teams[i].Draws++;
                            tournament.Teams[j].Draws++;
                        }
                        else if (result == 1)
                        {
                            tournament.Teams[i].Wins++;
                            tournament.Teams[j].Losses++;
                        }
                        else
                        {
                            tournament.Teams[i].Losses++;
                            tournament.Teams[j].Wins++;
                        }
                    }
                }
            }

            jsonSerializer.Write(tournaments, "data.json");

            foreach (var tournament in tournaments)
            {
                tournament.Sort("points");
            }

            jsonSerializer.Write(tournaments, "sort_data.json");

            MyXmlSerializer xmlSerializer = new MyXmlSerializer();
            var sortedTournaments = tournaments.Select(t =>
            {
                t.Sort("points");
                var sortedTeams = t.Teams.GetRange(0, t.Teams.Count / 2);
                var newTournament = new TournamentTable(t.Name);
                newTournament.Teams.AddRange(sortedTeams);
                return newTournament;
            }).ToArray();

            xmlSerializer.Write(sortedTournaments, "raw_data.xml");

            foreach (var tournament in sortedTournaments)
            {
                for (int i = 0; i < tournament.Teams.Count; i++)
                {
                    for (int j = i + 1; j < tournament.Teams.Count; j++)
                    {
                        tournament.AddMatch(tournament.Teams[i], tournament.Teams[j]);
                    }
                }
            }

            xmlSerializer.Write(sortedTournaments, "data.xml");

            Console.WriteLine("Raw Data:");
            jsonSerializer.Read("raw_data.json");

            Console.WriteLine("\nData:");
            jsonSerializer.Read("data.json");

            Console.WriteLine("\nSorted Data:");
            jsonSerializer.Read("sort_data.json");

            Console.WriteLine("\nXML Data:");
            xmlSerializer.Read("raw_data.xml");

            Console.WriteLine("\nXML Sorted Data:");
            xmlSerializer.Read("data.xml");
        }
    }
}
