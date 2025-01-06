using System;

namespace AdventOfCode.Common.Extensions
{
    public static class Int64Extensions
    {
        public static int GetDigit(this long value, int position, bool fromTheLeft = false)
        {
            return fromTheLeft
                ? GetDigitLeft(value, position)
                : GetDigitRight(value, position);
        }


        /// <summary>
        /// Gets a single digit from the specified number (right to left).
        /// </summary>
        /// <param name="value">The number value.</param>
        /// <param name="position">The digit position, from right to left.</param>
        /// <returns></returns>
        private static int GetDigitRight(long value, int position)
        {
            var modifier = Convert.ToInt32(Math.Pow(10, position - 1));
            var result = (value / modifier) % 10;
            return (int)result;

            //if (value == 0)
            //    return 0;
            //var numDigits = Convert.ToInt32(Math.Floor(Math.Log10(value) + 1));
            //if (position < 1)
            //    position = 1;
            //var offset = numDigits - position + 1;
            //var result = Math.Truncate(value / Math.Pow(10, numDigits - offset))
            //          - (Math.Truncate(value / Math.Pow(10, numDigits - offset + 1)) * 10);
            //return Convert.ToInt32(result);
        }

        /// <summary>
        /// Gets a single digit from the specified number (left to right).
        /// </summary>
        /// <param name="value">The number value.</param>
        /// <param name="position">The digit position, from left to right.</param>
        /// <returns></returns>
        private static int GetDigitLeft(long value, int position)
        {
            var digit = value.ToString()[position - 1];
            var result = digit - 48; // ASCII number offset
            return result;
        }
        //public static int GetDigitLeft(int value, int position)
        //{
        //    const int MaxPosition = 6;
        //    var result = Math.Truncate(value / Math.Pow(10, MaxPosition - position))
        //        - (Math.Truncate(value / Math.Pow(10, MaxPosition - position + 1)) * 10);
        //    return Convert.ToInt32(result);
        //}

    }
}
