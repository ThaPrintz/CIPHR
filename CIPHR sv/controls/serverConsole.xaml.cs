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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CIPHR_server.controls
{
    /// <summary>
    /// Interaction logic for serverConsole.xaml
    /// </summary>
    public partial class serverConsole : UserControl
    {
        public serverConsole()
        {
            InitializeComponent();
        }

        public void clog(String msg)
        {
            var _pt = new ConLogMsg();
            _pt.Msgg.Text = msg;

            ConGrid.Children.Add(_pt);
        }
    }
}
