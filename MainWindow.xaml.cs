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
using System.Net.Http;
using System.IO;
using System.Data.OleDb;



namespace QuestionsAndAnswersGame {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public int currentPlayerID = 0;
        public MainWindow() {
            InitializeComponent();

            // Location of window on screen
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Hide();

            Window1 window = new Window1();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            
            Page myPage = new Page1();
            Main.Content = myPage;
        }
    }
}
