using CIPHR_server.SV_Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CIPHR_server
{
    public class sv_netcmd
    {
        public static void cPrint(String std)
        {
            MainWindow._con.Dispatcher.Invoke(() =>
            {
                MainWindow._con.clog(std);
            });
        }

        public static async void AUTH(Socket cl, string u, string p)
        {
            ICUserRepo repository = new UserRepository();
            bool result = await repository.Check(new cuser() { Username = u, Password = p, _clhandle = cl });

            if (result) {
                cPrint("user '" + u + "' authorized for login");

                cserver.SendCLData(cl, "--[AUTHOK]--");
            }  else {
                cPrint("Failed to authorize user '" + u + "'");

                cserver.SendCLData(cl, "--[AUTHNO]--");
            }
        }

        public static async void REG(Socket cl, string u, string p, string e, string ph)
        {
            ICUserRepo repository = new UserRepository();
            bool result = await repository.Insert(new cuser() { Username = u, Password = p, _clhandle = cl, Emailadd = e, Phonenumber = ph });

            if (result) {
                cPrint("new user registered with username '" + u + "' and password '" + p + "'");

                cserver.SendCLData(cl, "--[REGOK]--");
            } else {
                cPrint("Error registering user '" + u + "'");

                cserver.SendCLData(cl, "--[REGNO]--");
            }
        }

        public static async void CREATE(Socket cl, string svid, string ownerid)
        {
            ICServerRepo repository = new ServerRepository();
            bool result = await repository.Create(new csv_struct() { Sv_name = svid, owner = ownerid, ranks = "owner;user;guest", tchan = "general;", vchan = "general;AFK", users = ownerid });

            if (result) {
                cPrint("new server registered with name '" + svid + "'");

                cserver.SendCLData(cl, "--[REGSVOK]--");
            } else {
                cPrint("Error registering server '" + svid + "'");

                cserver.SendCLData(cl, "--[REGSVNO]--");
            }
        }
    }
}
