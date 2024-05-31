using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace ЛР_10_1
{
    public abstract class MySerializer
    {
        public abstract void Read(string filePath);
        public abstract void Write(TournamentTable[] tables, string filePath);
    }

    public class MyJsonSerializer : MySerializer
    {
        public override void Read(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                Converters =
                {
                    new TeamJsonConverter()  // Custom converter for Team base class
                }
            };
            TournamentTable[]? tables = JsonSerializer.Deserialize<TournamentTable[]>(jsonString, options);
            if (tables != null)
            {
                foreach (var table in tables)
                {
                    Console.WriteLine(table);
                }
            }
        }

        public override void Write(TournamentTable[] tables, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IncludeFields = true,
                Converters =
                {
                    new TeamJsonConverter()  // Custom converter for Team base class
                }
            };
            string jsonString = JsonSerializer.Serialize(tables, options);
            File.WriteAllText(filePath, jsonString);
        }
    }

    public class MyXmlSerializer : MySerializer
    {
        public override void Read(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TournamentTable[]), new Type[] { typeof(FootballTeam), typeof(BasketballTeam), typeof(VolleyballTeam) });
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                TournamentTable[]? tables = (TournamentTable[])xmlSerializer.Deserialize(fs);
                if (tables != null)
                {
                    foreach (var table in tables)
                    {
                        Console.WriteLine(table);
                    }
                }
            }
        }

        public override void Write(TournamentTable[] tables, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TournamentTable[]), new Type[] { typeof(FootballTeam), typeof(BasketballTeam), typeof(VolleyballTeam) });
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, tables);
            }
        }
    }
}
