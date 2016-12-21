﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelOfLAN
{
    /// <summary>
    /// this class simulates the work of the local network
    /// </summary>
    public class LocalNetwork
    {
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="file">the adjacency matrix</param>
        /// <param name="infectedComputers">computers that are infected with viruses</param>
        public LocalNetwork(System.IO.StreamReader file, List<int> infectedComputers)
        {
            computers = new List<Computer>();
            string line;
            if ((line = file.ReadLine()) != null)
            {
                for (int j = 0; j < line.Length; ++j)
                {
                    computers.Add(new Computer(line[j]) { ID = j });
                }
            }

            adjacencyList = new List<List<int>>();
            int i = 0;
            while ((line = file.ReadLine()) != null)
            {
                adjacencyList.Add(new List<int>());
                for (int j = 0; j < line.Length; ++j)
                {
                    if (line[j] == '1')
                    {
                        adjacencyList[i].Add(j);
                    }
                }

                ++i;
            }

            foreach (var numOfInfected in infectedComputers)
            {
                computers[numOfInfected].Infect(100);
            }
        }

        /// <summary>
        /// shows the adjacency matrix in the console
        /// </summary>
        public void ShowAdjacencyList()
        {
            foreach (var list in adjacencyList)
            {
                foreach (var computer in list)
                {
                    Console.Write(computer + " ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// checks the health of the system
        /// </summary>
        /// <returns>returns true, if system is unhealthy</returns>
        public bool IsUnhealthy()
        {
            var isUnhealthy = true;
            isUnhealthy = computers.Aggregate(isUnhealthy, (current, computer) => current && computer.IsInfected());
            return isUnhealthy;
        }

        /// <summary>
        /// shows the health of each computer
        /// </summary>
        public void ShowSystem()
        {
            foreach (var computer in computers)
            {
                Console.ForegroundColor = computer.IsInfected() ? ConsoleColor.Red : ConsoleColor.Gray;
                var health = computer.IsInfected() ? "infected" : "healthy";
                Console.WriteLine("computer number " + computer.ID + " is " + health);   
            }
        }

        /// <summary>
        /// simulates the unit of time and performs changes in the system
        /// </summary>
        public void Step()
        {
            var tryInfect = new List<int>();
            for (int i = 0; i < adjacencyList.Count; ++i)
            {
                if (computers[i].IsInfected())
                {
                    foreach (var neighbors in adjacencyList[i])
                    {
                        tryInfect.AddRange(adjacencyList[i]);
                    }
                }
            }

            foreach (var num in tryInfect)
            {
                computers[num].Infect(((new Random()).Next(100)));
            }
        }

        private List<List<int>> adjacencyList;
        private List<Computer> computers;
    }
}