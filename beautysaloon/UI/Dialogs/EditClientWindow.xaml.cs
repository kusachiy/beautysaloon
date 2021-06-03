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
    /// Interaction logic for EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        private bool _isUpdateMode = false;
        private ClientService _serviceService;
        private Client _client;
        public EditClientWindow()
        {
            InitializeComponent();
            _client = new Client();
            _serviceService = new ClientService();
        }
        public EditClientWindow(Client client)
        {
            InitializeComponent();
            _serviceService = new ClientService();
            _isUpdateMode = true;
            _client = client;
            TbxName.Text = client.Fio;
            TbxDesc.Text = client.Age.ToString();
            TbxDuration.Text = client.Phone;
            TbxPrice.Text = client.Sex;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            _client.Fio = TbxName.Text;
            _client.Phone = TbxDuration.Text;
            _client.Age = int.Parse(TbxDesc.Text);
            _client.Sex = TbxPrice.Text;
            if (_isUpdateMode)
                _serviceService.Update(_client);
            else
                _serviceService.Create(_client);
            DialogResult = true;
            Close();

        }
    }
}
