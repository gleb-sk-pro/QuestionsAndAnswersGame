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
using System.Data.OleDb;

namespace QuestionsAndAnswersGame {
    /// <summary>
    /// Interaction logic for Ranking.xaml
    /// </summary>
    public partial class Ranking : Window {
        public Ranking() {
            InitializeComponent();
            DataAccess dataAccess = new DataAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            DataRanking.ItemsSource = dataAccess.ReadData();

            // Create the columns
            DataGridTextColumn idColumn = new DataGridTextColumn();
            idColumn.Header = "ID";
            idColumn.Binding = new Binding("ID");

            DataGridTextColumn nicknameColumn = new DataGridTextColumn();
            nicknameColumn.Header = "Nickname";
            nicknameColumn.Binding = new Binding("Nickname");

            DataGridTextColumn ratingColumn = new DataGridTextColumn();
            ratingColumn.Header = "Rating";
            ratingColumn.Binding = new Binding("Rating");

            DataGridTextColumn gamesColumn = new DataGridTextColumn();
            gamesColumn.Header = "Games";
            gamesColumn.Binding = new Binding("Games");

            // Add the columns to the DataGrid
            DataRanking.Columns.Add(idColumn);
            DataRanking.Columns.Add(nicknameColumn);
            DataRanking.Columns.Add(ratingColumn);
            DataRanking.Columns.Add(gamesColumn);



            LastGameAccess lastGameAccess = new LastGameAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            GameDate.ItemsSource = lastGameAccess.ReadData();

             DataGridTextColumn PlayerID = new DataGridTextColumn();
            PlayerID.Header = "PlayerID";
            PlayerID.Binding = new Binding("PlayerID");

            DataGridTextColumn CorrectAnswer = new DataGridTextColumn();
            CorrectAnswer.Header = "CorrectAnswer";
            CorrectAnswer.Binding = new Binding("CorrectAnswer");

            DataGridTextColumn IncorrectAnswer = new DataGridTextColumn();
            IncorrectAnswer.Header = "IncorrectAnswer";
            IncorrectAnswer.Binding = new Binding("IncorrectAnswer");

            DataGridTextColumn TimeTaken = new DataGridTextColumn();
            TimeTaken.Header = "TimeTaken";
            TimeTaken.Binding = new Binding("TimeTaken");
            
            // Add the columns to the DataGrid
            GameDate.Columns.Add(CorrectAnswer);
            GameDate.Columns.Add(IncorrectAnswer);
            GameDate.Columns.Add(TimeTaken);
            GameDate.Columns.Add(PlayerID);

        }
    }
}
