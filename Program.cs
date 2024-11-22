using System.Globalization;
using Newtonsoft.Json; 

namespace RSS1;


internal class Program
{
    public static List<Employee> employees  =new List<Employee>();
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь файла .json");
        bool flag = false;
        string filePath = "";
        while (!flag)
        {
            filePath = Console.ReadLine();
            if (filePath == null)
            {
                Console.WriteLine("Путь файла пустой");
                continue;
            }

            if (filePath.Contains(".json"))
                flag = true;
            else
                Console.WriteLine("Файл не в формате json");

        }
         
        employees = JsonFileReader.DeserializeJsonToList<List<Employee>>(filePath);

        //Обработка исключений при преобразовании salary в int.
        var employeesWithParsedSalary = employees.Select(e =>
        {
            if (int.TryParse(e.salary.ToString(), out int parsedSalary))
            {
                return new Employee { name = e.name, phoneNumber = e.phoneNumber, salary = parsedSalary };
            }
            else
            {
                Console.WriteLine($"Ошибка преобразования зарплаты для сотрудника {e.name}. Зарплата пропущена.");
                return null;
            }
        }).Where(e => e != null).ToList();

        var top20Employees = employeesWithParsedSalary.OrderByDescending(e => e.salary).Take(20);

        foreach (var employee in top20Employees)
        {
            string formattedPhoneNumber = EmployeeFormatter.FormatPhoneNumber(employee.phoneNumber);
            string formattedSalary = EmployeeFormatter.FormatSalary(employee.salary);
            Console.WriteLine($"{employee.name} {formattedPhoneNumber}, {formattedSalary}");
        } 
    }
}
