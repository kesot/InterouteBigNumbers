using System.Collections.Generic;
using System.IO;

namespace BigNumbersMVC.Model
{
    public class LogReader : ILogReader
    {
        private string fileName;

        public LogReader(string fileName)
        {
            this.fileName = fileName;
        }

        public string[] ReadAll()
        {
            if (!File.Exists(fileName))
                return new string[0];
            return File.ReadAllLines(fileName);
        }
    }
}