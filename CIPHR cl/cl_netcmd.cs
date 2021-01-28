using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CIPHR
{
    class cl_netcmd
    {
        public static void PopupMsg(string str)
        {
            controls.PopUpMsgBox _pmsg = new controls.PopUpMsgBox();
            _pmsg.msg.Text = str;
            _pmsg.Show();
        }

        public static void GetCLServers(string u)
        {
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

            try {
                clientSocket.Connect("127.0.0.1", 70);

                NetworkStream serverStream = clientSocket.GetStream();

                byte[] msg = Encoding.ASCII.GetBytes(String.Concat("[GETCLSV|" + u + ":" +  "svcheck" + "]"));

                serverStream.Write(msg, 0, msg.Length);
                serverStream.Flush();

                byte[] inStream = new byte[16];
                Int32 bytes = serverStream.Read(inStream, 0, inStream.Length);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream, 0, bytes);

                serverStream.Close();
                clientSocket.Close();

                //PopupMsg
            } catch (Exception ex) {
                PopupMsg(ex.Message);
            }
        }
    }
}
