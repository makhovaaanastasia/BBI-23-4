// using System;
// using System.IO;
// using System.Text.Json;

// namespace SerializationLib
// {
//     public class MyJsonSerializer
//     {
//         public static void Serialize<T>(T obj, string filePath)
//         {
//             var options = new JsonSerializerOptions { WriteIndented = true };
//             string jsonString = JsonSerializer.Serialize(obj, options);
//             File.WriteAllText(filePath, jsonString);
//         }

//         public static T Deserialize<T>(string filePath)
//         {
//             string jsonString = File.ReadAllText(filePath);
//             return JsonSerializer.Deserialize<T>(jsonString);
//         }
//     }
// }
