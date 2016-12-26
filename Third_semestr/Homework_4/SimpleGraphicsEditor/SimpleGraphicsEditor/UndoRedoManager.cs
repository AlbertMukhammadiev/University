using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphicsEditor
{
    public class UndoRedoManager
    {
        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                var command = UndoStack.Pop();
                command.UnExecute();
                RedoStack.Push(command);
            }
        }

        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                var command = RedoStack.Pop();
                command.Execute();
                UndoStack.Push(command);
            }
        }

        public void Execute(ICommand command)
        {
            command.Execute();
            UndoStack.Push(command);
            //RedoStack.Clear();
        }

        private Stack<ICommand> UndoStack = new Stack<ICommand>();
        private Stack<ICommand> RedoStack = new Stack<ICommand>();
    }
}

