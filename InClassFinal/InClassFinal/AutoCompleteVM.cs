using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using System.Windows.Controls;

namespace InClassFinal {
    public class AutoCompleteVM :BaseVM{
        //public ObservableCollection<string> _Results { get; set; }
        private ObservableCollection<string> _Results;
                
        public ObservableCollection<string> Results {
            get { return _Results; }
            set { 
                _Results = value;
                OnPropertyChanged();
            }
        }
        
       

        private HttpClient client;
        private string _Log;

        public string  Log{
            get { return _Log; }
            set { 
                _Log = value;
                OnPropertyChanged();
            }
        }

        private string _CityName;

        public string CityName {
            get { return _CityName; }
            set { 
                _CityName = value;
                getMoreCityNames();
                OnPropertyChanged();
            }
        }
        

        public AutoCompleteVM() {
            _Results = new ObservableCollection<string>();
            inti();
        }

        private async void inti() {
            client = new HttpClient {
                BaseAddress = new Uri("http://cs.newpaltz.edu/~plotkinm/2012Grad/Final/api/"),
                DefaultRequestHeaders= {{"accept","application/json"}}
            };
            var temp = await client.GetStringAsync("Cities.php?term" + CityName);
            //Log = temp;
            temp = temp.Substring(1, temp.Length - 1);
            var splits = temp.Split(',');
            //ObservableCollection<string> results = new ObservableCollection<string>();
            foreach (var x in splits) {
                Results.Add(x);
            }
            foreach (var x in _Results) {
                Log += x + " ";
            }
           // Results = results;
            
        }

        private  void getMoreCityNames() {
            _Results.Clear();
            Log = "";
            var thread = client.GetStringAsync("Cities.php?term="+CityName);
            var temp = thread.Result;
            temp = temp.Substring(1, temp.Length - 2);
            var splits = temp.Split(',');
            //ObservableCollection<string> results = new ObservableCollection<string>();
            foreach (var x in splits) {
                Results.Add(x);
            }
            foreach (var x in _Results) {
                Log += x;
            }
            //Results = results;
            //OnPropertyChanged();
        }

        private void AutoCompleteBox_TextChanged(object sender, ExecutedRoutedEventArgs e) {
            var autoCompleteBox = sender as AutoCompleteBox;
            if (autoCompleteBox == null)
                return;

            var vm = autoCompleteBox.DataContext as AutoCompleteVM;
            if (vm == null)
                return;
            vm._CityName = autoCompleteBox.Text;
        }
    }



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
