using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteOOLib;

namespace RouletteOOLib.Bets
{
    public enum BetResult
    {
        WIN,
        LOSE,
        PARTIAL
    }

    public abstract class Bet
    {
        private readonly decimal _multiplyer;
        public decimal Multiplyer
        {
            get { return _multiplyer; }
        }

        public Bet(decimal multiplyer)
        {
            _multiplyer = multiplyer;
        }

        public abstract BetResult GetResult(Number number);

        public decimal GetPayoff(Number number, decimal notional)
        {
            BetResult result = GetResult(number);
            switch (result)
            {
                case BetResult.WIN:
                    return notional * Multiplyer;
                case BetResult.LOSE:
                    return 0;
                case BetResult.PARTIAL:
                    return notional / 2;
                default:
                    throw new Exception("Unknown result");
            }
        }
    }
}
