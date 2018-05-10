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
        StreamWriter file;

        public Logger(string filename)
        {
            file = File.AppendText(filename);
        }

        public void WriteLine(string line)
        {
            file.Write(line + "\n");
        }

        public void Dispose()
        {
            file.Close();
        }
    }
}
