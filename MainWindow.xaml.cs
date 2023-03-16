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
            //string myValue = ((Page1)myPage).getAttr().ToString();
            //Console.WriteLine(myValue);

            DataAccess dataAccess = new DataAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            // Read data from database
            try {

                List<PlayerData> playerDataList = dataAccess.ReadData();

                foreach (PlayerData playerData in playerDataList) {
                    Console.WriteLine($"ID: {playerData.ID} | Nickname: {playerData.Nickname} | Rating: {playerData.Rating} | Games: {playerData.Games} | LastPlayed: {playerData.LastPlayed.ToString("dd/MM/yyyy")}");
                }

                // Write data to database
                PlayerData newPlayerData = new PlayerData { Nickname = "PlayerOne", Rating = 0, Games = 0, LastPlayed = DateTime.Now.Date };
                //dataAccess.WriteData(newPlayerData);

                // Reset whole database
                //dataAccess.ResetDatabase();

                // Delete data from database
                //dataAccess.DeleteData(8);

            } catch (Exception ex) {
                Console.WriteLine("Check if database file is in the same directory.");
                Console.WriteLine("Exception: "+ex);
            }
        }
    }
}
