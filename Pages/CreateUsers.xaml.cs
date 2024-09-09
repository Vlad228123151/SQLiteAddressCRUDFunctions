using _06._09._2024_Smirnov_Andreew_wpf_sqlite.Class;
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
using _06._09._2024_Smirnov_Andreew_wpf_sqlite;

namespace _06._09._2024_Smirnov_Andreew_wpf_sqlite.Pages
{
    /// <summary>
    /// Обрабатывает взаимодействие пользователя на странице создания нового пользователя.
    /// </summary>
    public partial class CreateUsers : Page
    {
        public CreateUsers()
        {
            InitializeComponent();
        }

        private void btnSavechanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userName = txtNameUser.Text;
                int userAge = Convert.ToInt32(txtAgeUser.Text);

                // Создаем новый объект пользователя
                User user = new User(userName, userAge);

                using (ApplicationContext context = new ApplicationContext())
                {
                    // Добавляем пользователя в контекст и сохраняем изменения
                    context.Users.Add(user);
                    context.SaveChanges();
                }

                MessageBox.Show("Пользователь успешно добавлен.");

                // Переход на главную страницу
                NavigationService.Navigate(new Glav());
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректный возраст.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Навигация обратно на главную страницу
            this.NavigationService.Navigate(new Glav());
        }
    }
}