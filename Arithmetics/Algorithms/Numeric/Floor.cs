using System;
using System.Numerics;

namespace Arithmetics.Algorithms.Numeric
{
    /// <summary>
    ///     Perform floor operation on a number.
    /// </summary>
    public static class Floor
    {
        /// <summary>
        ///    Returns the largest integer less than or equal to the number.
        /// </summary>
        /// <typeparam name="T">Type of number.</typeparam>
        /// <param name="inputNum">Number to find the floor of.</param>
        /// <returns>Floor value of the number.</returns>
        public static int FloorVal(int inputNum)
        {
            int intPart = inputNum;

            if (inputNum == int.MinValue) { return int.MinValue; }

            return inputNum < intPart ? intPart - 1 : intPart;
        }

        public static long FloorVal(long inputNum)
        {
            long intPart = inputNum;

            if (inputNum == long.MinValue) { return long.MinValue; }

            return inputNum < intPart ? intPart - 1 : intPart;
        }

        public static float FloorVal(float inputNum)
        {
            float intPart = inputNum;

            if (inputNum == float.MinValue) { return float.MinValue; }

            return inputNum < intPart ? intPart - 1 : intPart;
        }

        public static double FloorVal(double inputNum)
        {
            double intPart = inputNum;

            if (inputNum == double.MinValue) { return double.MinValue; }

            return inputNum < intPart ? intPart - 1 : intPart;
        }

    }
}