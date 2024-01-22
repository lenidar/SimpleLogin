using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogin
{
    internal class FileManipulators
    {
        public List<string> FileRead(string filePath)
        {
            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        public void FileWrite(List<string> thingToWrite, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (string line in thingToWrite)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}
