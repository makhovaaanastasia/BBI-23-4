using System;
using System.IO;
using System.Text.Json;

namespace MySerializeLibrary
{
    public class MySerializeJson
    {
        public static void Serialize<T>(T data, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static T Deserialize<T>(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
