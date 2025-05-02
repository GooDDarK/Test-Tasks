using System;
using System.Threading;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Используйте команду GetCount, чтобы прочитать переменную \"count\". Ее можно использовать параллельно.\nИспользуйте команду AddToCount \"цифра\", чтобы добавить значение к переменной \"count\". Ее нельзя использовать одновременно!");

            string userText = Console.ReadLine();

            if (userText == "GetCount")
            {
                int serverCount = Server.GetCount();

                Console.WriteLine("count = " + serverCount);
            }

            if (userText.Contains("AddToCount"))
            {
                string stringValue = userText.Replace("AddToCount", "").Trim();

                if (stringValue == "")
                {
                    Console.WriteLine("Укажите на сколько нужно увеличить значение \"count\"");

                    stringValue = Console.ReadLine();

                    if (stringValue == "")
                        return;
                }

                int addValue = int.Parse(stringValue);

                Server.AddToCount(addValue);

                Console.WriteLine("Переменная \"count\" увеличена на " + addValue);
            }

            Console.ReadLine();
        }
    }
}
