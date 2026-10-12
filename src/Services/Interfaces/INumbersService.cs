using System.Collections.Generic;

namespace AdventOfCode.Common.Services.Interfaces
{
    /// <summary>
    /// Provides methods for performing common numerical operations.
    /// </summary>
    public interface INumbersService
    {
        /// <summary>
        /// Finds the Highest Common Factor between two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The Highest Common Factor of the two numbers.</returns>
        /// <remarks>
        /// https://stackoverflow.com/a/20824923/6136
        /// https://www.cuemath.com/numbers/hcf-highest-common-factor/
        /// </remarks>
        long HighestCommonFactor(long a, long b);

        /// <summary>
        /// Finds the Highest Common Factor between all the numbers.
        /// </summary>
        /// <param name="values">The numbers. At least 2 numbers must be specified.</param>
        /// <returns>The Highest Common Factor of all the numbers.</returns>
        /// <remarks>
        /// https://stackoverflow.com/a/20824923/6136
        /// https://www.cuemath.com/numbers/hcf-highest-common-factor/
        /// </remarks>
        long HighestCommonFactor(IList<long> values);



        /// <summary>
        /// Find the Lowest Common Multiple of two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The Lowest Common Multiple of the two numbers.</returns>
        /// <remarks>
        /// https://stackoverflow.com/a/20824923/6136
        /// https://www.cuemath.com/numbers/lcm-least-common-multiple/
        /// </remarks>
        long LowestCommonMultiple(long a, long b);

        /// <summary>
        /// Finds the Lowest Common Multiple between all the numbers.
        /// </summary>
        /// <param name="values">The numbers. At least 2 numbers must be specified.</param>
        /// <returns>The Lowest Common Multiple of all the numbers.</returns>
        /// <remarks>
        /// https://stackoverflow.com/a/20824923/6136
        /// https://www.cuemath.com/numbers/lcm-least-common-multiple/
        /// </remarks>
        long LowestCommonMultiple(IList<long> values);
    }
}
