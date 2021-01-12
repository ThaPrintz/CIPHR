using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CIPHR_server.pages
{
    /// <summary>
    /// Interaction logic for server.xaml
    /// </summary>
    public partial class server : UserControl
    {
        public server()
        {
            InitializeComponent();
        }

        private void Startsv(object sender, RoutedEventArgs e)
        {
            MainWindow.cprint("server launched");

            Thread _DT = new Thread(new ThreadStart(cserver.Start));
            _DT.SetApartmentState(ApartmentState.STA);
            _DT.Start();
        }
    }
}
