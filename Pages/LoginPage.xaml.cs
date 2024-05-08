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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        PsychoBase DB = new PsychoBase();

        public LoginPage()
        {
            InitializeComponent();

        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            Users user = DB.Users.Where(x=>x.Login == Login.Text && x.Password == Password.Password).FirstOrDefault();
            if(user != null)
            {
                if(user.Id_role == 2)
                {
                    MainFrame.frame.Navigate(new UserTests(user.User_id));
                }
                else
                {
                    MainFrame.frame.Navigate(new PsychoPage(user.User_id));
                }
            }
            else
            {
                MessageBox.Show("Ваших данных нет в базе");
            }
        }
    }
}
