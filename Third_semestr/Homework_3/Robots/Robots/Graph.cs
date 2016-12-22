using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public enum Colours { Black, White };

    public class Node
    {
        public Colours Colour { get; set; }
        public bool HaveRobot { get; set; }
    }

    public class Graph
    {
        public Graph(System.IO.StreamReader file, List<int> robots)
        {
            nodes = new List<Node>();
            adjacencyList = new List<List<int>>();
            int i = 0;
            string line;
            while ((line = file.ReadLine()) != null)
            {
                adjacencyList.Add(new List<int>());
                for (int j = i; j < line.Length; ++j)
                {
                    if (line[j] == '1')
                    {
                        adjacencyList[i].Add(j);
                    }
                }

                var node = robots.Contains(i) ? new Node { HaveRobot = true } : new Node { HaveRobot = false };
                node.Colour = Colours.White;
                nodes.Add(node);
                ++i;
            }

            buffer = new List<int>();
        }

        public bool AreDestruct()
        {
            int onWhite = 0;
            int onBlack = 0;
            foreach (var node in nodes)
            {
                if (node.HaveRobot)
                {
                    if (node.Colour == Colours.White)
                    {
                        ++onWhite;
                    }
                    else
                    {
                        ++onBlack;
                    }
                }
            }

            if ((onWhite != 1) || (onBlack != 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PaintGraph()
        {
            nodes[0].Colour = Colours.Black;
            var visitedNodes = new List<int> { 0 };
            PaintNeighbors(visitedNodes);
        }

        private void PaintNeighbors(List<int> visitedNodes)
        {
            foreach (var number in visitedNodes)
            {
                foreach (var neighbors in adjacencyList[number])
                {
                    buffer.AddRange(adjacencyList[neighbors]);
                }
            }

            visitedNodes.RemoveRange(0, visitedNodes.Count);
            foreach (var num in buffer)
            {
                if (!visitedNodes.Contains(num))
                {
                    visitedNodes.Add(num);
                }
            }

            buffer.RemoveRange(0, buffer.Count);
            foreach (var number in visitedNodes)
            {
                nodes[number].Colour = Colours.Black;
            }

            if (visitedNodes.Count != 0)
            {
                PaintNeighbors(visitedNodes);
            }
        }

        private List<int> buffer;
        private List<List<int>> adjacencyList;
        private List<Node> nodes;
    }
}
