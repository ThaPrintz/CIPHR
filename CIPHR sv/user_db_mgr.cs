using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIPHR_server
{
    public partial class user_db_mgr : Form
    {
        public user_db_mgr()
        {
            InitializeComponent();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.userInfoDataSet);

        }

        private void user_db_mgr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userInfoDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.userInfoDataSet.Users);

        }
    }
}
