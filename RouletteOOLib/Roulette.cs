using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace RouletteOOLib
{
    /// <summary>
    /// Represents a Roulette casino game.
    /// </summary>
    public abstract class Roulette
    {
        /// <summary>
        /// The history of numbers that came up.
        /// </summary>
        public List<Number> History { get; set; }

        protected readonly Random _rand;

        /// <summary>
        /// Creates an instance of a roulette game.
        /// </summary>
        public Roulette()
        {
            History = new List<Number>();
            _rand = new Random();
        }

        /// <summary>
        /// Simulates a throw of the ball on the roulette.
        /// </summary>
        /// <returns>The number where the ball landed.</returns>
        protected abstract Number _Draw();

        public Number Play()
        {
            Number number = _Draw();
            History.Add(number);
            return number;
        }
        
        
        public void Reset()
        {
            History.Clear();
        }
    }
}
