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

namespace QuestionsAndAnswersGame {
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window {
        public RegisterWindow() {
            InitializeComponent();
            this.MouseDown += Window1_MouseDown;
        }

        private void Window1_MouseDown(object sender, MouseButtonEventArgs e) {
            try { this.DragMove(); }
            catch (Exception ex) { Console.WriteLine("Error:" + ex); }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var nameLength = NicknameField.Text.Length;
            var passwordLength = PasswordBox.Password.Length;

            DataAccess dataAccess = new DataAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            if (dataAccess.Contains("Nickname", NicknameField.Text)) {
                MessageBox.Show("Nickname already exists");
                return;
            }
            else if (nameLength < 4 || nameLength > 12) {
                MessageBox.Show("Nickname length must be between 4 and 12 characters");
                return;
            }
            else if (passwordLength < 8 || passwordLength > 16) {
                MessageBox.Show("Password length must be between 8 and 16 characters");
                return;
            }
            PasswordEncryption pass = new PasswordEncryption();
            CredentialAccess credentialAccess = new CredentialAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            LastGameAccess lastGameAccess = new LastGameAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            

            // Create default values for new user, and separate pass
            dataAccess.WriteData(new PlayerData { Nickname = NicknameField.Text, Rating = 0, Games = 0, LastPlayed = DateTime.Now.Date });
            lastGameAccess.WriteData(new LastGameData { PlayerID= dataAccess.ReadLastID(), CorrectAnswer = 0, IncorrectAnswer = 0, TimeTaken = 0});
            credentialAccess.WriteData(new CredentialData { AccountID = dataAccess.ReadLastID(), Pass = pass.sha256(PasswordBox.Password) });
            ((MainWindow)Application.Current.MainWindow).currentPlayerID=dataAccess.ReadLastID();
            ((MainWindow)Application.Current.MainWindow).Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            this.Close();
            Window1 window = new Window1();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }
    }
}
