using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для UserTests.xaml
    /// </summary>
    public partial class UserTests : Page
    {
        public PsychoBase DB = new PsychoBase();
        int usid;

        public UserTests(int id)
        {
            InitializeComponent();

            TestList.ItemsSource = DB.Tests.ToList();

            List<Categories> cats = DB.Categories.ToList();
            cats.Insert(0, new Categories() { Category_name = "Все"});
            CategoryFilter.ItemsSource = cats.Select(x=>x.Category_name);
            usid = id;
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            int id = Convert.ToInt32(img.Uid);
            Tests test = DB.Tests.Where(x => x.Test_id == id).FirstOrDefault();
            byte[] bt = test.Image;
            if(bt != null)
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

        public void Filter()
        {
            List<Tests> FilterList = DB.Tests.ToList();
            if(CategoryFilter.SelectedIndex!= 0)
            {
                FilterList = FilterList.Where(x=>x.Id_category+1 == CategoryFilter.SelectedIndex).ToList();
            }
            if (!string.IsNullOrEmpty(SearchBar.Text))
            {
                FilterList = FilterList.Where(x=>x.Test_name.ToUpper().Contains(SearchBar.Text.ToUpper())).ToList();
            }
            TestList.ItemsSource = FilterList;
        }

        private void ChangeCategory(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void SearchChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void GoToTestPage(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            int test_id = Convert.ToInt32(bt.Uid);

            MainFrame.frame.Navigate(new TestPage(test_id,usid));
        }

        private void GoToUserPage(object sender, RoutedEventArgs e)
        {
            MainFrame.frame.Navigate(new UserPage(usid));
        }
    }
}
