using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Robotics.Extensions;

namespace RoboticsTest.Extensions
{
    [TestClass]
    public class ArrayExtensionsTest
    {        
        [TestMethod]
        public void IsHomogeneousSuccess()
        {
            object[] testArrayLengh0 = { };
            object [] testArrayLength1 = { Guid.NewGuid() };
            object [] testArrayLength3 = { new Random(), new Random(), new Random() };

            Assert.IsTrue(ArrayExtensions.IsHomogeneous(null));
            Assert.IsTrue(testArrayLengh0.IsHomogeneous());
            Assert.IsTrue(testArrayLength1.IsHomogeneous());
            Assert.IsTrue(testArrayLength3.IsHomogeneous());
        }

        [TestMethod]
        public void IsHomogeneousFailure()
        {
            object[] testArrayLengthSDD = { new Random(), new Guid(), new Guid() };
            object[] testArrayLengthSDS = { new Random(), new Guid(), new Random() };
            object[] testArrayLengthSSD = { new Random(), new Random(), new Guid() };

            Assert.IsFalse(testArrayLengthSDD.IsHomogeneous());
            Assert.IsFalse(testArrayLengthSDS.IsHomogeneous());
            Assert.IsFalse(testArrayLengthSSD.IsHomogeneous());
        }

        [TestMethod]
        public void IsHomogeneousNumericTypeSuccess()
        {
            int i32a = 0, i32b = 0, i32c = 0;
            double d1 = 0, d2 = 0, d3 = 0;
            object[] testArrayLengthi1 = { i32a };
            object[] testArrayLengthi2 = { i32a, i32b };
            object[] testArrayLengthi3 = { i32a, i32b, i32c };
            object[] testArrayLengthd1 = { d1 };
            object[] testArrayLengthd2 = { d1, d2 };
            object[] testArrayLengthd3 = { d1, d2, d3 };

            Assert.IsTrue(testArrayLengthd1.IsHomogeneousNumericType());
            Assert.IsTrue(testArrayLengthd2.IsHomogeneousNumericType());
            Assert.IsTrue(testArrayLengthd3.IsHomogeneousNumericType());
        }

        [TestMethod]
        public void IsHomogeneousNumericTypeFailure()
        {
            object[] testArrayLengh0 = { };
            int i32a = 0, i32b = 0;
            double d1 = 0, d2 = 0;
            object[] testArrayLengthSDD = { i32a, d1, d2 };
            object[] testArrayLengthSDS = { i32a, d1, i32b };
            object[] testArrayLengthSSD = { d1, d2, i32a };

            Assert.IsFalse(ArrayExtensions.IsHomogeneousNumericType(null));
            Assert.IsFalse(testArrayLengh0.IsHomogeneousNumericType());
            Assert.IsFalse(testArrayLengthSDD.IsHomogeneousNumericType());
            Assert.IsFalse(testArrayLengthSDS.IsHomogeneousNumericType());
            Assert.IsFalse(testArrayLengthSSD.IsHomogeneousNumericType());
        }
    }
}
