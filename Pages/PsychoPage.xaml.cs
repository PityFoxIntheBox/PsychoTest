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
    /// Логика взаимодействия для PsychoPage.xaml
    /// </summary>
    public partial class PsychoPage : Page
    {
        public PsychoBase DB = new PsychoBase();
        public int Pid;

        public PsychoPage(int id)
        {
            InitializeComponent();

            Pid = id;
            Fullname.Text = DB.Users.Where(x=>x.User_id == id).Select(x=>x.Surname).FirstOrDefault() + 
                " " + DB.Users.Where(x => x.User_id == id).Select(x => x.Surname).FirstOrDefault() + 
                " " + DB.Users.Where(x => x.User_id == id).Select(x => x.Surname).FirstOrDefault();

            PateintList.ItemsSource = DB.Users.Where(x=>x.Id_doctor == id).ToList();
        }

        private void AddPatients(object sender, RoutedEventArgs e)
        {

        }

        private void FullnamePatient(object sender, RoutedEventArgs e)
        {
            TreeViewItem tv = (TreeViewItem)sender;
            int id = Convert.ToInt32(tv.Uid);
            tv.Header = DB.Users.Where(x => x.User_id == id).Select(x => x.Surname).FirstOrDefault() + " " +
                DB.Users.Where(x => x.User_id == id).Select(x => x.Name).FirstOrDefault() + " " +
                DB.Users.Where(x => x.User_id == id).Select(x => x.Patronymic).FirstOrDefault();
        }

        private void UserTestResults(object sender, RoutedEventArgs e)
        {
            ListView lv = (ListView)sender;
            int id = Convert.ToInt32(lv.Uid);
            lv.ItemsSource = DB.Users_Tests.Where(x=>x.Id_user == id).ToList();
        }

        private void TestName(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int id = Convert.ToInt32(tb.Uid);
            tb.Text = "• \"" + DB.Results.Where(x=>x.Result_id == id).Select(x=>x.Tests.Test_name).FirstOrDefault() + "\": ";
        }

        private void TestResult(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int id = Convert.ToInt32(tb.Uid);
            tb.Text = DB.Results.Where(x => x.Result_id == id).Select(x => x.Result_name).FirstOrDefault();
        }

    }
}
