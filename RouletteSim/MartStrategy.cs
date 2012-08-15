using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RouletteSim
{
    class MartStrategy
    {
        private int _MinBid;
        private int _MaxBid;
        private double _InitWealth;
        public double Losses {get; private set;}
        public double Earnings {get; private set;}
        public double Wealth { get; private set; }

        

        public MartStrategy(int min, int max, double w)
        {
            _MinBid = min;
            _MaxBid = max;
            _InitWealth = w;
            Wealth = _InitWealth;
            Losses = 0;
            Earnings =0;
        }

        public double Bet()
        {
            double bid;
            if (Losses == 0) bid=_MinBid;
            else bid=Losses+_MinBid;
            return bid;
        }

        public void PlaceBet(double bid)
        {
            Wealth -= bid;
        }

        public void Setup(double payoff)
        {
            //Adds the payoff to the wealth
            Wealth += payoff;
            //Computes the current deficit
            Losses = Math.Max(_InitWealth - Wealth, 0);
            //Saves the earnings if any
            if (Wealth - _InitWealth > 0)
            {
                Earnings += Wealth - _InitWealth;
                Wealth = _InitWealth;
            }
        }

        public void Reset()
        {
            Wealth = _InitWealth;
            Losses = 0;
            Earnings = 0;
        }

    }
}
