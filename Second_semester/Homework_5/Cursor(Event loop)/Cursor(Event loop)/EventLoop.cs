﻿using System;
using System.Collections.Generic;

namespace CursorNamespace
{
    /// <summary>
    /// class that implements the event loop
    /// </summary>
    public class EventLoop
    {
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };
        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };
        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

        public void Run(List<string> log)
        {

            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            LeftHandler(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            RightHandler(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            UpHandler(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            DownHandler(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                    case ConsoleKey.P:
                        {
                            var top = Console.CursorTop;
                            var left = Console.CursorLeft;
                            Console.Clear();
                            Console.WriteLine("Log:");
                            foreach (string record in log)
                            {
                                Console.WriteLine("-" + record);
                            }

                            Console.CursorLeft = left;
                            Console.CursorTop = top;
                            break;
                        }
                }
            }
        }
    }
}
