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
using _06._09._2024_Smirnov_Andreew_wpf_sqlite.Class;

namespace _06._09._2024_Smirnov_Andreew_wpf_sqlite.Pages
{
    /// <summary>
    /// Логика для взаимодействия с RedactUser.xaml
    /// </summary>
    public partial class RedactUser : Page
    {
        private User _currentUser;

        public RedactUser(User user)
        {
            _currentUser = user;
            InitializeComponent();
            txtNameUser.Text = user.Name;
            txtAgeUser.Text = user.Age.ToString();
        }

        private void btnSavechangesRedact_Click(object sender, RoutedEventArgs e)
        {
            _currentUser.Name = txtNameUser.Text;
            _currentUser.Age = int.Parse(txtAgeUser.Text);

            using (var context = new ApplicationContext())
            {
                context.Users.Update(_currentUser);
                context.SaveChanges();
            }

            MessageBox.Show("Информация о пользователе обновлена");

            // Переход на главную страницу
            NavigationService.Navigate(new Glav());
        }

        private void btnBackRedact_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Glav());
        }
    }
}
