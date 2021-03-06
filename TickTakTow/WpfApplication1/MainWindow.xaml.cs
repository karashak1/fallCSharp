﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        string Team = "X";
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var b = sender as TextBlock;
            if (b == null) {

            }
            else {
                if (Team == "X") {
                    Team = "O";
                    b.Background = Brushes.BlueViolet;
                }
                else {
                    Team = "X";
                    b.Background = Brushes.Pink;
                }
                b.Text = Team;
                var s = Resources["Rotate"] as Storyboard;//windows resource get rotate cast to storyboard
                s.Begin(b); //tell the storyboard to start
            }
        }
    }
}
