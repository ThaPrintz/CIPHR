using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace CIPHR
{
    /// <summary>
    /// Interaction logic for cl_register.xaml
    /// </summary>
    public partial class cl_register : Window
    {
        public cl_register()
        {
            InitializeComponent();
        }

        private void regscr_close(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void RegUser(object sender, RoutedEventArgs e)
        {
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

            try
            {
                clientSocket.Connect("127.0.0.1", 70);

                NetworkStream serverStream = clientSocket.GetStream();

                byte[] msg = Encoding.ASCII.GetBytes(String.Concat("[REGU|" + uname.Text + ":" + pword.Password + "]"));

                serverStream.Write(msg, 0, msg.Length);
                serverStream.Flush();

                serverStream.Close();
                clientSocket.Close();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
