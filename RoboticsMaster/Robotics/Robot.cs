using System;
using System.Collections.Generic;

using Robotics.Chips;

namespace Robotics
{
    /// <summary>
    /// Robot that can take a single Chip and based on the behavior of this
    /// Chip perform an action numeric data. A generic was not used so that the Robot
    /// can perform action on different data types (byte, double, long, etc.)
    /// </summary>
    public class Robot
    {
        private object _lock = new object();

        // A list that is used to track unique chip types used. If hundreds of chips
        // were to be used then a Dictionary and full type names should be used (strings) 
        private List<Type> _chipTypes = new List<Type>();

        public int UniqueChipsInstalled => _chipTypes.Count;

        private Chip _chip = null;

        /// <summary>
        /// Installs the Chip used by the Robot 
        /// </summary>
        /// <param name="chip">Chip used by the Robot to control the operation performed</param>
        public void Install(Chip chip)
        {
            lock(_lock)
            {
                _chip = chip;
                if (chip != null)
                {
                    Type chipType = chip.GetType();

                    if (!_chipTypes.Contains(chipType))
                    {
                        _chipTypes.Add(chipType);
                    }
                }
            }
        }

        /// <summary>
        /// Executes  operation on the data using the chip specified
        /// </summary>
        /// <param name="data">data on which the chip Operation is performed</param>
        /// <returns>For chips that return an array of values the array is returned by the methods.
        /// For chips that return a scalar value then a single element is return with the 0th element
        /// containing the scalar value returned by the operation. </returns>
        public T[] Execute<T>(T [] data)
        {
            lock (_lock)
            {
                if (_chip == null)
                {
                    throw new NullReferenceException(
                        "A robot cannot function without a chip");
                }

                return _chip.Operation(data);
            }
        }
    }
}
