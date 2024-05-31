using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ЛР_10_1
{
    [XmlInclude(typeof(FootballTeam))]
    [XmlInclude(typeof(BasketballTeam))]
    [XmlInclude(typeof(VolleyballTeam))]
    public abstract class Team
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }

        public Team() { }  // Parameterless constructor for serialization

        public Team(string name, int wins = 0, int draws = 0, int losses = 0)
        {
            Name = name;
            Wins = wins;
            Draws = draws;
            Losses = losses;
        }

        public abstract int CalculatePoints();

        public override string ToString()
        {
            return $"{Name}: Points - {CalculatePoints()}, Wins - {Wins}, Draws - {Draws}, Losses - {Losses}";
        }
    }

    public class FootballTeam : Team
    {
        public FootballTeam() : base() { }
        public FootballTeam(string name, int wins = 0, int draws = 0, int losses = 0) : base(name, wins, draws, losses) { }

        public override int CalculatePoints()
        {
            return Wins * 3 + Draws;
        }
    }

    public class BasketballTeam : Team
    {
        public BasketballTeam() : base() { }
        public BasketballTeam(string name, int wins = 0, int draws = 0, int losses = 0) : base(name, wins, draws, losses) { }

        public override int CalculatePoints()
        {
            return Wins * 2 + Draws;
        }
    }

    public class VolleyballTeam : Team
    {
        public VolleyballTeam() : base() { }
        public VolleyballTeam(string name, int wins = 0, int draws = 0, int losses = 0) : base(name, wins, draws, losses) { }

        public override int CalculatePoints()
        {
            return Wins * 2 + Draws;
        }
    }
}
