using System;
using System.Threading;

namespace Beep
{
    class Program
    {
        static void Gusigagaga()
        {
            int C = 264;
            int D = 297;
            int E = 330;
            int F = 352;
            int G = 396;
            int A = 440;
            int Bb = 466;
            int B = 495;
            int C2 = 528;

            int note = 1000;
            int half = 1000 / 2;
            int quarter = 1000 / 4;
            int eighth = 1000 / 8;

            Thread.Sleep(quarter);
            Console.Beep(F, quarter);
            Console.Beep(E, quarter);
            Console.Beep(D, quarter);
            Console.Beep(C, quarter);
            Console.Beep(G, half);
            Console.Beep(G, half);
            Console.Beep(F, quarter);
            Console.Beep(E, quarter);
            Console.Beep(D, quarter);
            Console.Beep(C, quarter);
            Console.Beep(G, half);
            Console.Beep(G, half);

            Console.Beep(F, quarter);
            Console.Beep(A, quarter);
            Console.Beep(A, quarter);
            Console.Beep(F, quarter);
            Console.Beep(E, quarter);
            Console.Beep(G, quarter);
            Console.Beep(G, quarter);
            Console.Beep(E, quarter);

            Console.Beep(D, quarter);
            Console.Beep(E, quarter);
            Console.Beep(F, quarter);
            Console.Beep(D, quarter);
            Console.Beep(C, half);
            Console.Beep(C, half);

            Console.Beep(F, quarter);
            Console.Beep(A, quarter);
            Console.Beep(A, quarter);
            Console.Beep(F, quarter);
            Console.Beep(E, quarter);
            Console.Beep(G, quarter);
            Console.Beep(G, quarter);
            Console.Beep(E, quarter);

            Console.Beep(D, quarter);
            Console.Beep(E, quarter);
            Console.Beep(F, quarter);
            Console.Beep(D, quarter);
            Console.Beep(C, half);
            Console.Beep(C, half);
            Thread.Sleep(quarter);
        }

        static void Main(string[] args)
        {
            Gusigagaga();
        }
    }
}
