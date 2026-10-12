using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Services.Interfaces;

namespace AdventOfCode.Common.Services
{
    /// <summary>
    /// Provides methods for performing common numerical operations.
    /// </summary>
    public sealed class NumbersService : INumbersService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersService"/> class.
        /// </summary>
        public NumbersService() { }

        /// <inheritdoc/>
        public long HighestCommonFactor(long a, long b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <inheritdoc/>
        public long HighestCommonFactor(IList<long> values)
        {
            if (values is null || values.Count <= 1)
            {
                throw new ArgumentException("Not enough values specified. There must be at least 2.", nameof(values));
            }

            var a = values[0];
            foreach (var b in values.Skip(1))
            {
                a = HighestCommonFactor(a, b);
            }
            return a;
        }



        /// <inheritdoc/>
        public long LowestCommonMultiple(long a, long b)
        {
            return (a * b) / HighestCommonFactor(a, b);
        }

        /// <inheritdoc/>
        public long LowestCommonMultiple(IList<long> values)
        {
            if (values is null || values.Count <= 0)
            {
                throw new ArgumentException("Not enough values specified. There must be at least 1.", nameof(values));
            }
            if (values.Any(x => x <= 0))
            {
                throw new ArgumentException("All values must be greater than 0.", nameof(values));
            }

            var accumulators = new long[values.Count];
            values.CopyTo(accumulators, 0);

            while (!accumulators.All(x => x == accumulators[0]))
            {
                var index = Array.IndexOf(accumulators, accumulators.Min());
                accumulators[index] += values[index];
            }

            return accumulators[0];
        }

    }
}
