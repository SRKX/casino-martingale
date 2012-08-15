using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RouletteSim
{
    /// <summary>
    /// Enumeration representing the possible colors of the numbers on the Roulette.
    /// </summary>
    public enum NumberColor {None,Red,Black};

    /// <summary>
    /// Representation of the numbers on the roulette desk.
    /// </summary>
    public class Number
    {
        /// <summary>
        /// Value of the number
        /// </summary>
        public int Value { get; set; }

        public Number (int v)
	    {
            Value = v;
	    }

        /// <summary>
        /// Color of the number.
        /// </summary>
        public NumberColor Color {
            get {
                if (Value == 0) return NumberColor.None;
                else if (Value % 2 == 1) return NumberColor.Red;
                else return NumberColor.Black;
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
