using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ЛР_10_1
{
    public class TeamJsonConverter : JsonConverter<Team>
    {
        public override Team Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                string type = root.GetProperty("type").GetString();
                string name = root.GetProperty("name").GetString();
                int wins = root.GetProperty("wins").GetInt32();
                int draws = root.GetProperty("draws").GetInt32();
                int losses = root.GetProperty("losses").GetInt32();

                return type switch
                {
                    "FootballTeam" => new FootballTeam(name, wins, draws, losses),
                    "BasketballTeam" => new BasketballTeam(name, wins, draws, losses),
                    "VolleyballTeam" => new VolleyballTeam(name, wins, draws, losses),
                    _ => throw new NotSupportedException($"Type '{type}' is not supported"),
                };
            }
        }

        public override void Write(Utf8JsonWriter writer, Team value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("type", value.GetType().Name);
            writer.WriteString("name", value.Name);
            writer.WriteNumber("wins", value.Wins);
            writer.WriteNumber("draws", value.Draws);
            writer.WriteNumber("losses", value.Losses);
            writer.WriteEndObject();
        }
    }
}
