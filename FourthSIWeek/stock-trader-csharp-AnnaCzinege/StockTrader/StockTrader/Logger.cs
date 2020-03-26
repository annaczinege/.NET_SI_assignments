using System;
using System.IO;

namespace stockTrader
{
    public class Logger
    {

        private static Logger _instance;

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        public void Log(string message) {
            var msg = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " " + message;
            Console.WriteLine(msg);
            try
            {
                using (var fileWriter = File.AppendText("log.txt"))  {
                    fileWriter.WriteLine(msg);
                }    
            }
            catch (IOException e) {
                Console.WriteLine("Log file write failed :( " + e);
            }

        }        
    }
}