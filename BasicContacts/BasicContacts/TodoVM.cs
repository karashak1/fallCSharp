//using DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace BasicContacts {
    public class TodoVM : BaseVM{


        private string _Text;

        public string Text {
            get { return _Text; }
            set { 
                _Text = value;
                OnPropertyChanged("Text");
                AddCommand.OnCanExecuteChanged();
            }
        }
        public ObservableCollection<TodoItem> List { get; set; }
        //public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand _AddCommand;

        public DelegateCommand AddCommand {
            get { return _AddCommand; }
            //set { _AddCommand = value; }
        }
        

        public TodoVM() {
            List = new ObservableCollection<TodoItem>();
            _AddCommand = new DelegateCommand(AddTodo, ()=> Text != null && Text.Length > 0);
        }

        public void AddTodo() {
            this.List.Add(new TodoItem { Title = Text });
            Text = null;
        }
    }

   

}
