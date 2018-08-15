namespace Helpers
{
    public class LogsHelper
    {
        public string LogEntry { get; set; }
        public LogTypes LogTypes { get; set; }

        public void AddNewLogEntry (string str, LogTypes logTypes = LogTypes.Usual)
        {
            LogTypes = logTypes;
            LogEntry = str;
        }
    }
}
