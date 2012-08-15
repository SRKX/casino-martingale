using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteOOLib
{
    /// <summary>
    /// Represents Vegas Roulette with 0 and 00.
    /// </summary>
    public class VegasRoulette:Roulette
    {
        protected override Number _Draw()
        {
            int v = _rand.Next(-1, 36);
            Number n = (v == -1) ? new DoubleZeroNumber() : new Number(v);
            return n;
        }
    }

    /// <summary>
    /// Represets a 00 number
    /// </summary>
    public class DoubleZeroNumber : Number
    {
        public DoubleZeroNumber()
            :base(-1)
        { }

        public override NumberColor Color
        {
            get
            {
                return NumberColor.None;
            }
        }

        public override string ToString()
        {
            return "00";
        }
    }
}
