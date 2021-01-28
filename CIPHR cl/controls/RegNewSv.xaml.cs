using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace CIPHR.controls
{
    /// <summary>
    /// Interaction logic for RegNewSv.xaml
    /// </summary>
    public partial class RegNewSv : Window
    {
        public RegNewSv()
        {
            InitializeComponent();
        }

        string cnstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\clservers.mdf;Integrated Security=True";

        private void RegSv(object sender, RoutedEventArgs e)
        {

            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

            try
            {
                clientSocket.Connect("127.0.0.1", 70);

                NetworkStream serverStream = clientSocket.GetStream();

                byte[] msg = Encoding.ASCII.GetBytes(String.Concat("[REGSV|" + svname.Text + ":" + MainWindow.Uname + "]"));

                serverStream.Write(msg, 0, msg.Length);
                serverStream.Flush();

                byte[] inStream = new byte[16];
                Int32 bytes = serverStream.Read(inStream, 0, inStream.Length);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream, 0, bytes);

                serverStream.Close();
                clientSocket.Close();

                if (returndata == "--[REGSVOK]--") {
                    this.Close();
                } else {
                    MainWindow.PopupMsg("Failed to register new server, please try again.");
                }
            } catch (Exception ex) {
                MainWindow.PopupMsg(ex.Message);
            }
        }
    }
}
