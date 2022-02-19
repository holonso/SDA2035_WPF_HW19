using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SDA2035_WPF_HW19
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> executeField;
        private readonly Func<object, bool> canExecuteField;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> ExecuteDelegate, Func<object, bool> CanExecuteDelegate = null)
        {
            executeField = ExecuteDelegate ?? throw new ArgumentNullException(nameof(ExecuteDelegate));
            canExecuteField = CanExecuteDelegate;
        }

        public bool CanExecute(object parameter) => canExecuteField?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => executeField(parameter);
    }
}
