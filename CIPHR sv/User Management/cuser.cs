using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CIPHR_server
{
    public class cuser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Emailadd { get; set; }
        public string Phonenumber { get; set; }
        public Socket _clhandle { get; set; }
    }
}
