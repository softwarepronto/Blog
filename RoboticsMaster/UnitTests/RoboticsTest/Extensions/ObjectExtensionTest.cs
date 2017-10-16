using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Robotics.Extensions;

namespace RoboticsTest.Extensions
{
    [TestClass]
    public class ObjectExtensionTest
    {
        [TestMethod]
        public void IsNumericTypeSuccess()
        {
            byte by = 0;
            sbyte sby = 0;
            ushort ui16 = 0;
            uint ui32 = 0;
            ulong ui64 = 0;
            short i16 = 0;
            int i32 = 0;
            long i64 = 0;
            decimal dec = 0;
            double d = 0;
            float s = 0;

            Assert.IsTrue(by.IsNumericType());
            Assert.IsTrue(sby.IsNumericType());
            Assert.IsTrue(ui16.IsNumericType());
            Assert.IsTrue(ui32.IsNumericType());
            Assert.IsTrue(ui64.IsNumericType());
            Assert.IsTrue(i16.IsNumericType());
            Assert.IsTrue(i32.IsNumericType());
            Assert.IsTrue(i64.IsNumericType());
            Assert.IsTrue(dec.IsNumericType());
            Assert.IsTrue(d.IsNumericType());
            Assert.IsTrue(s.IsNumericType());
        }

        [TestMethod]
        public void IsNumericTypeFailure()
        {
            bool b = false;
            string s = "";
            char c = 'a';

            Assert.IsFalse(b.IsNumericType());
            Assert.IsFalse(s.IsNumericType());
            Assert.IsFalse(c.IsNumericType());
        }
    }
}
