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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuestionsAndAnswersGame {
    /// <summary>
    /// Interaction logic for Summary.xaml
    /// </summary>
    public partial class Summary : Page {
        public Summary(String content) {
            InitializeComponent();
            summaryContent.Text = content;
            summaryContent.TextWrapping = TextWrapping.Wrap;
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            var window = (MainWindow)Application.Current.MainWindow;
            // Display summary with incorrect answers
            window.Content = new Page1();

        }
    }
}
