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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace beautysaloon.UI.Pages
{
    /// <summary>
    /// Interaction logic for MostWantedMastersReport.xaml
    /// </summary>
    public partial class MostWantedMastersReport : Page
    {
        List<ServiceProvision> ServiceProvisions { get; set; }
        ServiceProvisionService _service;
        DateTime? dt1, dt2;
        UserService _userService;
        ClientService _clientService;
        ServiceService _serviceService;
        public MostWantedMastersReport()
        {
            InitializeComponent();
            _service = new ServiceProvisionService();
            _userService = new UserService();
            _clientService = new ClientService();
            _serviceService = new ServiceService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.ServiceProvisions = _service.GetAll();
            var usr = _userService.GetAll();
            var srvs = _serviceService.GetAll();
            var clnt = _clientService.GetAll();
            ServiceProvisions.ForEach(s => s.Client = clnt.FirstOrDefault(c => c.Id == s.ClientId));
            ServiceProvisions.ForEach(s => s.Master = usr.FirstOrDefault(u => u.Id == s.MasterId));
            ServiceProvisions.ForEach(s => s.Service = srvs.FirstOrDefault(ss => ss.Id == s.ServiceId));


            
        }

        private void Dtpicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dt1 = dtpicker1.SelectedDate;
            Check();
        }

        private void Dtpicker2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dt2 = dtpicker2.SelectedDate;
            Check();

        }
        private void Check()
        {
            if (dt2 != null && dt1 != null && dt2 > dt1)
            {
                datagrid1.ItemsSource = from sp in ServiceProvisions
                                        group sp by sp.Master into g
                                        select new { MasterName = g.Key, CountOfOrders = g.Count() };
            }
        }
    }
}
