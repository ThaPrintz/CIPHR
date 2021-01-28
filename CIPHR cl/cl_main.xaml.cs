using CIPHR.controls;
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

namespace CIPHR
{
    /// <summary>
    /// Interaction logic for cl_main.xaml
    /// </summary>
    public partial class cl_main : Window
    {
        public cl_main()
        {
            InitializeComponent();

            var _ctxm = new cl_main_ctxm();
            _ctxm.Show();

            var svbtn = new ServerButton();
            svbtn.btnimg.Source = new BitmapImage(new Uri("C:\\Users\\Printz\\Desktop\\CIPHR\\CIPHR cl\\clg.png"));
  
            svgrid.Children.Add(svbtn);
        }

        private void _gmd(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void RegSvM(object sender, RoutedEventArgs e)
        {
            RegNewSv _sv = new RegNewSv();
            _sv.Show();
        }
    }
}
