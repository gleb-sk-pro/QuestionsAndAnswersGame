using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<string> Suggestions { get; set; }


        public Window1() {
            InitializeComponent();
            AnswerField.Focus();
            this.MouseDown += Window1_MouseDown;

            // Needed for existing account suggestions
            DataAccess dataAccess = new DataAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            // Loop over players and check if nickname exists
            List<PlayerData> playerDataList = dataAccess.ReadData();
            foreach (PlayerData playerData in playerDataList) {
                AnswerField.Items.Add(playerData.Nickname);
            }
        }


        private void Window1_MouseDown(object sender, MouseButtonEventArgs e) {
            try { this.DragMove(); }
            catch (Exception ex) { Console.WriteLine("Error:" + ex); }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e) {
            this.Close();
            RegisterWindow r = new RegisterWindow();
            r.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            r.Show();
        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e) {
            // Show main form
            if (String.IsNullOrEmpty(AnswerField.Text) || PasswordBox.Password.Length < 1) {
                MessageBox.Show("All fields are required to fill!");
                return;
            }
            DataAccess dataAccess = new DataAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            CredentialAccess credentialAccess = new CredentialAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            PasswordEncryption pass = new PasswordEncryption();

            if (dataAccess.Contains("Nickname", AnswerField.Text) && credentialAccess.Contains("Pass", pass.sha256(PasswordBox.Password))) {
                ((MainWindow)Application.Current.MainWindow).currentPlayerID = dataAccess.returnID("Nickname", AnswerField.Text);
                ((MainWindow)Application.Current.MainWindow).Show();
                this.Close();
            }
            else { MessageBox.Show("Nickname or password is incorrect!"); }
        }

        private void Button_Click(object sender, RoutedEventArgs e) { Application.Current.Shutdown(); }

        void ChildWindow_Closing(object sender, CancelEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Are you sure to exit?", "Application Shutdown", MessageBoxButton.YesNo, MessageBoxImage.Question);
            e.Cancel = (result == MessageBoxResult.No);
        }

        void ChildWindow_Closed(object sender, EventArgs e) { Application.Current.Shutdown(); }
    }

}


