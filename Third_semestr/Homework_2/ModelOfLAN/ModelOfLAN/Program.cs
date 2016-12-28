using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelOfLAN
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new System.IO.StreamReader(@"..\..\matrix.txt");
            var list = new List<int> { 11, 3 };
            var lan = new LocalNetwork(file, list);
            file.Close();

            lan.ShowSystem();
            Console.WriteLine();

            while (!lan.IsUnhealthy())
            {
                lan.Step();
                lan.ShowSystem();
                Console.WriteLine();
                Console.WriteLine("System is unhealthy " + lan.IsUnhealthy());
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
