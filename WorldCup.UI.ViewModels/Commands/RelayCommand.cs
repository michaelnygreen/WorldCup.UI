using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WorldCup.UI.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        private Func<Task> _action;
        private Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Func<Task> action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public async void Execute(object parameter)
        {
            await _action();
        }
    }
}
