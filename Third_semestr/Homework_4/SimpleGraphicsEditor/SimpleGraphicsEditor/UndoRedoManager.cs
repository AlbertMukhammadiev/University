using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphicsEditor
{
    /// <summary>
    /// the class which execute actions undo/redo
    /// </summary>
    public class UndoRedoManager
    {
        /// <summary>
        /// returns the user to go back a step
        /// </summary>
        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                var command = UndoStack.Pop();
                command.UnExecute();
                RedoStack.Push(command);
            }
        }

        /// <summary>
        /// returns the user one step forward 
        /// </summary>
        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                var command = RedoStack.Pop();
                command.Execute();
                UndoStack.Push(command);
            }
        }

        /// <summary>
        /// executes the command and remember it
        /// </summary>
        /// <param name="command"></param>
        public void Execute(ICommand command)
        {
            command.Execute();
            UndoStack.Push(command);
            ///RedoStack.Clear();
        }

        private Stack<ICommand> UndoStack = new Stack<ICommand>();
        private Stack<ICommand> RedoStack = new Stack<ICommand>();
    }
}

