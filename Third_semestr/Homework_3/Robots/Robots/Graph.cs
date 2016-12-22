﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    /// <summary>
    /// two possible colors for painting the node
    /// </summary>
    public enum Colours { Black, White };

    /// <summary>
    /// Node of the graph
    /// </summary>
    public class Node
    {
        /// <summary>
        /// the color of a node
        /// </summary>
        public Colours Colour { get; set; }
        /// <summary>
        /// this property is true if this node has robot
        /// </summary>
        public bool HaveRobot { get; set; }
    }

    /// <summary>
    /// the graph that represented by adjacency list
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="file">this file stores the adjacency matrix</param>
        /// <param name="robots">the list of nodes which has robots</param>
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

        /// <summary>
        /// checks the possibility of destroying the robots in the graph
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// color the graph in two colors
        /// </summary>
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
