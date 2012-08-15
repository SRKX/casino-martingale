using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RouletteSim
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn_man_Click(object sender, RoutedEventArgs e)
        {
            Window1 ms = new Window1();
            ms.ShowDialog();
        }

        private void btn_auto_Click(object sender, RoutedEventArgs e)
        {
            AutoSim aSim = new AutoSim();
            aSim.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_wealth.Text = Properties.Settings.Default.InitWealth.ToString();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.InitWealth = Convert.ToDouble(txt_wealth.Text);
            Properties.Settings.Default.Save();
        }
    }
}
