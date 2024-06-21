using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public PsychoBase DB = new PsychoBase();
        public int user_id;

        public UserPage(int id)
        {
            InitializeComponent();

            user_id = id;
            Fullname.Text = DB.Users.Where(x=>x.User_id == id).Select(x=>x.Surname).FirstOrDefault() + " " + 
                DB.Users.Where(x => x.User_id == id).Select(x => x.Name).FirstOrDefault() + " " +
                DB.Users.Where(x => x.User_id == id).Select(x => x.Patronymic).FirstOrDefault();
            List<Users_Tests> ut = DB.Users_Tests.Where(x=>x.Id_user == id).ToList();
            List<Tests> tt = new List<Tests>();
            foreach(Users_Tests utt in ut)
            {
                tt.Add(DB.Tests.Where(x => x.Test_id == utt.Results.Id_test).First());
            }
            TestList.ItemsSource = tt;
        }

        private void GoToTestPage(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            int test_id = Convert.ToInt32(bt.Uid);
            MainFrame.frame.Navigate(new TestPage(test_id,user_id));
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            int id = Convert.ToInt32(img.Uid);
            Tests test = DB.Tests.Where(x => x.Test_id == id).FirstOrDefault();
            byte[] bt = test.Image;
            if (bt != null)
            {
                ShowImage(bt, img);
            }
            else
            {
                img.Source = img.Source = new BitmapImage(new Uri("/Resources/picture.png", UriKind.RelativeOrAbsolute));
            }
        }

        void ShowImage(byte[] arr, System.Windows.Controls.Image img)
        {
            BitmapImage BI = new BitmapImage();
            BI.BeginInit();
            BI.StreamSource = new MemoryStream(arr);
            BI.EndInit();
            img.Source = BI;
        }

        private void GoToAllTests(object sender, RoutedEventArgs e)
        {
            MainFrame.frame.Navigate(new UserTests(user_id));
        }

        private void ResultFind(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int id = Convert.ToInt32(tb.Uid);
            int resid = DB.Users_Tests.Where(x=>x.Id_user == user_id && x.Results.Id_test == id).Select(x=>x.Id_result).FirstOrDefault();
            tb.Text = "Ваш результат: " + DB.Results.Where(x=>x.Result_id == resid).Select(x=>x.Result_name).FirstOrDefault();
        }

        private void ExitToAuth(object sender, RoutedEventArgs e)
        {
            MainFrame.frame.Navigate(new LoginPage());
        }
    }
}
