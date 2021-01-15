using CIPHR_server.UserInfoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public int AUTH(string u, string p)
        {
            UserInfoDataSetTableAdapters.UsersTableAdapter _userAdap = new UsersTableAdapter();
            UserInfoDataSet _dataSet = new UserInfoDataSet();

            _userAdap.Fill(_dataSet.Users);

            return 0;
        }

        public static async void REG(string u, string p)
        {
            CUserRepo repository = new UserRepository();
            bool result = await repository.Insert(new cuser() { Username = u, Password = p });

            if (result) {
                cPrint("new user registered with username '" + u + "' and password '" + p + "'");
            } else {
                cPrint("Error registering user '" + u + "'");
            }
        }
    
    }
}
