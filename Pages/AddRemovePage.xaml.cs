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

namespace PsychoTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddRemovePage.xaml
    /// </summary>
    public partial class AddRemovePage : Window
    {
        public PsychoBase DB = new PsychoBase();
        public Users user = new Users();
        public int psId;

        public AddRemovePage(int psId)
        {
            InitializeComponent();

            PatientList.ItemsSource = DB.Users.Where(x=>x.Id_role==2).ToList();
            this.psId = psId;
        }

        private void AddPatient(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            int id = Convert.ToInt32(cb.Uid);
            user = DB.Users.Where(x=>x.User_id == id).FirstOrDefault();
            if(user.Id_doctor != psId)
            {
                user.Id_doctor = psId;
                DB.SaveChanges();
                MainFrame.frame.Navigate(new PsychoPage(psId));
            }
        }

        private void RemovePatient(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            int id = Convert.ToInt32(cb.Uid);
            user = DB.Users.Where(x => x.User_id == id).FirstOrDefault();
            if (user.Id_doctor == psId)
            {
                user.Id_doctor = null;
                DB.SaveChanges();
                MainFrame.frame.Navigate(new PsychoPage(psId));
            }
        }

        private void FullnameLoad(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int id = Convert.ToInt32(tb.Uid);
            tb.Text = DB.Users.Where(x => x.User_id == id).Select(x => x.Surname).FirstOrDefault() + " "
                + DB.Users.Where(x => x.User_id == id).Select(x => x.Name).FirstOrDefault() + " "
                + DB.Users.Where(x => x.User_id == id).Select(x => x.Patronymic).FirstOrDefault();
        }

        private void CheckBoxLoad(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            int id = Convert.ToInt32(cb.Uid);

            if (DB.Users.Where(x=>x.User_id == id).Select(x=>x.Id_doctor).FirstOrDefault() == psId)
            {
                cb.IsChecked = true;
            }
            else
            {
                cb.IsChecked = false;
            }
        }
    }
}
