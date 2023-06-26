//Завдання 3

//Напишіть жартівливу програму «Дешифратор», яка в текстовому файлі могла б замінити всі прийменники словом «ГАВ!».
using System.Text;
using System.Text.RegularExpressions;

namespace ProfessionalEx3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            string filePath = "test.txt";
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine("Before chaging");

            Console.WriteLine(fileContent);

            string result = Regex.Replace(fileContent.ToLower(), @"\b(по|за|у|в|на|від|при|під|перед|через|над|зі|після|всередині|навколо|для|про|біля|згідно|насупроти|біля|поміж|поперек|вздовж|проти|через|уздовж|уві|поза|уві|відповідно|між|поміж|без)\b", "ГАВ!");

            Console.WriteLine(result);
        }
    }
}