using System;

namespace Robotics.Extensions
{
    /// <summary>
    /// Extensions to the Array class.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Returns true if every value in an array is of the same type.
        /// </summary>
        /// <param name="array">Array for which homogeneity is determined. 
        /// This value can be null.</param>
        /// <returns>return true if array is null or array has a Length of 1 (since is a homogeneous case).
        /// Returns true if all values in array have the same Type (via GetType()) and
        /// false otherwise</returns>
        public static bool IsHomogeneous(this Array array)
        {
            // when called as an extenion method this cannot be null but if this
            // is called as a method it can be null so it can be checked.
            if ((array == null) || (array.Length == 0))
            {
                return true;
            }

            
            Type masterType = array.GetValue(0).GetType();

            for (int i = 1; i < array.Length; i++)
            {
                if (!array.GetValue(i).GetType().Equals(masterType))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns true if every value in an array is of the same numeric type.
        /// </summary>
        /// <param name="array">Array for which homogeneity is determined being all of a single 
        /// numberic type. If null or zero lenth then the type cannot be numeric so return 
        /// value is false</param>
        /// <returns>return false if array is null or array has a Length of 0 since no numeric type
        /// can be detected. Returns true if all values in array have the same Type (via GetType()) 
        /// and if this type is a C#/CLI numeric. Returns false otherwise</returns>
        public static bool IsHomogeneousNumericType(this Array array)
        {
            // when called as an extenion method this cannot be null but if this
            // is called as a method it can be null so it can be checked.
            if ((array == null) || (array.Length == 0) || (!array.GetValue(0).IsNumericType()))
            {
                return false;
            }

            return IsHomogeneous(array);
        }
    }
}
