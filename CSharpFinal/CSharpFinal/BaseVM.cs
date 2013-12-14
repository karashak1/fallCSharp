using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSharpFinal {
    public class BaseVM : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null) {

            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class DelegateCommand : ICommand {

        private Action _Action;
        private Func<bool> _CanExecute;

        public DelegateCommand(Action action, Func<bool> canExecute = null) {
            _Action = action;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            //throw new NotImplementedException();
            if (_CanExecute == null)
                return true;
            else
                return _CanExecute();
        }

        public event EventHandler CanExecuteChanged;
        public void OnCanExecuteChanged() {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public void Execute(object parameter) {
            //throw new NotImplementedException();
            _Action();
        }
    }
}
