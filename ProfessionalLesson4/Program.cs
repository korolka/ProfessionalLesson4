//Завдання 2

//Напишіть програму, яка дозволила б за вказаною адресою web-сторінки вибирати
//    всі посилання на інші сторінки, номери телефонів, поштові адреси та зберігала отриманий результат у файл.
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ProfessionalLesson4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string htmlContent = new System.Net.WebClient().DownloadString(@"https://shop.kyivstar.ua/pick-number#similar");
            string paternForLinks = @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})";
            string paternForPhoneNumber = "\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}";
            string paternForEmail = "@\"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$\"";

            Regex regexForLinks = new Regex(paternForLinks);
            Regex regexForPhoneNumber = new Regex(paternForPhoneNumber);
            Regex regexForEmail = new Regex(paternForEmail);

            FileInfo file= new FileInfo(@"C:\TESTDIR\result.txt");
            FileStream fileStream = file.Create();

            StreamWriter streamWriter= new StreamWriter(fileStream);
            for (Match m = regexForLinks.Match(htmlContent); m.Success; m = m.NextMatch())
            {
                streamWriter.WriteLine("ССЫЛКА: {0,-25}", m);
            }
            streamWriter.WriteLine(new string('-' , 100));

            for (Match m = regexForPhoneNumber.Match(htmlContent); m.Success; m = m.NextMatch())
            {
                streamWriter.WriteLine("Номер: {0}", m);
                Console.WriteLine(m);
            }
            streamWriter.WriteLine(new string('-', 100));

            for (Match m = regexForEmail.Match(htmlContent); m.Success; m = m.NextMatch())
            {
                streamWriter.WriteLine("Email: {0}", m);
                Console.WriteLine(m);
            }
            streamWriter.Close();

            
        }
    }
}