using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.IO;


namespace ParkingLibrary
{
    public static class Logger
    {
        static StreamWriter file;

        static Logger()
        {
            file = File.AppendText("Transactions.log");
            //if (!File.Exists("Transactions.log"))
            //{
            //    File.Create("Transactions.log");
            //}

            //var file = File.AppendText("Transactions.log");
            //file.Write(Date + " / " + Car.Id + " / " + Payment + " grn");
            // Console.WriteLine(Date + " / " + Car.Id + " / " + Payment + " grn");
        }

        public static void Write(string param1, string param2, string money)
        {
            file.Write(param1 + "/" + param2 + "/" + money + "grn");
        }


    }
}
