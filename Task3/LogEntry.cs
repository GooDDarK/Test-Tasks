using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class LogEntry
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string LogLevel { get; set; }
        public string CallingMethod { get; set; }
        public string Message { get; set; }
    }
}
