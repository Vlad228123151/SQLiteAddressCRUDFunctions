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
    /// Обрабатывает логику для главной страницы управления пользователями.
    /// </summary>
    public partial class Glav : Page
    {
        private List<User> users;

        public Glav()
        {
            // Инициализация данных пользователей из базы данных
            using (var context = new ApplicationContext())
            {
                users = context.Users.ToList();
            }

            InitializeComponent();
            // Установка источника данных для DataGrid
            dtgUsers.ItemsSource = users;
        }

        private void btnRedactUsers_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранного пользователя для редактирования
            var selectedUser = dtgUsers.SelectedItem as User;
            if (selectedUser != null)
            {
                // Переход к странице редактирования пользователя
                NavigationService.Navigate(new RedactUser(selectedUser));
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для редактирования.");
            }
        }

        private void btnCreateUsers_Click(object sender, RoutedEventArgs e)
        {
            // Переход к странице создания нового пользователя
            NavigationService.Navigate(new CreateUsers());
        }

        private void btnDeleteUsers_Click(object sender, RoutedEventArgs e)
        {
            // Получение списка выбранных пользователей для удаления
            var selectedUsers = dtgUsers.SelectedItems.Cast<User>().ToList();

            if (selectedUsers.Count > 0)
            {
                // Удаление выбранных пользователей из базы данных
                using (var context = new ApplicationContext())
                {
                    foreach (var user in selectedUsers)
                    {
                        context.Users.Remove(user);
                    }
                    context.SaveChanges();
                }

                // Обновление списка пользователей в DataGrid
                using (var context = new ApplicationContext())
                {
                    dtgUsers.ItemsSource = context.Users.ToList();
                }

                MessageBox.Show($"Удалено {selectedUsers.Count} пользователей.");

                // Переход на главную страницу
                NavigationService.Navigate(new Glav());
            }
            else
            {
                MessageBox.Show("Не выбрано ни одного пользователя для удаления.");
            }
        }
    }
}
