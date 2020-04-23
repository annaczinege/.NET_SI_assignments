using System;
using System.Diagnostics;

namespace AppEventLog
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!EventLog.SourceExists("Demo", "DESKTOP-L1DHLM2"))
            {
                EventLog.CreateEventSource("Demo", "Application", "DESKTOP-L1DHLM2");
            }
            EventLog logDemo = new EventLog("Application", "DESKTOP-L1DHLM2", "Demo");
            logDemo.WriteEntry("Event Written to Application Log",
                              EventLogEntryType.Information,
                              234,
                              Convert.ToInt16(3));
        }
    }
}
