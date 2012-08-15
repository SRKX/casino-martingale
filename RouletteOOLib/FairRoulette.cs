using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteOOLib
{
    /// <summary>
    /// Represents a Roulette with no 0.
    /// </summary>
    public class FairRoulette:Roulette
    {

        protected override Number _Draw()
        {
            int v = _rand.Next(1, 36);
            Number n = new Number(v);
            return n;
        }
    }
}
