using System;
using System.Threading;

namespace Beep
{
    class Program
    {
        static void Brigada()
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

            int note = 2500;
            int halfdot = 2500 / 3 * 2;
            int half = 2500 / 2;
            int quarter = 2500 / 4;
            int eighth = 2500 / 8;
            int eighthdot = 2500 / 6;
            int sixteenth = 2500 / 16;

            Thread.Sleep(quarter);
            Console.Beep(D, sixteenth);
            Console.Beep(A, sixteenth);
            Console.Beep(G, sixteenth);
            Console.Beep(Bb, sixteenth);
            Console.Beep(A, eighthdot);
            Console.Beep(F, sixteenth);
            Console.Beep(G, sixteenth);
            Console.Beep(A, sixteenth);
            Console.Beep(Bb, eighth);
            Console.Beep(A, sixteenth);
            Console.Beep(D, eighthdot);
            
            Thread.Sleep(half);
            Console.Beep(D, sixteenth);
            Console.Beep(A, sixteenth);
            Console.Beep(G, sixteenth);
            Console.Beep(Bb, sixteenth);
            Console.Beep(A, eighthdot);
            Thread.Sleep(100);
            Console.Beep(A, sixteenth);
            Console.Beep(G, sixteenth);
            Console.Beep(F, sixteenth);
            Console.Beep(E, eighth);
            Console.Beep(F, sixteenth);
            Console.Beep(C, eighthdot);
            
            Thread.Sleep(half);
            Console.Beep(D, sixteenth);
            Console.Beep(A, sixteenth);
            Console.Beep(G, sixteenth);
            Console.Beep(Bb, sixteenth);
            Console.Beep(A, eighthdot);
            Console.Beep(F, sixteenth);
            Console.Beep(G, sixteenth);
            Console.Beep(A, sixteenth);
            Console.Beep(Bb, eighth);
            Console.Beep(A, sixteenth);
            Console.Beep(C, eighthdot);

            Thread.Sleep(eighth);
            Console.Beep(D, eighth);
            Console.Beep(E, sixteenth);
            Console.Beep(F, sixteenth);
            Console.Beep(G, eighth);
            Console.Beep(F, sixteenth);
            Console.Beep(D, eighthdot);

            Thread.Sleep(eighth);
            Console.Beep(D, sixteenth);
            Console.Beep(F, sixteenth);
            Console.Beep(E, sixteenth);
            Console.Beep(D, sixteenth);
            Console.Beep(C, eighth);
            Console.Beep(D, halfdot);
        }

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
            //Gusigagaga();
            Brigada();
        }
    }
}
