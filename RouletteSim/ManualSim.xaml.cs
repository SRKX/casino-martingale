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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RouletteSim
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Roulette _RGame;
        private MartStrategy _MStrat = new MartStrategy(5, 250, Properties.Settings.Default.InitWealth);

        public Window1()
        {
            InitializeComponent();
            _RGame = new Roulette();
        }

        private void SetRes(Number res)
        {
            ListBoxItem it = new ListBoxItem();
            it.Content = res;
            it.Foreground = Brushes.White;
            switch (res.Color)
            {
                case NumberColor.None:
                    it.Background = Brushes.Green;
                    break;
                case NumberColor.Red:
                    it.Background = Brushes.Red;
                    break;
                case NumberColor.Black:
                    it.Background = Brushes.Black;
                    break;
                default:
                    break;
            }
            lst_history.Items.Add(it);
            lst_history.ScrollIntoView(lst_history.Items[lst_history.Items.Count - 1]);

            switch (res.Color)
            {
                case NumberColor.None:
                    lbl_res.Background = Brushes.Green;
                    break;
                case NumberColor.Red:
                    lbl_res.Background = Brushes.Red;
                    break;
                case NumberColor.Black:
                    lbl_res.Background = Brushes.Black;
                    break;
                default:
                    break;
            }

            lbl_res.Content = res.Value;
        }

        private void btn_playStrat_Click(object sender, RoutedEventArgs e)
        {
            double bid = Convert.ToDouble(txt_bid.Text);
            if (bid > _MStrat.Wealth)
            {
                MessageBox.Show("You're broke.\n You left the casino with "+_MStrat.Earnings.ToString()+"$.\n Game was reset.");
                _RGame.Reset();
                _MStrat.Reset();
                lst_history.Items.Clear();
            }
            else
            {
                _MStrat.PlaceBet(bid);
                Number res = _RGame.Play();
                SetRes(res);
                double payoff = _RGame.GetPayoffColor(NumberColor.Red, bid, res);
                _MStrat.Setup(payoff);
            }
            ShowStrat();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowStrat();
        }

        private void ShowStrat()
        {
            txt_initWealth.Text = _MStrat.Wealth.ToString();
            txt_earnings.Text = _MStrat.Earnings.ToString();
            txt_losses.Text = _MStrat.Losses.ToString();
            txt_bid.Text = _MStrat.Bet().ToString();
        }
    }
}
