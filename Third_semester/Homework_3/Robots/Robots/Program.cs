using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new System.IO.StreamReader(@"..\..\test.txt");
            var robots = new List<int> { 11, 3, 10 };
            var graph = new Graph(file, robots);
            file.Close();
            graph.PaintGraph();
            Console.WriteLine(graph.AreDestruct());
        }
    }
}
