using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net.Http;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace QuestionsAndAnswersGame
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            categoryBox.SelectedIndex = 0;
            difficultyBox.SelectedIndex = 0;
            typeBox.SelectedIndex = 0;
            numberField.Text = "10";
        }

        private async void singleGame(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;
            const int defaultNumberOfQuestions = 10;
            string generatedLink = "https://opentdb.com/api.php?amount=";

            string categoryTag = ((ComboBoxItem)categoryBox.SelectedItem).Tag.ToString();
            string difficultyTag = ((ComboBoxItem)difficultyBox.SelectedItem).Tag.ToString();
            string typeTag = ((ComboBoxItem)typeBox.SelectedItem).Tag.ToString();
            
            generatedLink += (String.IsNullOrEmpty(numberField.Text) || int.Parse(numberField.Text) < 1) ? defaultNumberOfQuestions.ToString() : numberField.Text;

            if (categoryTag != "any")
                generatedLink += $"&category={categoryTag}";
            if (difficultyTag != "any")
                generatedLink += $"&difficulty={difficultyTag}";
            if (typeTag != "any")
                generatedLink += $"&type={typeTag}";
            generatedLink += "&encode=base64";

            Console.WriteLine(generatedLink);
            // get API request response String
            var responseString = await client.GetStringAsync(generatedLink);
            dynamic responseJSON=JsonConvert.DeserializeObject(responseString);

            if (responseJSON["results"].Count == 0) {
                MessageBox.Show("Unfortunately, there are no questions for set criteria.");
                return;
            }
            window.Content = new Page2(responseJSON);
        }

        private static readonly HttpClient client = new HttpClient();
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }

}
