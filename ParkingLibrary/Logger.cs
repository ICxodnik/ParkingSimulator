using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.IO;


namespace ParkingLibrary
{
    public class Logger : IDisposable
    {
        StreamWriter writer;
        FileStream file;
        string _fileName;

        public Logger(string filename)
        {
            _fileName = filename;
            file = File.Open(_fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            file.Seek(0, SeekOrigin.End);
            writer = new StreamWriter(file);
            writer.AutoFlush = true;
        }

        public void WriteLine(string line)
        {
            writer.Write(line + "\r\n");
        }

        public string GetContent()
        {
            lock (file)
            {
                file.Seek(0, SeekOrigin.Begin);
                try
                {
                    return new StreamReader(file).ReadToEnd();
                }
                finally
                {
                    file.Seek(0, SeekOrigin.End);
                }
            }
        }

        public void Dispose()
        {
            file.Close();
        }
    }
}
