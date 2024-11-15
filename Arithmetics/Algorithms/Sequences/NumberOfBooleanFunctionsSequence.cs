using System.Collections.Generic;
using System.Numerics;

namespace Arithmetics.Algorithms.Sequences
{
    /// <summary>
    ///     <para>
    ///         Sequence of number of truth tables generated by Boolean expressions of n variables
    ///         (Double exponentials of 2: a(n) = 2^(2^n)).
    ///     </para>
    ///     <para>
    ///         Wikipedia: https://wikipedia.org/wiki/Truth_table.
    ///     </para>
    ///     <para>
    ///         OEIS: https://oeis.org/A001146.
    ///     </para>
    /// </summary>
    public class NumberOfBooleanFunctionsSequence : ISequence
    {
        /// <summary>
        /// Gets sequence of number Of Boolean functions.
        /// </summary>
        public IEnumerable<BigInteger> Sequence
        {
            get
            {
                var n = new BigInteger(2);

                while (true)
                {
                    yield return n;
                    n *= n;
                }
            }
        }
    }
}