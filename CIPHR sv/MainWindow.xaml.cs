using CIPHR_server.controls;
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

namespace CIPHR_server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static serverConsole _con = new serverConsole();

        public MainWindow()
        {
            InitializeComponent();

            GridMain.Children.Add(new pages.server());
            _con.clog("testing");
        }

        public static void cprint(String std)
        {
            MainWindow._con.clog(std);
        }

        private void _gmd(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(231 + (160 * index), 45, 0, 0);

            switch (index)
            {
                case 0:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new pages.server());

                    break;
                case 1:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new pages.settings());

                    break;
                case 2:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(_con);

                    break;
                case 3:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new pages.logs());

                    break;
                case 4:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new pages.database());

                    break;
            }
        }
    }
}
