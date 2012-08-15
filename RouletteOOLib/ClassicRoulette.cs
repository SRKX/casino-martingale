using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteOOLib
{
    /// <summary>
    /// Represents a classic roulette implementation with a single 0.
    /// </summary>
    public class ClassicRoulette:Roulette
    {
        protected override Number _Draw()
        {
            int v = _rand.Next(0, 36);
            Number n = new Number(v);
            return n;
        }
    }
}
