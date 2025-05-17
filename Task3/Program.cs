using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = AppContext.BaseDirectory + "input.log";
            string outputFilePath = AppContext.BaseDirectory + "output.log";
            string problemFilePath = AppContext.BaseDirectory + "problems.txt";

            Console.WriteLine("Программа стандартизации лог-файлов");

            try
            {
                ProcessLogFile(inputFilePath, outputFilePath);
                Console.WriteLine("Обработка завершена успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadLine();
        }

        static void ProcessLogFile(string inputPath, string outputPath)
        {
            string problemsPath = AppContext.BaseDirectory + "problems.txt";

            using (StreamReader reader = new StreamReader(inputPath))
            using (StreamWriter writer = new StreamWriter(outputPath))
            using (StreamWriter problemsWriter = new StreamWriter(problemsPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (ParseLogFile.TryParseFormat(line, out var logEntry))
                    {
                        ParseLogFile.WriteStandardizedLog(writer, logEntry);
                    }
                    else
                    {
                        problemsWriter.WriteLine(line);
                    }
                }
            }
        }
    }
}
