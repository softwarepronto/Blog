using System;
using System.Reflection;

namespace Robotics.Extensions
{
    /// <summary>
    /// Extensions to the Type class which includes getting operator+ for a Type.
    /// In a production environment this could be extended to get all operator types
    /// (-, less than, greater than, etc.) based off the standard names given these
    /// overloads by the compiler (op_Inequality, op_GreaterThan, op_Subtraction, etc.)
    /// </summary>
    public static class TypeExtensions
    {
        private const string OperatorPlustMethodName = "op_Addition";

        /// <summary>
        /// Returns the method associated with operator+ for a given type
        /// There is no value returned for numeric types (int32, 
        /// int64, double, float, etc.) and there is no value returned for string
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Returns operator method for specified type or null of 
        /// operator+ is not associated with the give type.</returns>
        public static MethodInfo GetOperatorAddition(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(
                    $"{nameof(TypeExtensions)}.{nameof(GetOperatorAddition)} value of " + 
                    $"{nameof(type)} cannot be null,");
            }

            return type.GetMethod(
                OperatorPlustMethodName,
                BindingFlags.Static | BindingFlags.Public);
        }
    }
}
