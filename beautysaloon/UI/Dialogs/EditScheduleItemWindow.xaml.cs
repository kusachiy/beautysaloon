﻿using beautysaloon.Models;
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
        public EditScheduleItemWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var clinet = (Client)comboBox1.SelectedItem;
            var service = (Service)comboBox2.SelectedItem;
            var master = (User)comboBox3.SelectedItem;
            var dt = (DateTime)dtpicker.SelectedDate;
            var time = (UserTime)comboBoxTimes.SelectedItem;
            if (time != null)
                dt = dt.Add(time.Value);
            (new ServiceProvisionService()).Create(new Models.ServiceProvision() { ClientId = clinet.Id,MasterId = master.Id, ServiceId= service.Id, Dt = dt});
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
        }
    }
}