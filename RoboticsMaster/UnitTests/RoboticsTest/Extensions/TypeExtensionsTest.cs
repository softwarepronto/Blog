using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Robotics.Extensions;

namespace RoboticsTest.Extensions
{
    [TestClass]
    public class TypeExtensionsTest
    {
        private void TestViaTimeSpan()
        {
            const int unitOfTime = 1;
            MethodInfo methodOperatorAddition = typeof(TimeSpan).GetOperatorAddition();
            TimeSpan milliseconds = new TimeSpan(0, 0, 0, 0, unitOfTime);
            TimeSpan seconds = new TimeSpan(0, 0, 0, unitOfTime);
            TimeSpan minutes = new TimeSpan(0, unitOfTime, 0);
            TimeSpan hours = new TimeSpan(unitOfTime, 0, 0);
            TimeSpan days = new TimeSpan(unitOfTime, 0, 0, 0);
            TimeSpan sumThis = new TimeSpan();
            object[] valueToAdd = { null, null };

            Assert.IsNotNull(methodOperatorAddition);
            valueToAdd[0] = sumThis;
            valueToAdd[1] = milliseconds;
            sumThis = (TimeSpan)methodOperatorAddition.Invoke(null, valueToAdd);
            valueToAdd[0] = sumThis;
            valueToAdd[1] = seconds;
            sumThis = (TimeSpan)methodOperatorAddition.Invoke(null, valueToAdd);
            valueToAdd[0] = sumThis;
            valueToAdd[1] = minutes;
            sumThis = (TimeSpan)methodOperatorAddition.Invoke(null, valueToAdd);
            valueToAdd[0] = sumThis;
            valueToAdd[1] = hours;
            sumThis = (TimeSpan)methodOperatorAddition.Invoke(null, valueToAdd);
            valueToAdd[0] = sumThis;
            valueToAdd[1] = days;
            sumThis = (TimeSpan)methodOperatorAddition.Invoke(null, valueToAdd);

            Assert.AreEqual(unitOfTime, sumThis.Milliseconds);
            Assert.AreEqual(unitOfTime, sumThis.Seconds);
            Assert.AreEqual(unitOfTime, sumThis.Minutes);
            Assert.AreEqual(unitOfTime, sumThis.Hours);
            Assert.AreEqual(unitOfTime, sumThis.Days);
        }

        [TestMethod]
        public void GetOperatorAdditionSuccess()
        {
            TestViaTimeSpan();
        }

        [TestMethod]
        public void GetOperatorAdditionFailure()
        {
            MethodInfo methodOperatorAddition = typeof(Random).GetOperatorAddition();

            Assert.IsNull(methodOperatorAddition);
            // primitive types do not contain operator add as this is compiler support
            // and not a method overload
            methodOperatorAddition = typeof(int).GetOperatorAddition();
            Assert.IsNull(methodOperatorAddition);
            methodOperatorAddition = typeof(string).GetOperatorAddition();
            Assert.IsNull(methodOperatorAddition);
        }
    }
}
