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

        private void AuthLogin(object sender, RoutedEventArgs e)
        {
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

            try
            {
                clientSocket.Connect("127.0.0.1", 70);

                NetworkStream serverStream = clientSocket.GetStream();

                byte[] msg = Encoding.ASCII.GetBytes("[LOGIN_AUTH]username:password");

                serverStream.Write(msg, 0, msg.Length);
                serverStream.Flush();
            } catch ( Exception ex) {

            }
        }
    }
}
