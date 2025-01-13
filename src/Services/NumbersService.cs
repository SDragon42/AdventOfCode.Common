using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Services.Interfaces;

namespace AdventOfCode.Common.Services
{
    public class NumbersService : INumbersService
    {
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



        public long LowestCommonMultiple(long a, long b)
        {
            return (a * b) / HighestCommonFactor(a, b);
        }

        public long LowestCommonMultiple(IList<long> values)
        {
            if (values is null || values.Count <= 0)
            {
                throw new ArgumentException("Not enough values specified. There must be at least 1.", nameof(values));
            }

            var acumulators = new long[values.Count];
            values.CopyTo(acumulators, 0);

            while (!acumulators.All(x => x == acumulators[0]))
            {
                var index = Array.IndexOf(acumulators, acumulators.Min());
                acumulators[index] += values[index];
            }

            return acumulators[0];
        }

    }
}
