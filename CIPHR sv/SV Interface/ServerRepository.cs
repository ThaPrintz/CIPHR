using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHR_server.SV_Interface
{
    public class ServerRepository : ICServerRepo
    {
        private string cnstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ciphr_servers.mdf;Integrated Security=True";

        public static void cPrint(String std)
        {
            MainWindow._con.Dispatcher.Invoke(() =>
            {
                MainWindow._con.clog(std);
            });
        }

        public async Task<bool> Create(csv_struct sv) 
        {
            using (IDbConnection db = new SqlConnection(cnstr))
            {
                var result = await db.ExecuteAsync(CIPHR_server.Properties.Resources.InsertServer, new { Sv_name = sv.Sv_name, Ownername = sv.owner, tch = sv.tchan, vch = sv.vchan, mbrs = sv.users, rnks = sv.ranks });

                return result > 0;
            }
        }

        public async Task<bool> Delete(csv_struct sv) 
        {
            using (IDbConnection db = new SqlConnection(cnstr))
            {
                var result = await db.ExecuteAsync(CIPHR_server.Properties.Resources.DeleteSVTable, new { Sv_name = sv.Sv_name });
  
                return result > 0;
            }
        }

        public async Task<bool> Validate(csv_struct sv)
        {
            
            /*
            using (SqlConnection db = new SqlConnection(cnstr))
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Users WHERE username='" + user.Username + "' AND password='" + user.Password + "'", db);

                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1") {
                    return true;
                } else {
                    return false;
                }
            }*/
            return true;
        }
    }
}
