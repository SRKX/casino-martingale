using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RouletteOOLib
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

        private static int[] _redNumber = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36};


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
        public virtual NumberColor Color {
            get {
                if (Value == 0) return NumberColor.None;
                else if (_redNumber.Contains(Value)) return NumberColor.Red;
                else return NumberColor.Black;
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            Number n = obj as Number;
            return n!=null && n.Value==this.Value;
        }

        public override int GetHashCode()
        {
            return this.Value;
        }
    }
}
