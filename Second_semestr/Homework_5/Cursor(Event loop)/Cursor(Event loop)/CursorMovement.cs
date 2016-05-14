using System;

namespace CursorNamespace
{
    /// <summary>
    /// class that implements the movement of cursor
    /// </summary>
    class CursorMovement
    {
        public void Leftward(object sender, EventArgs args)
        {
            if (Console.CursorLeft == 0)
            {
                Console.CursorLeft = 79;
                return;
            }

            --Console.CursorLeft;
        }

        public void Rightward(object sender, EventArgs args)
        {
            if (Console.CursorLeft == 79)
            {
                Console.CursorLeft = 0;
                return;
            }

            ++Console.CursorLeft;
        }

        public void Upward(object sender, EventArgs args)
        {
            if (Console.CursorTop == 0)
            {
                Console.CursorTop = 299;
                return;
            }

            --Console.CursorTop;
        }

        public void Downward(object sender, EventArgs args)
        {
            if (Console.CursorTop == 299)
            {
                Console.CursorTop = 0;
                return;
            }

            ++Console.CursorTop;
        }
    }
}