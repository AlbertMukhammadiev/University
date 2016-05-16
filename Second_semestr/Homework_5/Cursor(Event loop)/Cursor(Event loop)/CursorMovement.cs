using System;

namespace CursorNamespace
{
    /// <summary>
    /// class that implements the movement of cursor
    /// </summary>
    class CursorMovement
    {
        /// <summary>
        /// moves the cursor to the left
        /// (if the cursor is at the beginning of the row, it will move to the end of the row)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Leftward(object sender, EventArgs args)
        {
            if (Console.CursorLeft == 0)
            {
                Console.CursorLeft = Console.BufferWidth - 1;
                return;
            }

            --Console.CursorLeft;
        }

        /// <summary>
        /// moves the cursor to the right
        /// (if the cursor reaches the end of the row, it will move to beginning of row)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Rightward(object sender, EventArgs args)
        {
            if (Console.CursorLeft == Console.BufferWidth - 1)
            {
                Console.CursorLeft = 0;
                return;
            }

            ++Console.CursorLeft;
        }

        /// <summary>
        /// moves the cursor up
        /// (if the cursor is at the top of the buffer, it will move to the bottom of the buffer)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Upward(object sender, EventArgs args)
        {
            if (Console.CursorTop == 0)
            {
                Console.CursorTop = Console.BufferHeight - 1;
                return;
            }

            --Console.CursorTop;
        }

        /// <summary>
        /// moves the cursor down
        /// (if the cursor is at the bottom of the buffer, it will move to the top of the buffer)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Downward(object sender, EventArgs args)
        {
            if (Console.CursorTop == Console.BufferHeight - 1)
            {
                Console.CursorTop = 0;
                return;
            }

            ++Console.CursorTop;
        }
    }
}