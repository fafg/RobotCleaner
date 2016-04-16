using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleanerLib;
using System;

namespace RobotCleanerTest
{
    [TestClass]
    public class RobotCleanerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            RobotCleaner robot = RobotCleanerFactory.CreateHashSet(10, 10, -100000, 100000);
            robot.Init();

            robot.Clean("E", 10);

            Assert.IsTrue("=> Cleaned: 11" == robot.PlacesCleaned);
        }

        [TestMethod]
        public void TestMethod2()
        {
            RobotCleaner robot = RobotCleanerFactory.CreateHashSet(10, 10, -100000, 100000);
            robot.Init();

            robot.Clean("E", 100000);

            Assert.IsTrue("=> Cleaned: 99991" == robot.PlacesCleaned);

            robot.Dispose();
        }


        [TestMethod]
        public void TestMethod3()
        {
            Tuple<string, int>[] inputs = new Tuple<string, int>[3]
            {
                Tuple.Create<string, int>("E", 5),
                Tuple.Create<string, int>("W", 5),
                Tuple.Create<string, int>("E", 5)
            };

            RobotCleaner robot = RobotCleanerFactory.CreateHashSet(10, 10, -100000, 100000);
            robot.Init();

            for (int i = 0; i < inputs.Length; i++)
                robot.Clean(inputs[i].Item1, inputs[i].Item2);

            Assert.IsTrue("=> Cleaned: 6" == robot.PlacesCleaned);

            robot.Dispose();
        }

        [TestMethod]
        public void TestMethod4()
        {
            Tuple<string, int>[] inputs = new Tuple<string, int>[3]
            {
                Tuple.Create<string, int>("E", 5),
                Tuple.Create<string, int>("W", 5),
                Tuple.Create<string, int>("E", 5)
            };

            RobotCleaner robot = RobotCleanerFactory.CreateHashSet(10, 10, -100000, 100000);
            robot.Init();

            for (int i = 0; i < inputs.Length; i++)
                robot.Clean(inputs[i].Item1, inputs[i].Item2);

            Assert.IsTrue("=> Cleaned: 6" == robot.PlacesCleaned);

            robot.Dispose();
        }
    }
}
