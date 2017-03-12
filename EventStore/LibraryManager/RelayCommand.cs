using System;
using System.Windows.Input;

namespace LibraryManager
{
    class RelayCommand<T> : ICommand
    {
        private Action<T> _execute;
        private Predicate<T> _canExecute;

        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
