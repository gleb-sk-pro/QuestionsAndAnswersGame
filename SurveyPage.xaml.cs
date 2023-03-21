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

namespace QuestionsAndAnswersGame {
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page {
        public dynamic data;
        public DateTime startTime, endTime;
        public List<String> answerHistory;
        public int currentQuestion = 0;

        public Page2(dynamic parsedJSON) {
            InitializeComponent();
            answerHistory = new List<String>();
            data = parsedJSON;
            startTime = DateTime.Now;

            prepareLayout();
        }

        public void updateQuestionLabel() {
            var decodedQuestion = "[" + (currentQuestion + 1) + "] " + decodedString((string)data["results"][currentQuestion].question);
            TextBlock textBlock = new TextBlock();
            textBlock.Text = decodedQuestion;
            // Otherwise text wrapping won't work
            textBlock.TextWrapping = TextWrapping.Wrap;
            QuestionLabel.Content = textBlock;
        }

        public void updateQuestionButtonClick(object sender, RoutedEventArgs e) {
            updateQuestionLabel();
            Button clickedButton = sender as Button;
            answerHistory.Add((string)clickedButton.Content);
            currentQuestion += 1;
            prepareLayout();
        }

        public void prepareLayout() {
            // All questions answered
            if (currentQuestion == data["results"].Count) {
                endTime = DateTime.Now;
                checkAnswers();
                return;
            }
            updateQuestionLabel();
            //printData();

            // True/False questions layout
            if (decodedString((string)data["results"][currentQuestion].type).Equals("boolean")) {
                // Add answer options to 2 buttons (true/false)
                optionA.SetValue(Grid.RowSpanProperty, 2);
                optionB.SetValue(Grid.RowSpanProperty, 2);
                optionC.Visibility = Visibility.Hidden;
                optionD.Visibility = Visibility.Hidden;
                optionA.Content = "True";
                optionB.Content = "False";
            }
            // Multi-choice questions layout
            else {
                List<String> answerOptions = new List<String>();
                foreach (var i in data["results"][currentQuestion].incorrect_answers) { answerOptions.Add(decodedString((string)i)); }
                answerOptions.Add(decodedString((string)data["results"][currentQuestion].correct_answer));
                answerOptions = shuffleAnswers(answerOptions);
                // Add answer options to all 4 buttons
                optionA.SetValue(Grid.RowSpanProperty, 1);
                optionB.SetValue(Grid.RowSpanProperty, 1);
                optionC.Visibility = Visibility.Visible;
                optionD.Visibility = Visibility.Visible;
                optionA.Content = answerOptions[0];
                optionB.Content = answerOptions[1];
                optionC.Content = answerOptions[2];
                optionD.Content = answerOptions[3];
            }
        }

        public static List<string> shuffleAnswers(List<string> answers) {
            List<string> shuffledAnswers = new List<string>(answers);
            Random rng = new Random();
            int n = shuffledAnswers.Count;
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                string value = shuffledAnswers[k];
                shuffledAnswers[k] = shuffledAnswers[n];
                shuffledAnswers[n] = value;
            }
            return shuffledAnswers;
        }
        public string decodedString(string strToDecode) {
            byte[] data = Convert.FromBase64String(strToDecode);
            string decodedString = Encoding.UTF8.GetString(data);
            return decodedString;
        }

        private void printData() {
            var getCurrent = data["results"][currentQuestion];
            Console.WriteLine(decodedString((string)getCurrent.question));
            Console.Write(decodedString((string)getCurrent.category) + " | ");
            Console.Write(decodedString((string)getCurrent.type) + " | ");
            Console.Write(decodedString((string)getCurrent.difficulty) + " | ");
            Console.Write(decodedString((string)getCurrent.correct_answer) + " | ");
            Console.WriteLine(getCurrent.incorrect_answers.Count);
            Console.Write("Incorrect answers: ");
            foreach (var i in getCurrent.incorrect_answers) { Console.Write(decodedString((string)i) + " | "); }
            Console.WriteLine();

        }
        private string getAnswer(int number) { return decodedString((string)data["results"][number].correct_answer); }

        private string getQuestion(int number) { return decodedString((string)data["results"][number].question); }

        private void checkAnswers() {
            var correctCount = 0;
            string text = "";

            for (var i = 0; i < data["results"].Count; i++) {
                if (answerHistory[i] == getAnswer(i)) { correctCount++; }
                else { text += getQuestion(i) + "\r\nGuess: " + answerHistory[i] + "\r\nCorrect Answer: " + getAnswer(i) + "\r\n\r\n"; }
            }
            text += "\r\n";

            TimeSpan duration = endTime - startTime;

            Page summaryPage = new Summary($"Duration: {Math.Round(duration.TotalSeconds)} sec\r\nCorrect answers - {correctCount}\r\nIncorrect answers - {(data["results"].Count - correctCount)}\r\n\r\n{text}");
            Application.Current.MainWindow.Content = summaryPage;

            var currentID = ((MainWindow)Application.Current.MainWindow).currentPlayerID;

            LastGameAccess lastGameAccess = new LastGameAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            lastGameAccess.ModifyData(currentID,
                new LastGameData { CorrectAnswer = correctCount, IncorrectAnswer = (data["results"].Count - correctCount), TimeTaken = (int)Math.Round(duration.TotalSeconds) });

            DataAccess dataAccess = new DataAccess(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=QuestionnaireData.accdb;Persist Security Info=False;");
            // Every correct answer gives 1 point and every incorrect answer subtracts 1 point from rating
            var gainedRating = dataAccess.GetCurrentRanking(currentID,"Rating") + correctCount * 1 - (data["results"].Count - correctCount) * 1;
            if (gainedRating < 0) { gainedRating = 0; }
            dataAccess.modifyRanking(currentID,"Rating",(int)gainedRating);
            dataAccess.modifyRanking(currentID,"Games", dataAccess.GetCurrentRanking(currentID, "Games")+1);

        }
    }

}
