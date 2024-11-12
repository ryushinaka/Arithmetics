using System;
using System.Numerics;

namespace Arithmetics.Algorithms.Numeric
{
    /// <summary>
    ///     Perform ceiling operation on a number.
    /// </summary>
    public static class Ceil
    {
        /// <summary>
        ///    Returns the smallest integer greater than or equal to the number.
        /// </summary>
        /// <typeparam name="T">Type of number.</typeparam>
        /// <param name="inputNum">Number to find the ceiling of.</param>
        /// <returns>Ceiling value of the number.</returns>        
        public static int CeilVal(int inputNum)
        {
            int intPart = inputNum;

            if (inputNum == int.MaxValue) { return int.MaxValue; }

            return inputNum > intPart ? intPart + 1 : intPart;
        }
        public static long CeilVal(long inputNum)
        {
            long intPart = inputNum;

            if (inputNum == long.MaxValue) { return long.MaxValue; }

            return inputNum > intPart ? intPart + 1 : intPart;
        }
        public static float CeilVal(float inputNum)
        {
            float intPart = inputNum;

            if (inputNum == float.MaxValue) { return float.MaxValue; }

            return inputNum > intPart ? intPart + 1 : intPart;
        }
        public static double CeilVal(double inputNum)
        {
            double intPart = inputNum;

            if (inputNum == double.MaxValue) { return double.MaxValue; }

            return inputNum > intPart ? intPart + 1 : intPart;
        }
    }
}