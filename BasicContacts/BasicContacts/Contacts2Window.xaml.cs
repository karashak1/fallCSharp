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
using System.Windows.Shapes;

namespace BasicContacts {
    /// <summary>
    /// Interaction logic for Contacts2Window.xaml
    /// </summary>
    public partial class Contacts2Window : Window {
        public Contacts2Window() {
            InitializeComponent();
            DataContext = new Contacts2VM();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {


            System.Windows.Data.CollectionViewSource contacts2VMViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contacts2VMViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contacts2VMViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource contactMethodViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contactMethodViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contactMethodViewSource.Source = [generic data source]
        }
    }
}
