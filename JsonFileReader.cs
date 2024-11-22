using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RSS1;
public static class JsonFileReader
{
    public static T DeserializeJsonToList<T>(string path)
    {
        try
        {
            string jsonString = File.ReadAllText(path);
            T employees = default;
            employees = JsonConvert.DeserializeObject<T>(jsonString);

            if (employees == null)
            {
                Console.WriteLine("Ошибка при разборе JSON.");
                return default;
            }
            else
                return employees;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Файл {path} не найден.");
            return default;
        }
        catch (JsonReaderException ex)
        {
            Console.WriteLine($"Ошибка при разборе JSON: {ex.Message}");
            return default;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
            return default;
        }
    }
}
