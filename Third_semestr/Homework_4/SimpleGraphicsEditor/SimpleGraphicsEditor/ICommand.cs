using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphicsEditor
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();
        void UnExecute();
    }
}
