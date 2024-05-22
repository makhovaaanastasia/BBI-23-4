// using System;
// using System.IO;
// using System.Text.Json;
// using System.Text.Json.Serialization;

// namespace Serializer
// {
//     public class MyJsonSerializer
//     {
//         public static void SerializeToFile<T>(T obj, string filePath)
//         {
//             var options = new JsonSerializerOptions { WriteIndented = true };
//             string jsonString = JsonSerializer.Serialize(obj, options);
//             File.WriteAllText(filePath, jsonString);
//         }

//         public static T DeserializeFromFile<T>(string filePath)
//         {
//             string jsonString = File.ReadAllText(filePath);
//             return JsonSerializer.Deserialize<T>(jsonString);
//         }
//     }
// }
