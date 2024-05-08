using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public PsychoBase DB = new PsychoBase();
        Users_Tests ut = new Users_Tests();
        int id;

        public ResultPage(int test_id, int user_id, double result_count)
        {
            InitializeComponent();

            id = user_id;
            ut = DB.Users_Tests.Where(x=>x.Id_user == user_id && x.Results.Id_test == test_id).FirstOrDefault();
            DefineResult(test_id, user_id, result_count);
        }

        public void DefineResult(int test_id, int user_id, double result_count)
        {
            List<Results> resus = DB.Results.Where(x => x.Id_test == test_id).ToList();
            resus = resus.OrderBy(x=>x.Score_count).ToList();
            Results content = null;
            int result_count_int = Convert.ToInt32(result_count);
            foreach(Results res in resus)
            {
                if(result_count_int >= res.Score_count)
                {
                    content = new Results();
                    content.Result_id = res.Result_id;
                    content.Result_name = res.Result_name;
                    content.Description = res.Description;
                }
            }
            if(content == null)
            {
                content = new Results();
                content.Result_id = resus[0].Result_id;
                content.Result_name = resus[0].Result_name;
                content.Description = resus[0].Description;
            }
            ResultName.Text = content.Result_name;
            ResultText.Text = content.Description;
            if(ut!=null)
            {
                ut.Id_result = content.Result_id;
                DB.SaveChanges();
            }
            else
            {
                ut = new Users_Tests() { Id_result = content.Result_id, Id_user = user_id };
                DB.Users_Tests.Add(ut);
                DB.SaveChanges();
            }

        }

        private void GoTests(object sender, RoutedEventArgs e)
        {
            MainFrame.frame.Navigate(new UserTests(id));
        }
    }
}
