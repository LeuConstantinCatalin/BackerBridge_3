using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BackerBridge_3.Views
{
    using System;
    using System.Windows.Input;

    namespace BackerBridge_3.Views
    {
        // Generic RelayCommand for commands with parameters
        public class RelayCommand<T> : ICommand
        {
            private readonly Action<T> execute;
            private readonly Func<T, bool> canExecute;

            public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter) => canExecute == null || canExecute((T)parameter);

            public void Execute(object parameter) => execute((T)parameter);

            public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        // Non-generic RelayCommand for commands without parameters
        public class RelayCommand : ICommand
        {
            private readonly Action execute;
            private readonly Func<bool> canExecute;

            public RelayCommand(Action execute, Func<bool> canExecute = null)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter) => canExecute == null || canExecute();

            public void Execute(object parameter) => execute();

            public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
