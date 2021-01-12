using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Automation.Peers;

namespace CIPHR_server
{
    class cserver
    {
        public static string data = null;

        public static void cPrint(String std)
        {
            MainWindow._con.Dispatcher.Invoke(() =>
            {
                MainWindow._con.clog(std);
            });
        }

        public static string[] ParseCmd(string ccmd)
        {
            var cmd = ccmd.Split('|');
            var data = cmd[1].Split(':');

            string[] ret = {cmd[0], data[0], data[1] };

            return ret;
        }

        public static void Start()
        {
            byte[] bytes = new Byte[1024];

            IPAddress ipAdress = IPAddress.Parse("0.0.0.0");
            IPEndPoint localEndPoint = new IPEndPoint(ipAdress, 70);

            Socket listener = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(20);

                while (true)
                {
                    Socket handler = listener.Accept();
                    data = null;

                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    var pkg = ParseCmd(data);
                    cPrint("NET CMD: " + pkg[0].Remove(0, 1));
                    cPrint("arg1: " + pkg[1]);
                    cPrint("arg2: " + pkg[2].Remove(pkg[2].Length-1, 1));
                }
            }
            catch (Exception e)
            {
               
            }
        }
    }
}
