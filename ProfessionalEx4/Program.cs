//Завдання 4

//Створіть текстовий файл-чек на кшталт «Найменування товару – 0.00(ціна)грн.» 
//    з певною кількістю найменувань товарів та датою здійснення покупки.
//    Виведіть на екран інформацію з чека у форматі поточної локалі користувача та у форматі локалі en-US.
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ProfessionalEx4
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            Console.OutputEncoding = Encoding.Unicode;

            CultureInfo curentculture = CultureInfo.CurrentCulture;
            CultureInfo enculture = new CultureInfo("en-US");

            DateTime dateTime = DateTime.Now;

            string formatedDateForCurrent = dateTime.ToString("D", curentculture);
            string formatedDateForEn = dateTime.ToString("D", enculture);

            Dictionary<string, double> checkList = new Dictionary<string, double>();

            checkList.Add("Відеокарта MSI PCI-Ex GeForce GTX 1650 - ", 7299);
            checkList.Add("Блок живлення Aerocool VX Plus 400 400W - ", 999);
            checkList.Add("Материнська плата MSI B450 GAMING PLUS MAX - ", 4351);
            checkList.Add("Процесор Intel Core i9-12900KS 3.4GHz/30MB - ", 19949);
            checkList.Add("Оперативна пам'ять Goodram DDR4-2666 - ", 1149);
            checkList.Add("Монітор 28 Samsung Odyssey G7 - ", 19999);
            FileStream check = new FileStream("test.txt", FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(check);
            foreach (var item in checkList)
            {
                streamWriter.WriteLine(item.Key + item.Value);
            }
            streamWriter.WriteLine(dateTime);
            streamWriter.Close();

            foreach (var item in checkList)
            {
                Console.WriteLine(item.Key + item.Value.ToString("C",curentculture));
            }
            Console.WriteLine(dateTime.ToString(formatedDateForCurrent));

            Console.WriteLine(new string('-', 100));

            foreach (var item in checkList)
            {
                Console.WriteLine(item.Key + item.Value.ToString("C",enculture));
            }
            Console.WriteLine(dateTime.ToString(formatedDateForEn));
        }
    }
}