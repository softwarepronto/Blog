using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Robotics.Chips;

namespace RoboticsTest.Chips
{
    [TestClass]
    public class ChipTest
    {
        /// <summary>
        /// Provides a wrapepr to access protected method(s) of Chip base class.
        /// </summary>
        private class FauxChip : Chip
        {
            public override T[] Operation<T>(T[] data)
            {
                throw new NotImplementedException();
            }

            public static void InvokeTestIfNumeric<T>(T[] data)
            {
                TestIfTypesAllTheSameNumeric(data);
            }
        }

        [TestMethod]
        public void TestIfTypesAreTheSameSuccess()
        {
            byte[] bytes = { 0 };
            int[] ints = { 0, 1 };
            double[] doubles = { 0, 1, 2 };

            FauxChip.InvokeTestIfNumeric(bytes);
            FauxChip.InvokeTestIfNumeric(ints);
            FauxChip.InvokeTestIfNumeric(doubles);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfTypesAreTheSameFailure()
        {
            Guid[] guids = { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()};

            FauxChip.InvokeTestIfNumeric(guids);
        }
    }
}
