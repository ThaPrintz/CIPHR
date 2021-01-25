using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace CIPHR_server
{
    public class UserRepository : ICUserRepo
    {
        private string cnstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ciphr_users.mdf;Integrated Security=True";

        public static void cPrint(String std)
        {
            MainWindow._con.Dispatcher.Invoke(() =>
            {
                MainWindow._con.clog(std);
            });
        }

        public async Task<bool> Insert(cuser user)
        {
            using(IDbConnection db = new SqlConnection(cnstr))
            {
                var result = await db.ExecuteAsync(CIPHR_server.Properties.Resources.InsertUser, new { Username = user.Username, Password = user.Password, Email = user.Emailadd, Phonenum = user.Phonenumber });
                
                return result > 0;
            }
        }

        public async Task<bool> Check(cuser user)
        {
            using (SqlConnection db = new SqlConnection(cnstr))
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM cUsers WHERE username='" + user.Username + "' AND password='" + user.Password + "'", db);

                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    return true;
                } else { 
                    return false;
                }
            }
        }
    }
}
