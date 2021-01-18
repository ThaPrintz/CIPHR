using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHR_server.SV_Interface
{
    public class ServerRepository : CServerRepo
    {
        private string cnstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ciphr_users.mdf;Integrated Security=True";

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
                var result = await db.ExecuteAsync(CIPHR_server.Properties.Resources.InsertUser, new { Username = user.Username, Password = user.Password });

                return result > 0;
            }
        }

        public async Task<bool> Delete(csv_struct sv) { }

        public async Task<bool> Validate(csv_struct sv) { }
    }
}
