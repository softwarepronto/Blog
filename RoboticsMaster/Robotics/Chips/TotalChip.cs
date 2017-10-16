using System;
using System.Reflection;

using Robotics.Extensions;

namespace Robotics.Chips
{
    /// <summary>
    /// Chip for Robot that allows Robot to sum data
    /// </summary>
    public class TotalChip : Chip
    {
        private static T Add<T>(object x, object y)
        {
            return (T)Convert.ChangeType((dynamic)x + (dynamic)y, typeof(T));
        }
        /// <summary>
        /// Returns the sum (opeator+) of all values in data array via the zeroth element 
        /// of the returned array. The reason a scaler is not returned is due to a inconsistency
        /// in the design requriments namely that chips can return arrays or scalars so the
        /// 0th element is used to return the 
        /// FYI: name does not match other chips naming pattern (name specified by PM)
        /// </summary>
        /// <param name="data">An array of values of the same Type where said type must contain operator+</param>
        /// <returns>if data is null, value returned in null otherwise returns sum of all elements in data.
        /// all values in data array</returns>
        public override T[] Operation<T>(T[] data)
        {
            if (data == null)
            {
                return data;
            }

            TestIfTypesAllTheSameNumeric(data);

            T[] result = { default(T) };

            foreach (T datum in data)
            {
                result[0] += (dynamic)datum;
            }

            return result;
        }
    }
}
