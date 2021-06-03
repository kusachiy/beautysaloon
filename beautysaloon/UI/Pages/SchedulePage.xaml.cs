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
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        List<ServiceProvision> ServiceProvisions { get; set; }
        ServiceProvisionService _service;
        UserService _userService;
        ClientService _clientService;
        ServiceService _serviceService;
        public SchedulePage()
        {
            InitializeComponent();
            _service = new ServiceProvisionService();
            _userService = new UserService();
            _clientService = new ClientService();
            _serviceService = new ServiceService();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ServiceProvisions = _service.GetAll();
            var usr = _userService.GetAll();
            var srvs = _serviceService.GetAll();
            var clnt = _clientService.GetAll();
            ServiceProvisions.ForEach(s => s.Client = clnt.FirstOrDefault(c => c.Id == s.ClientId));
            ServiceProvisions.ForEach(s => s.Master = usr.FirstOrDefault(u => u.Id == s.MasterId));
            ServiceProvisions.ForEach(s => s.Service = srvs.FirstOrDefault(ss => ss.Id == s.ServiceId));


            servicesGrid.ItemsSource = ServiceProvisions;
        }      
    }
}
