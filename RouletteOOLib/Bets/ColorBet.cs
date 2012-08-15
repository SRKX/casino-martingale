using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteOOLib.Bets
{
    public class ColorBet:Bet
    {
        private readonly NumberColor _color;
        public NumberColor Color
        {
            get { return _color; }
        }

        public ColorBet(NumberColor color)
            :base(2)
        {
            if (color == NumberColor.None)
                throw new ArgumentException("Cannot bet on color 'none'");

            _color = color;
        }

        public override BetResult GetResult(Number number)
        {
            if (number.Color == NumberColor.None)
                return BetResult.PARTIAL;
            else
                return number.Color == Color ? BetResult.WIN : BetResult.LOSE;
        }
    }
}
