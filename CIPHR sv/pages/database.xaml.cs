﻿using System;
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

namespace CIPHR_server.pages
{
    /// <summary>
    /// Interaction logic for database.xaml
    /// </summary>
    public partial class database : UserControl
    {
        public database()
        {
            InitializeComponent();

            user_db_mgr xx = new user_db_mgr();
            xx.Show();
        }
    }
}
