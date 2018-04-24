using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Interfaces;

namespace ATMClasses
{
    public class FileLog: IFileLog
    {
        public string FilePath { get; set; }

        public FileLog(string filePath = @"Log.Txt") => FilePath = filePath;
        public void LogToFile(List<SeperationEvent> seperationEvents)
        {
            //Writes every object in seperationEvents list into a file, per default "Log.txt"
            using (StreamWriter file = new StreamWriter(FilePath, true))
            {
                for(int i = 0; i < seperationEvents.Count; i++)
                {
                    file.WriteLine(i);
                }
            }
        }
    }
}
