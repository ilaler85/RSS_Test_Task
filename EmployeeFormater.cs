using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS1;
public static class EmployeeFormatter
{
    public static string FormatPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length != 11 || !phoneNumber.StartsWith("7")) return phoneNumber; //Обработка некорректных номеров
        return $"+7({phoneNumber.Substring(1, 3)}){phoneNumber.Substring(4, 3)}-{phoneNumber.Substring(7, 2)}-{phoneNumber.Substring(9, 2)}";
    }

    public static string FormatSalary(int salary)
    {
        return salary.ToString("N0") + " р.";
    }
}