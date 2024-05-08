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

namespace PsychoTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public PsychoBase DB = new PsychoBase();
        List<Questions> questions;
        public int n = 0;
        public double TotalScore = 0;
        int test_id, user_id;

        public TestPage(int id_test, int id_user)
        {
            InitializeComponent();

            questions = DB.Questions.Where(x=>x.Id_test==id_test).ToList();
            QuestionContent.Text = questions[n].Content;
            test_id = id_test; 
            user_id = id_user;
        }

        private void TotalAgree(object sender, RoutedEventArgs e)
        {
            CountScoring(5);
        }

        private void PartAgree(object sender, RoutedEventArgs e)
        {
            CountScoring(4);
        }

        private void NotSure(object sender, RoutedEventArgs e)
        {
            CountScoring(3);
        }

        private void PartDisagree(object sender, RoutedEventArgs e)
        {
            CountScoring(2);
        }

        private void TotalDisagree(object sender, RoutedEventArgs e)
        {
            CountScoring(1);
        }

        private void ExitOfTest(object sender, RoutedEventArgs e)
        {
            MainFrame.frame.Navigate(new UserTests(user_id));
        }

        public void CountScoring(int answer)
        {
            switch(answer)
            {
                case 1:
                    if (questions[n].Id_answer == 1)
                    {
                        TotalScore++;
                    }
                    break;
                case 2:
                    if (questions[n].Id_answer == 1)
                    {
                        TotalScore+=0.75;
                    }
                    else
                    {
                        TotalScore += 0.25;
                    }
                    break;
                case 3:
                    TotalScore += 0.5;
                    break;
                case 4:
                    if (questions[n].Id_answer == 1)
                    {
                        TotalScore += 0.25;
                    }
                    else
                    {
                        TotalScore += 0.75;
                    }
                    break;
                case 5:
                    if (questions[n].Id_answer == 5)
                    {
                        TotalScore++;
                    }
                    break;
                default:
                    MessageBox.Show("Что-то не так");
                    break;
            }

            n++;
            try
            {
                QuestionContent.Text = questions[n].Content;
            }
            catch 
            {
                MainFrame.frame.Navigate(new ResultPage(test_id,user_id, TotalScore));
            }

        }
    }
}
