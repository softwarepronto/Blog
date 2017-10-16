using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Robotics;
using Robotics.Chips;

namespace RoboticsTest
{
    [TestClass]
    public class RobotTest
    {
        private Robot _robot = new Robot();
        private List<decimal> _highToLow = new List<decimal>();
        private List<decimal> _lowToHigh = new List<decimal>();
        private List<int> _random = new List<int>();

        public RobotTest()
        {
            Random computeRandom = new Random(Guid.NewGuid().GetHashCode());
            decimal minMaster = decimal.MinValue / 1000.0m;
            decimal maxMaster = decimal.MaxValue / 2500000.0m;

            for (decimal i = 1; i <= 10; i++)
            {
                _highToLow.Add(i * minMaster);
                _lowToHigh.Add(i * maxMaster);
                _random.Add(computeRandom.Next(1000));
            }
        }

        [TestMethod]
        public void TestExecuteChipOfSortsAsending()
        {
            _robot.Install(new ChipOfSorts(ChipOfSorts.SortDirection.Ascending));

            decimal [] highToLow = _highToLow.ToArray();
            decimal[] reversed = _robot.Execute(highToLow);
            decimal[] lowToHigh = _lowToHigh.ToArray();
            decimal[] sameOrder = _robot.Execute(lowToHigh);
            int[] random = _random.ToArray();
            int[] randomAscending = _robot.Execute(random);
            int [] randomAscendingFromLinq = (from r in _random orderby r select r).ToArray();
            decimal [] highToLowAscendingFromLinq = (from h in _highToLow orderby h select h).ToArray();

            CollectionAssert.AreEqual(lowToHigh, sameOrder);
            CollectionAssert.AreEqual(randomAscending, randomAscendingFromLinq);
            CollectionAssert.AreEqual(reversed, highToLowAscendingFromLinq);
        }

        [TestMethod]
        public void TestExecuteChipOfSortsDesending()
        {
            _robot.Install(new ChipOfSorts(ChipOfSorts.SortDirection.Descending));

            decimal[] highToLow = _highToLow.ToArray();
            decimal[] sameOrder = _robot.Execute(highToLow);
            decimal[] lowToHigh = _lowToHigh.ToArray();
            decimal[] reversed = _robot.Execute(lowToHigh);
            int[] random = _random.ToArray();
            int[] randomDecending = _robot.Execute(random);
            int[] randomDecendingFromLinq = (from r in _random orderby r descending select r).ToArray();
            decimal[] lowToHighDescendingFromLinq = (from h in _lowToHigh orderby h descending select h).ToArray();

            CollectionAssert.AreEqual(highToLow, sameOrder);
            CollectionAssert.AreEqual(randomDecending, randomDecendingFromLinq);
            CollectionAssert.AreEqual(reversed, lowToHighDescendingFromLinq);
        }

        private void TestExecuteTotalChip<T>(T [] data, T sum)
        {
            T [] result = _robot.Execute(data); ;

            Assert.AreEqual(sum, result[0]);
        }

        [TestMethod]
        public void TestExecuteTotalChip()
        {
            _robot.Install(new TotalChip());

            // in this method we will compute the values without
            // generics as the chip uses generics so we want to 
            // derive the same answer via a different code path.
            byte[] bytes = { 2, 4, 6, 8 };
            byte byteSum = 0;
            double[] doubles = { 2.1, 4.1, 6.1, 8.1 };
            double doubleSum = 0;
            decimal[] decimals = { 2.1m, 4.1m, 6.1m, 8.1m };
            decimal decimalSum = 0;

            bytes.ToList().ForEach(b => byteSum += b);
            TestExecuteTotalChip(bytes, byteSum);
            doubles.ToList().ForEach(b => doubleSum += b);
            TestExecuteTotalChip(doubles, doubleSum);
            decimals.ToList().ForEach(b => decimalSum += b);
            TestExecuteTotalChip(decimals, decimalSum);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               