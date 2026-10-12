using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Extensions
{
    /// <summary>
    /// Provides extension methods for working with IEnumerable collections.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Executes the specified action on each element of the enumerable.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="elements">The enumerable whose elements the action will be executed on.</param>
        /// <param name="actionMethod">The action to execute on each element.</param>
        public static void ForEach<T>(this IEnumerable<T> elements, Action<T> actionMethod)
        {
            if (elements is null) throw new ArgumentNullException(nameof(elements));
            if (actionMethod is null) throw new ArgumentNullException(nameof(actionMethod));

            foreach (var item in elements)
                actionMethod(item);
        }


        /// <summary>
        /// Returns an enumerable yielding a sliding window containing elements drawn from the input enumerable.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="elements">The enumerable whose elements will be used to create the sliding windows.</param>
        /// <param name="windowSize">The size of each sliding window.</param>
        /// <returns>An enumerable of arrays, each representing a sliding window of the specified size.</returns>
        /// <remarks>Code from: https://stackoverflow.com/a/8877876/6136</remarks>
        public static IEnumerable<T[]> Windowed<T>(this IEnumerable<T> elements, int windowSize)
        {
            if (elements is null) throw new ArgumentNullException(nameof(elements));
            if (windowSize <= 0) throw new ArgumentOutOfRangeException(nameof(windowSize));

            using (var e = elements.GetEnumerator())
            {
                var arr = new T[windowSize];

                var i = 0;
                var r = windowSize - 1;

                while (e.MoveNext())
                {
                    arr[i] = e.Current;
                    i = (i + 1) % windowSize;

                    if (r == 0)
                        yield return CreateWindowArray(j => arr[(i + j) % windowSize]);
                    else
                        r--;
                }
            }


            T[] CreateWindowArray(Func<int, T> GetValue)
            {
                var output = new T[windowSize];
                for (var i = 0; i < windowSize; i++)
                    output[i] = GetValue(i);
                return output;
            }
        }


        /// <summary>
        /// Returns a list of all possible combinations of the item list.
        /// (item list only tested with unique values)
        /// </summary>
        /// <typeparam name="T">The type of elements in the item list.</typeparam>
        /// <param name="items">The enumerable of items to generate permutations for.</param>
        /// <returns>An enumerable of enumerables, each representing a unique permutation of the input items.</returns>
        /// <remarks>
        /// Sourced and modified from:
        /// https://stackoverflow.com/questions/5132758/words-combinations-without-repetition
        /// </remarks>
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> items)
        {
            if (items.Count() == 1)
            {
                yield return new T[] { items.First() };
                yield break;
            }

            foreach (var item in items)
            {
                var nextItems = items.Where(i => !i.Equals(item));
                foreach (var result in GetPermutations(nextItems))
                    yield return new T[] { item }.Concat(result);
            }
        }

        /// <summary>
        /// Creates a cartesian product of 2 or more enumerables.
        /// </summary>
        /// <typeparam name="T">The type of elements in the input sequences.</typeparam>
        /// <param name="sequences">The input sequences to generate the cartesian product from.</param>
        /// <returns>An enumerable of enumerables, each representing a combination from the cartesian product of the input sequences.</returns>
        /// <remarks>
        /// Sourced and modified from:
        /// https://ericlippert.com/2010/06/28/computing-a-cartesian-product-with-linq/
        /// </remarks>
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> result = default;

            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };

            // uses the query comprehension syntax to generate the cartesian product of the all sequences.
            result = sequences.Aggregate(emptyProduct,
                                         (accumulator, sequence) => from accseq in accumulator
                                                                    from item in sequence
                                                                    select accseq.Concat(new[] { item }));

            //// Same code, but using the "fluent" method style
            //result = sequences.Aggregate(emptyProduct,
            //                             (accumulator, sequence) => accumulator.SelectMany((accseq) => sequence,
            //                                                                               (accseq, item) => accseq.Concat(new[] { item })));


            //// Loop over each sequence 
            //result = emptyProduct;
            //foreach (IEnumerable<T> sequence in sequences)
            //{
            //    result = from accseq in result
            //             from item in sequence
            //             select accseq.Concat(new[] { item });
            //}

            return result;
        }
    }
}
