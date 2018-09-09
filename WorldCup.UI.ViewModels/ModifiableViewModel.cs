using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WorldCup.UI.ViewModels.Commands;

namespace WorldCup.UI.ViewModels
{
    public abstract class ModifiableViewModel : BaseViewModel
    {
        private bool _isModified = false;

        private RelayCommand _saveCommand;
        private RelayCommand _resetCommand;

        public ICommand SaveCommand => _saveCommand;
        public ICommand ResetCommand => _resetCommand;

        public bool IsModified
        {
            get => _isModified;
            set
            {
                if (SetProperty(ref _isModified, value))
                {
                    _saveCommand.RaiseCanExecuteChanged();
                    _resetCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public ModifiableViewModel()
        {
            _saveCommand = new RelayCommand(Save, () => IsModified);
            _resetCommand = new RelayCommand(Reset, () => IsModified);
        }

        protected void ModifyProperty<T>(ref T memberVariable, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (SetProperty(ref memberVariable, newValue, propertyName))
            {
                IsModified = true;
            }
        }

        protected abstract Task Save();
        protected abstract Task Reset();
    }
}
