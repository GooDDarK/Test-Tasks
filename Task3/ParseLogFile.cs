using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Task3
{
    public static class ParseLogFile
    {
        public static bool TryParseFormat(string line, out LogEntry logEntry)
        {
            // Формат 1: 10.03.2025 15:14:49.523 INFORMATION Версия программы: '3.4.0.48729'
            var pattern1 = @"^(?<Date>\d{2}\.\d{2}\.\d{4})\s+(?<Time>\d{2}:\d{2}:\d{2}\.\d+)\s+(?<Level>\w+)\s+(?<Message>.*)$";
            // Формат 2: 2025-03-10 15:14:51.5882| INFO|11|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'
            var pattern2 = @"^(?<Date>\d{4}-\d{2}-\d{2})\s+(?<Time>\d{2}:\d{2}:\d{2}\.\d+)\s*\|\s*(?<Level>\w+)\s*\|\s*\d+\s+(?<Method>[\w.]+)\s*\|\s*(?<Message>.*)$";
            var match1 = Regex.Match(line, pattern1);
            var match2 = Regex.Match(line, pattern2);

            if (match1.Success)
            {
                try
                {
                    DateTime date = DateTime.ParseExact(match1.Groups[1].Value, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    string time = match1.Groups[2].Value;
                    string level = match1.Groups[3].Value;
                    string message = match1.Groups[4].Value;

                    logEntry = new LogEntry
                    {
                        Date = date,
                        Time = time,
                        LogLevel = level,
                        CallingMethod = "DEFAULT",
                        Message = message
                    };
                    return true;
                }
                catch
                {
                    // Если не удалось распарсить дату
                }
            }
            else if (match2.Success)
            {
                try
                {
                    DateTime date = DateTime.ParseExact(match2.Groups[1].Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string time = match2.Groups[2].Value;
                    string level = match2.Groups[3].Value;
                    string method = match2.Groups[4].Value.Trim();
                    string message = match2.Groups[5].Value.Trim();

                    logEntry = new LogEntry
                    {
                        Date = date,
                        Time = time,
                        LogLevel = level,
                        CallingMethod = method,
                        Message = message
                    };
                    return true;
                }
                catch
                {
                    // Если не удалось распарсить дату
                }
            }

            logEntry = null;
            return false;
        }

        public static void WriteStandardizedLog(StreamWriter writer, LogEntry logEntry)
        {
            // Преобразуем уровень логирования
            string standardizedLevel = logEntry.LogLevel.Replace("INFORMATION", "INFO");
            standardizedLevel = logEntry.LogLevel.Replace("WARNING", "WARN");

            // Форматируем дату в DD-MM-YYYY
            string formattedDate = logEntry.Date.ToString("dd-MM-yyyy");

            // Записываем в выходной файл с разделителями табуляции
            writer.WriteLine(formattedDate);
            writer.WriteLine(logEntry.Time);
            writer.WriteLine(standardizedLevel);
            writer.WriteLine(logEntry.CallingMethod);
            writer.WriteLine(logEntry.Message);
            writer.WriteLine(); // Пустая строка между записями
        }
    }
}
