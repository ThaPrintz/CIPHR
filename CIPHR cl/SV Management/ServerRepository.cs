using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHR.SV_Management
{
    public class ServerRepository : ICServerRepo
    {
        private string cnstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\clservers.mdf;Integrated Security=True";

        public async Task<bool> Create(cserver sv)
        {
            using (IDbConnection db = new SqlConnection(cnstr)) {
                var result = await db.ExecuteAsync(CIPHR.Properties.Resources.InsertSV, new { Sv_name = sv.Sv_name, Ownername = sv.owner, tch = sv.tchan, vch = sv.vchan, mbrs = sv.users, rnks = sv.ranks });

                return result > 0;
            }
        }

        public async Task<bool> Delete(cserver sv)
        {
            using (IDbConnection db = new SqlConnection(cnstr)) {
                //var result = await db.ExecuteAsync(CIPHR_server.Properties.Resources.DeleteSVTable, new { Sv_name = sv.Sv_name });

                return true;
            }
        }

        public async Task<bool> Validate(cserver sv)
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
