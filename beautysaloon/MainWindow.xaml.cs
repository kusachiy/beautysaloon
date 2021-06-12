using beautysaloon.Models.RequestResponseModels;
using beautysaloon.Services;
using beautysaloon.UI.Dialogs;
using beautysaloon.UI.Pages;
using beautysaloon.Windows;
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

namespace beautysaloon
{
    
    public partial class MainWindow : Window
    {
        private User _currentUser;
        private AuthorizeService _authorizeService;
        bool HasAdminAccess = false;
        bool HasModerAccess = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _authorizeService = new AuthorizeService();
            Login();
        }
        private void Authorize(Credentalis credentalis)
        {
            var result = _authorizeService.Authorize(credentalis);
            if (result.Found)
            {
                _currentUser = result.CurrentUser;
                UserContext.CurrentUser = result.CurrentUser;
            }
            if (_currentUser != null)
            {
                HasAdminAccess = _currentUser.RoleID == 4;
                HasModerAccess = _currentUser.RoleID == 4 || _currentUser.RoleID == 5;
                scheduleMenu.Visibility = HasModerAccess ? Visibility.Visible : Visibility.Collapsed;
                userMenu.Visibility = HasModerAccess ? Visibility.Visible : Visibility.Collapsed;
                //servicesMenu.Visibility = HasModerAccess ? Visibility.Visible : Visibility.Collapsed;
                //clientMenu.Visibility = HasModerAccess ? Visibility.Visible : Visibility.Collapsed;
                reportMenu.Visibility = HasAdminAccess ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void Login()
        {
            PasswordWindow passwordWindow = new PasswordWindow();
            if (passwordWindow.ShowDialog() == true)
            {
                var credentalis = new Credentalis() { Login = passwordWindow.Login, Password = passwordWindow.Password };
                Authorize(credentalis);
                if (_currentUser != null)
                {
                    MessageBox.Show("Авторизация пройдена");
                    RightTopLabel.Content = $"{_currentUser.Name}: {_currentUser.Role.Name}";
                }
                else
                {
                    MessageBox.Show("Неверные данные");
                    Login();
                }
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
                Application.Current.Shutdown();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ServicePage page = new ServicePage();
            frameContent.Content = page;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ClientPage page = new ClientPage();
            frameContent.Content = page;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            EmployeePage page = new EmployeePage();
            frameContent.Content = page;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            SchedulePage page = new SchedulePage();
            frameContent.Content = page;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            EditScheduleItemWindow window = new EditScheduleItemWindow();
            if (window.ShowDialog() == true)
            {
                MessageBox.Show("Сохранено");
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            MostWantedMastersReport page = new MostWantedMastersReport();
            frameContent.Content = page;
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            MostWantedServicesReport page = new MostWantedServicesReport();
            frameContent.Content = page;
        }
    }
}
