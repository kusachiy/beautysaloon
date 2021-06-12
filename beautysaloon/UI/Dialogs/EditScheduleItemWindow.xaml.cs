using beautysaloon.Models;
using beautysaloon.Services;
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


namespace beautysaloon.UI.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для EditScheduleItemWindow.xaml
    /// </summary>
    public partial class EditScheduleItemWindow : Window
    {
        ServiceProvision _serviceProvision;
        public EditScheduleItemWindow()
        {
            InitializeComponent();
        }
        public EditScheduleItemWindow(ServiceProvision s)
        {
            InitializeComponent();
            _serviceProvision = s;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var clinet = (Client)comboBox1.SelectedItem;
            var service = (Service)comboBox2.SelectedItem;
            var master = (User)comboBox3.SelectedItem;
            var dt = (DateTime)dtpicker.SelectedDate;
            var time = (UserTime)comboBoxTimes.SelectedItem;
            var sale = (SaleModel)comboBoxSales.SelectedItem;
            if (time != null)
                dt = dt.Add(time.Value);
            (new ServiceProvisionService()).Create(new Models.ServiceProvision() { ClientId = clinet.Id,MasterId = master.Id, ServiceId= service.Id, Dt = dt, Sale = sale.Value});
            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var clients = (new ClientService()).GetAll();
            var users = (new UserService()).GetAll();
            var services = (new ServiceService()).GetAll();

            comboBox1.ItemsSource = clients;
            comboBox3.ItemsSource = users;
            comboBox2.ItemsSource = services;
            var times = new List<UserTime>();
            for (int i = 9; i < 16; i++)
            {
                times.Add(new UserTime(i,false));
                times.Add(new UserTime(i,true));
            }
            comboBoxTimes.ItemsSource = times;

            var sales = new List<SaleModel>();
            for (int i = 0; i <= 25; i+=5)
            {
                sales.Add(new SaleModel() {Value = i });               
            }
            comboBoxSales.ItemsSource = sales;
            comboBoxSales.SelectedIndex = 0;
            if (_serviceProvision != null)
            {
                comboBox1.SelectedItem = clients.FirstOrDefault(c => c.Id == _serviceProvision.ClientId);
                comboBox2.SelectedItem = services.FirstOrDefault(c => c.Id == _serviceProvision.ServiceId);
                comboBox3.SelectedItem = users.FirstOrDefault(c => c.Id == _serviceProvision.MasterId);                
            }
        }

        private void comboBoxSales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var service = comboBox2.SelectedItem as Service;
            var sale = comboBoxSales.SelectedItem as SaleModel;
            if (service != null && sale != null)
            {
                PriceLabel.Content = $"Итоговая стоимость: {service.Price * (100 - sale.Value) / 100.0 }";
            }
        }
    }
}
