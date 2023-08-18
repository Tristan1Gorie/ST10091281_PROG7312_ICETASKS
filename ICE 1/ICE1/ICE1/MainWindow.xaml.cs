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

namespace ICE1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> wordsList = new List<string>();
        private Random random = new Random();
        private string word;
        private int Score=0;
        
        public MainWindow()
        {
            InitializeComponent();
            PopulateList();
            DisplayWord();
        }
        private void PopulateList()
        {
            wordsList.Add("Hello");
            wordsList.Add("recursion");
            wordsList.Add("meta");
            wordsList.Add("brave");
            wordsList.Add("grape");
        }

        private string ScrambleWord(string word)
        {
            char[] characters = word.ToArray();
            for (int i = 0; i < characters.Length; i++)
            {
                int j = random.Next(characters.Length);
                char temp = characters[i];
                characters[i] = characters[j];
                characters[j] = temp;
            }
            return new string(characters);
        }

        private void DisplayWord()
        {
            if (wordsList.Count > 0)
            {
                int randomize = random.Next(wordsList.Count);
                word = wordsList[randomize];
                string scrambledWord = ScrambleWord(word);
                OutputTextBlock.Text = scrambledWord;
            }
        }

        private void PlayButton_Click_1(object sender, RoutedEventArgs e)
        {
            string answer = Answer.Text;

            if (answer == word)
            {

                MessageBox.Show("Correct!", "", MessageBoxButton.OK);
                Score += 1;
                score.Text = $"Score:{Score}";
            }
            else
            {
                MessageBox.Show("Incorrect", "", MessageBoxButton.OK);
                if(Score != 0)
                {
                  Score -= 1;
                }
                else { Score =0; }
                score.Text = $"Score:{Score}";
            }
            Answer.Text = "";
            DisplayWord();

        }

        

    }    
}

