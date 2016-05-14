using System;
using System.Collections.Generic;

namespace CursorNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var movement = new CursorMovement();

            eventLoop.LeftHandler += movement.Leftward;
            eventLoop.RightHandler += movement.Rightward;
            eventLoop.UpHandler += movement.Upward;
            eventLoop.DownHandler += movement.Downward;

            var log = new List<string>();

            eventLoop.LeftHandler += (sender, eventArgs) => log.Add("left");
            eventLoop.RightHandler += (sender, eventArgs) => log.Add("right");
            eventLoop.UpHandler += (sender, eventArgs) => log.Add("up");
            eventLoop.DownHandler += (sender, eventArgs) => log.Add("down");
            Console.Write("press Esc to exit, press P to print log, press right/left/up/down arrow to move cursor.");
            eventLoop.Run(log);
        }
    }
}
