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

            if (String.Compare(cmd[0].Remove(0, 1), "REGU") == 0) {
                string[] ret = { cmd[0], data[0], data[1], data[2], data[3] };
                return ret;
            } else {
                string[] ret = { cmd[0], data[0], data[1] };
                return ret;
            }
        }

        public static void SendCLData(Socket cl, string str)
        {
            try
            {
                cl.Send(Encoding.ASCII.GetBytes(str));
                cl.Close();
            } catch( Exception e) {
                cPrint(e.ToString());
            }
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

                while (true) {
                    Socket handler = listener.Accept();
                    data = null;

                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    cPrint("incoming data package from client, data: " + data);
                    cPrint("---------PARSED DATA------------");
                    var pkg = ParseCmd(data); 
                    cPrint("NET CMD: " + pkg[0].Remove(0, 1));
                    cPrint("arg1: " + pkg[1]);
                    if(pkg.Length > 3) {
                        cPrint("arg2: " + pkg[2]);
                        cPrint("arg3: " + pkg[3]);
                        cPrint("arg4: " + pkg[4].Remove(pkg[4].Length - 1, 1));
                    } else {
                        cPrint("arg2: " + pkg[2].Remove(pkg[2].Length - 1, 1));
                    }                   

                    if (String.Compare(pkg[0].Remove(0, 1),"REGU") == 0) {
                        sv_netcmd.REG(handler, pkg[1], pkg[2], pkg[3], pkg[4]);
                    } else if (String.Compare(pkg[0].Remove(0, 1), "AUTH") == 0) {
                        sv_netcmd.AUTH(handler, pkg[1], pkg[2].Remove(pkg[2].Length - 1, 1));
                    } else if (String.Compare(pkg[0].Remove(0, 1), "REGSV") == 0) {  
                        sv_netcmd.CREATE(handler, pkg[1], pkg[2].Remove(pkg[2].Length - 1, 1));
                    }
                }
            } catch (Exception e) {
                cPrint(e.ToString());
            }
        }
    }
}
