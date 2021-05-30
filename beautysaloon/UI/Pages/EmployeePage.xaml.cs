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
using beautysaloon.Services;
using beautysaloon.UI.Dialogs;

namespace beautysaloon.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        List<User> Users { get; set; }
        UserService _UserService;
        public EmployeePage()
        {
            InitializeComponent();
            _UserService = new UserService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Users = _UserService.GetAll();
            usersGrid.ItemsSource = Users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow window = new EditUserWindow();
            if (window.ShowDialog() == true)
            {
                MessageBox.Show("Сохранено");
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var s = usersGrid.SelectedItem as User;

            EditUserWindow window = new EditUserWindow(s);
            if (window.ShowDialog() == true)
            {
                MessageBox.Show("Сохранено");
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
        }






    }
}
