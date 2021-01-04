using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;

namespace CIPHR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pb_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            var _regscr = new cl_register();
            _regscr.Show();
        }

        private void AuthLogin(object sender, RoutedEventArgs e)
        {
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

            try
            {
                clientSocket.Connect("127.0.0.1", 70);

                NetworkStream serverStream = clientSocket.GetStream();

                byte[] msg = Encoding.ASCII.GetBytes(String.Concat("[AUTH|" + uname.Text + ":" + pword.Password + "]"));

                serverStream.Write(msg, 0, msg.Length);
                serverStream.Flush();

                byte[] inStream = new byte[16];
                Int32 bytes = serverStream.Read(inStream, 0, inStream.Length);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream, 0, bytes);

                serverStream.Close();
                clientSocket.Close();

                if (returndata == "--[AUTHOK]--")
                {
                    this.Hide();
                    var mainapp = new cl_main();
                    mainapp.Closed += (s, args) => this.Close();
                    mainapp.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
            } catch ( Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
