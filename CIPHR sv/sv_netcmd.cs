using CIPHR_server.UserInfoDataSetTableAdapters;
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
            CUserRepo repository = new UserRepository();
            bool result = await repository.Check(new cuser() { Username = u, Password = p, _clhandle = cl });

            if (result) {
                cPrint("user '" + u + "' authorized for login");

                cserver.SendCLData(cl, "--[AUTHOK]--");
            }  else {
                cPrint("Failed to authorize user '" + u + "'");

                cserver.SendCLData(cl, "--[AUTHNO]--");
            }
        }

        public static async void REG(Socket cl, string u, string p)
        {
            CUserRepo repository = new UserRepository();
            bool result = await repository.Insert(new cuser() { Username = u, Password = p, _clhandle = cl });

            if (result) {
                cPrint("new user registered with username '" + u + "' and password '" + p + "'");
            } else {
                cPrint("Error registering user '" + u + "'");
            }
        }
    
    }
}
