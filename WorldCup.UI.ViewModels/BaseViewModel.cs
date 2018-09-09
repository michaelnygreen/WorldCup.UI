using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WorldCup.UI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T memberVariable, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(memberVariable, newValue))
            {
                memberVariable = newValue;
                RaisePropertyChanged(propertyName);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
