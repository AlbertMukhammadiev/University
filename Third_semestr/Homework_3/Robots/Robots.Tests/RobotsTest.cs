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
            file = new System.IO.StreamReader(@"..\..\MonochromeGraph.txt");
            monochromeGraph = new Graph(file, robots);
            file.Close();

            file = new System.IO.StreamReader(@"..\..\TwoToneGraph.txt");
            twoToneGraph = new Graph(file, robots);
            file.Close();
        }


        [TestMethod]
        public void AlwaysDestroyTest()
        {
            monochromeGraph.PaintGraph();
            Assert.IsTrue(monochromeGraph.AreDestruct());
        }

        [TestMethod]
        public void NotDestroyTest()
        {
            twoToneGraph.PaintGraph();
            Assert.IsFalse(twoToneGraph.AreDestruct());
        }
    }
}
