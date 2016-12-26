using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots;

namespace RobotsTests
{
    [TestClass]
    public class UnitTest1
    {
        System.IO.StreamReader file;
        List<int> robots;
        Graph twoToneGraph;
        Graph monochromeGraph;

        [TestInitialize]
        public void Initialize()
        {
            robots = new List<int> { 11, 3 , 10};
            file = new System.IO.StreamReader(@"C:\Users\Альберт\Documents\GitHub\University\Third_semestr\Homework_3\Robots\MonochromeGraph.txt");
            monochromeGraph = new Graph(file, robots);
            file.Close();

            file = new System.IO.StreamReader(@"C:\Users\Альберт\Documents\GitHub\University\Third_semestr\Homework_3\Robots\TwoToneGraph.txt");
            twoToneGraph = new Graph(file, robots);
            file.Close();
        }


        [TestMethod]
        public void AlwaysDestroyTest()
        {
            Assert.IsTrue(monochromeGraph.AreDestruct());
        }

        [TestMethod]
        public void NotDestroyTest()
        {
            Assert.IsFalse(twoToneGraph.AreDestruct());
        }
    }
}
