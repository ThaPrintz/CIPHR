using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHR_server
{
    public class UserRepository : CUserRepo
    {
        private string cnstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ciphr_users.mdf;Integrated Security=True";

        public async Task<bool> Insert(cuser user)
        {
            using(IDbConnection db = new SqlConnection(cnstr))
            {
                var result = await db.ExecuteAsync(CIPHR_server.Properties.Resources.InsertUser, new { Username = user.Username, Password = user.Password });
                
                return result > 0;
            }
        }
    }
}
