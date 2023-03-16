using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace QuestionsAndAnswersGame {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            txtAnswer.Focus();
            this.MouseDown += Window1_MouseDown;
        }

        private void Window1_MouseDown(object sender, MouseButtonEventArgs e) { this.DragMove(); }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e) {
            // Show main form
            if (String.IsNullOrEmpty(txtAnswer.Text)) {
                MessageBox.Show("Name can't be empty!");
                return;
            }

            DataAccess dataAccess = new DataAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            // Loop over players and check if nickname exists
            List<PlayerData> playerDataList = dataAccess.ReadData();
            foreach (PlayerData playerData in playerDataList) {
                Console.WriteLine($"Nickname: {playerData.Nickname}");
                if (playerData.Nickname == txtAnswer.Text) {
                    MessageBox.Show("Name already exists!");
                    return;
                }
            }

            // Add new player to database
            PlayerData newPlayerData = new PlayerData { Nickname = txtAnswer.Text, Rating = 0, Games = 0, LastPlayed = DateTime.Now.Date };

            dataAccess.WriteData(newPlayerData);
            dataAccess.printData();
            ((MainWindow)Application.Current.MainWindow).Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e) { Application.Current.Shutdown(); }

        void ChildWindow_Closing(object sender, CancelEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Are you sure to exit?", "Application Shutdown", MessageBoxButton.YesNo, MessageBoxImage.Question);
            e.Cancel = (result == MessageBoxResult.No);
        }

        void ChildWindow_Closed(object sender, EventArgs e) { Application.Current.Shutdown(); }
    }
}


