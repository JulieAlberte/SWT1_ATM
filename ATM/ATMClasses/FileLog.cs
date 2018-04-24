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

        public FileLog(string filePath = @"C:\Log.Txt") 
            => FilePath = filePath;

        public void LogToFile(List<SeperationEventData> seperationList)
        {
            string path = @"C:\Temp\Logfile.txt";
            for (int i = 0; i < seperationList.Count; i++)
            {
                string text = "Planes in conflict: " + seperationList[i].TAG1 + " and " + seperationList[i].TAG2 +
                              "\nTime of occurance: " + seperationList[i].TimeOfEvent;
                File.WriteAllText(path, text);
            }

            //Writes every object in seperationEvents list into a file, per default "Log.txt"
            //if (!File.Exists(FilePath))
            //{
            //    using (StreamWriter file = File.CreateText(FilePath))
            //    {
            //        for (int i = 0; i < seperationList.Count; i++)
            //        {
            //            file.WriteLine(seperationList[i]);
            //        }
            //    }
            //}
            //else
            //{
            //    using (StreamWriter file = new StreamWriter(FilePath))
            //    {
            //        for (int i = 0; i < seperationList.Count; i++)
            //        {
            //            file.WriteLine(seperationList[i]);
            //        }
            //    }
            //}
        }
    }
}
