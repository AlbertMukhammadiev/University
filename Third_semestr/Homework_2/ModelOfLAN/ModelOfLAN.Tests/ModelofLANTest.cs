using System;
using System.Collections.Generic;
using ModelOfLAN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelOfLANTests
{
    [TestClass]
    public class ModelofLANTest
    {
        private System.IO.StreamReader file;
        private List<int> infectedComputers;
        private LocalNetwork LAN;

        [TestInitialize]
        public void Initialize()
        {
            infectedComputers = new List<int> { 11, 3 };
            file = new System.IO.StreamReader(@"C:\Users\Альберт\Documents\GitHub\University\Third_semestr\Homework_2\ModelOfLAN\test.txt");
            LAN = new LocalNetwork(file, infectedComputers);
            file.Close();
        }

        [TestMethod]
        public void GetHealthyComputersTest()
        {
            var checkList = new List<int> { 0, 1, 2, 4, 5, 6, 7, 8, 9, 10, 12, 13, 14 };
            var healthyComputers = LAN.GetHealthyComputers();
            for (int i = 0; i < checkList.Count; ++i)
            {
                Assert.IsTrue(healthyComputers.Contains(checkList[i]));
            }
        }

        [TestMethod]
        public void StepTest()
        {
            LAN.Step();
            var checkList = new List<int> { 0, 1, 5, 12, 13, 14 };
            var healthyComputers = LAN.GetHealthyComputers();
            for (int i = 0; i < checkList.Count; ++i)
            {
                Assert.IsTrue(healthyComputers.Contains(checkList[i]));
            }

            LAN.Step();
            healthyComputers = LAN.GetHealthyComputers();
            Assert.IsTrue(healthyComputers.Contains(13));
        }

        [TestMethod]
        public void CheckSystemStatusTest()
        {
            Assert.IsFalse(LAN.IsUnhealthy());

            file = new System.IO.StreamReader(@"C:\Users\Альберт\Documents\GitHub\University\Third_semestr\Homework_2\ModelOfLAN\test.txt");
            var UnhealthyLAN = new LocalNetwork(file, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            file.Close();
            Assert.IsTrue(UnhealthyLAN.IsUnhealthy());
        }
    }
}
