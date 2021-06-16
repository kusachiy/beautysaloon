using beautysaloon.Models;
using beautysaloon.Services;
using beautysaloon.UI.Dialogs;
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

namespace beautysaloon.UI.Pages
{
    /// <summary>
    /// Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        List<Client> Clients { get; set; }
        ClientService _clientService;
        public ClientPage()
        {
            InitializeComponent();
            _clientService = new ClientService();
            ButtonPanel.Visibility = UserContext.CurrentUser.RoleID == 6 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Clients = _clientService.GetAll();
            servicesGrid.ItemsSource = Clients;
            servicesGrid.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditClientWindow window = new EditClientWindow();
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
            var s = servicesGrid.SelectedItem as Client;

            EditClientWindow window = new EditClientWindow(s);
            if (window.ShowDialog() == true)
            {
                MessageBox.Show("Сохранено");
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
        }

        private void ServicesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
