using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpFinal {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        
        
        public MainWindow() {
            InitializeComponent();
            DataContext = new ContactsVM();
            //var db = new ContactsContext();
            //Contact = db.Contacts.First();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            System.Windows.Data.CollectionViewSource contactViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contactViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contactViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource addressViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("addressViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // addressViewSource.Source = [generic data source]
        }
    }
}
