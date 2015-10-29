using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dndReboot.Commands
{
    public class TypeCommand<T> : ICommand
    {

        private readonly Action<T> _execute = null;
        private readonly Predicate<T> _canExecute = null;

        public TypeCommand(Action<T> execute) : this(execute, null)
        {
            
        }

        public TypeCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T) parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute((T) parameter);
        }
    }
}
