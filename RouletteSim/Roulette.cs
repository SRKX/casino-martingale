using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace RouletteSim
{
    /// <summary>
    /// Represents a Roulette casino game.
    /// </summary>
    class Roulette
    {
        /// <summary>
        /// The history of numbers that came up.
        /// </summary>
        public List<Number> History { get; set; }

        private Random _Rand;

        /// <summary>
        /// Creates an instance of a roulette game.
        /// </summary>
        public Roulette()
        {
            History = new List<Number>();
            _Rand = new Random();
        }

        /// <summary>
        /// Simulates a throw of the ball on the roulette.
        /// </summary>
        /// <returns>The number where the ball landed.</returns>
        public Number Play()
        {
            int v = _Rand.Next(0, 36);
            Number n= new Number(v);
            History.Add(n);
            return n;
        }

        public double GetPayoffColor(NumberColor color, double bid, Number result)
        {
            if (result.Color == NumberColor.None) return (bid / 2);
            else if (result.Color == color) return 2*bid;
            else return 0;
        }

        public void Reset()
        {
            History.Clear();
        }
    }
}
