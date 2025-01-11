using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Common.Helpers
{
    public static class Helper
    {
        /// <summary>
        /// Finds the Greatest Common Factor between two numbers.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://stackoverflow.com/a/20824923/6136
        /// </remarks>
        public static long FindGreatestCommonFactor(long a, long b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Find the Least Common Multiple of two numbers.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://stackoverflow.com/a/20824923/6136
        /// </remarks>
        public static long FindLeastCommonMultiple(long a, long b)
        {
            return (a / FindGreatestCommonFactor(a, b)) * b;
        }

    }
}
