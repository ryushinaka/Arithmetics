using System;
using System.Numerics;

namespace Arithmetics.Algorithms.Numeric
{
    /// <summary>
    ///     Find the absolute value of a number.
    /// </summary>
    public static class Abs
    {
        /// <summary>
        ///    Returns the absolute value of a number.
        /// </summary>
        /// <typeparam name="T">Type of number.</typeparam>
        /// <param name="inputNum">Number to find the absolute value of.</param>
        /// <returns>Absolute value of the number.</returns>
        public static int AbsVal(int inputNum) => inputNum < 0 ? -inputNum : inputNum;
        public static double AbsVal(double inputNum) => inputNum < 0 ? -inputNum : inputNum;
        public static float AbsVal(float inputNum) => inputNum < 0 ? -inputNum : inputNum;
        public static long AbsVal(long inputNum) => inputNum < 0 ? -inputNum : inputNum;

        /// <summary>
        ///   Returns the number with the smallest absolute value on the input array.
        /// </summary>
        /// <typeparam name="T">Type of number.</typeparam>
        /// <param name="inputNums">Array of numbers to find the smallest absolute.</param>
        /// <returns>Smallest absolute number.</returns>        
        public static int AbsMin(int[] inputNum)
        {
            if (inputNum.Length == 0) { throw new ArgumentException("Array is empty"); }
            var min = inputNum[0];
            for (var index = 1; index < inputNum.Length; index++)
            {
                var current = inputNum[index];
                if (AbsVal(current).CompareTo(AbsVal(min)) < 0) { min = current; }
            }
            return min;
        }
        public static double AbsMin(double[] inputNum)
        {
            if (inputNum.Length == 0) { throw new ArgumentException("Array is empty"); }
            var min = inputNum[0];
            for (var index = 1; index < inputNum.Length; index++)
            {
                var current = inputNum[index];
                if (AbsVal(current).CompareTo(AbsVal(min)) < 0) { min = current; }
            }
            return min;
        }
        public static float AbsMin(float[] inputNum)
        {
            if (inputNum.Length == 0) { throw new ArgumentException("Array is empty"); }
            var min = inputNum[0];
            for (var index = 1; index < inputNum.Length; index++)
            {
                var current = inputNum[index];
                if (AbsVal(current).CompareTo(AbsVal(min)) < 0) { min = current; }
            }
            return min;
        }
        public static long AbsMin(long[] inputNum)
        {
            if (inputNum.Length == 0) { throw new ArgumentException("Array is empty"); }
            var min = inputNum[0];
            for (var index = 1; index < inputNum.Length; index++)
            {
                var current = inputNum[index];
                if (AbsVal(current).CompareTo(AbsVal(min)) < 0) { min = current; }
            }
            return min;
        }

        /// <summary>
        ///  Returns the number with the largest absolute value on the input array.
        /// </summary>
        /// <typeparam name="T">Type of number.</typeparam>
        /// <param name="inputNums">Array of numbers to find the largest absolute.</param>
        /// <returns>Largest absolute number.</returns>
        public static int AbsMax(int[] inputNums)
        {
            if (inputNums.Length == 0) { throw new ArgumentException("Array is empty."); }

            var max = inputNums[0];
            for (var index = 1; index < inputNums.Length; index++)
            {
                var current = inputNums[index];
                if (AbsVal(current).CompareTo(AbsVal(max)) > 0)
                {
                    max = current;
                }
            }

            return max;
        }
        public static long AbsMax(long[] inputNums)
        {
            if (inputNums.Length == 0) { throw new ArgumentException("Array is empty."); }

            var max = inputNums[0];
            for (var index = 1; index < inputNums.Length; index++)
            {
                var current = inputNums[index];
                if (AbsVal(current).CompareTo(AbsVal(max)) > 0)
                {
                    max = current;
                }
            }

            return max;
        }
        public static double AbsMax(double[] inputNums)
        {
            if (inputNums.Length == 0) { throw new ArgumentException("Array is empty."); }

            var max = inputNums[0];
            for (var index = 1; index < inputNums.Length; index++)
            {
                var current = inputNums[index];
                if (AbsVal(current).CompareTo(AbsVal(max)) > 0)
                {
                    max = current;
                }
            }

            return max;
        }
        public static float AbsMax(float[] inputNums)
        {
            if (inputNums.Length == 0) { throw new ArgumentException("Array is empty."); }

            var max = inputNums[0];
            for (var index = 1; index < inputNums.Length; index++)
            {
                var current = inputNums[index];
                if (AbsVal(current).CompareTo(AbsVal(max)) > 0)
                {
                    max = current;
                }
            }

            return max;
        }

    }
    
}