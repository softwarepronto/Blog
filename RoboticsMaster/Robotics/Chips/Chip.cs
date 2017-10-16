using System;

using Robotics.Extensions;

namespace Robotics.Chips
{
    /// <summary>
    /// Base class for chips used by Robot. An abstract base class was chosen
    /// over an interface because there are certain utility methods that can be shared
    /// such as TestIfTypesAreTheSame which insures operations are performed on arrays 
    /// containing only the same type.
    /// </summary>
    public abstract class Chip
    {
        /// <summary>
        /// Operation performed by chip. Operations are performed on numeric values. As
        /// the only way to determine numeric values is via code (such as a switch statement)
        /// a generic is permitted but the data will be validate as numeric (byte, int, double,
        /// decimal, etc.).
        /// </summary>
        /// <param name="data">array of values to be processed</param>
        /// <returns>result of processing. For scalar results an array of length 1 is returned 
        /// with the 0th element set to the scalar value</returns>
        public abstract T[] Operation<T>(T[] data);

        /// <summary>
        /// Tests is data contains numerica data (byte, int, double, etc.)
        /// and throws an exception ArgumentException is thrown if type is 
        /// not numeric 
        /// </summary>
        /// <typeparam name="T">Data type of array (must be numeric)</typeparam>
        /// <param name="data">A null or a zero length array is illegal.
        /// All types in array are checked if the values are numeric and identical</param>
        protected static void TestIfTypesAllTheSameNumeric<T>(T[] data)
        {
            // The data.IsHomogeneous is to make sure that T is IComparable
            // and data[0] is a byte (a legal numeric) but the next value
            // could be a string. T.IsNumericType is not legal for the compiler.
            if ((data == null) || 
                (data.Length == 0) || 
                (!data[0].IsNumericType()) ||
                (!data.IsHomogeneous()))
            {
                throw new ArgumentException(
                    $"{nameof(Operation)} requires data types to be numeric.");
            }
        }
    }
}
