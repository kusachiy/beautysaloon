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
using System.Windows.Shapes;

namespace beautysaloon.Windows
{
    /// <summary>
    /// Interaction logic for ServiceWindow.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        List<Service> Services { get; set; }
        ServiceService _serviceService;
        public ServicePage()
        {
            InitializeComponent();
            _serviceService = new ServiceService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Services = _serviceService.GetAll();
            servicesGrid.ItemsSource = Services;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditServiceWindow window = new EditServiceWindow();
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
            var s = servicesGrid.SelectedItem as Service;

            EditServiceWindow window = new EditServiceWindow(s);
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
