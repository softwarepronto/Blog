using System;
using System.Collections;

using Robotics.Extensions;

namespace Robotics.Chips
{
    /// <summary>
    /// Chip for Robot that allows a Robot to sort data.
    /// </summary>
    public class ChipOfSorts : Chip
    {
        public enum SortDirection
        {
            Ascending,
            Descending
        }

        private SortDirection _sortDirection;

        public SortDirection Direction => _sortDirection;

        private class SortDescending : IComparer
        {
            public int Compare(object x, object y)
            {
                return -1 * ((IComparable)x).CompareTo(y);
            }
        }

        /// <summary>
        /// Chip allows robot to sort data in ascending or descending order
        /// </summary>
        /// <param name="sortDirection">Specifies sort direction ascent or descending</param>
        public ChipOfSorts(SortDirection sortDirection)
        {
            _sortDirection = sortDirection;
        }

        /// <summary>
        /// Returns new array with data in sorted order.
        /// </summary>
        /// <param name="data">data to be sorted. If values is null then return value is null.
        /// All values in the data array must be of the same type or and ArgumentException 
        /// is thrown </param>
        /// <returns>data sorted based off SortDirection specified in the class constructor</returns>
        public override T[] Operation<T>(T[] data)
        {
            if (data == null)
            {
                return data;
            }

            TestIfTypesAllTheSameNumeric(data);
            // Array.Sort is destructive so clone array first
            T[] result = (T[])data.Clone();

            // Note from specification:
            // Sorting algorythm is not important, use standard one 
            // from any library you want.
            if (_sortDirection == SortDirection.Ascending)
            {
                Array.Sort(result);
            }

            else
            {
                Array.Sort(result, new SortDescending());
            }

            return result;
        }
    }
}
