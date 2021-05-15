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
    /// Interaction logic for EditServiceWindow.xaml
    /// </summary>
    public partial class EditServiceWindow : Window
    {
        private bool _isUpdateMode = false;
        private ServiceService _serviceService;
        private Service _service;
        public EditServiceWindow()
        {
            InitializeComponent();
            _service = new Service();
            _serviceService = new ServiceService();
        }
        public EditServiceWindow(Service service)
        {
            InitializeComponent();
            _serviceService = new ServiceService();
            _isUpdateMode = true;
            _service = service;
            TbxName.Text = service.Name;
            TbxDesc.Text = service.Description;
            TbxDuration.Text = service.Duration.ToString();
            TbxPrice.Text = service.Price.ToString();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            _service.Name = TbxName.Text;
            _service.Description = TbxDesc.Text;
            _service.Duration = int.Parse(TbxDuration.Text);
            _service.Price = int.Parse(TbxPrice.Text);
            if(_isUpdateMode)
                _serviceService.Update(_service);
            else
                _serviceService.Create(_service);

        }
    }
}
