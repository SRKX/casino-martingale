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
    /// Interaction logic for AutoSim.xaml
    /// </summary>
    public partial class AutoSim : Window
    {
        private Roulette _RGame = new Roulette();
        public AutoSim()
        {
            InitializeComponent();
        }

        private void btn_simulate_Click(object sender, RoutedEventArgs e)
        {
            int nbrSim = Convert.ToInt32(txt_nbrsim.Text);
            double initWealth = Properties.Settings.Default.InitWealth;

            List<double> finalEarnings = new List<double>();
            List<int> counts = new List<int>();

            for (int i = 0; i < nbrSim; i++)
            {
                MartStrategy MStrat = new MartStrategy(5, 250, initWealth);
                double bid = MStrat.Bet();
                Number res;
                double payoff;
                int count = 0;
                while (bid <= MStrat.Wealth)
                {
                    MStrat.PlaceBet(bid);
                    res = _RGame.Play();
                    payoff = _RGame.GetPayoffColor(NumberColor.Red, bid, res);
                    MStrat.Setup(payoff);
                    bid = MStrat.Bet();
                    count++;
                }
                finalEarnings.Add(MStrat.Earnings-initWealth);
                counts.Add(count);
            }

            txt_earnings.Text = finalEarnings.Average().ToString();
            txt_plays.Text = counts.Average().ToString();
            txt_maxEarnings.Text = finalEarnings.Max().ToString();
            txt_maxLosses.Text = finalEarnings.Min().ToString();
            txt_totEarnings.Text = finalEarnings.Where(x => x > 0).Sum().ToString();
            txt_totLosses.Text = finalEarnings.Where(x => x < 0).Sum().ToString();
            txt_balance.Text = finalEarnings.Sum().ToString();
        }
    }
}
