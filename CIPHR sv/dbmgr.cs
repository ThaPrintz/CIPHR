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
    public partial class dbmgr : Form
    {
        public dbmgr()
        {
            InitializeComponent();
        }

        private void cServersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cServersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ciphr_serversDataSet);

        }

        private void dbmgr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ciphr_usersDataSet.cUsers' table. You can move, or remove it, as needed.
            this.cUsersTableAdapter.Fill(this.ciphr_usersDataSet.cUsers);
            // TODO: This line of code loads data into the 'ciphr_serversDataSet.cServers' table. You can move, or remove it, as needed.
            this.cServersTableAdapter.Fill(this.ciphr_serversDataSet.cServers);

        }
    }
}
