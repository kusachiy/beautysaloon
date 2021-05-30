﻿using System;
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
using beautysaloon.Services;

namespace beautysaloon.UI.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        private bool _isUpdateMode = false;
        private UserService _userService;
        private User _user;
        public EditUserWindow()
        {
            InitializeComponent();
            _user = new User();
            _userService = new UserService();
        }
        public EditUserWindow(User user)
        {
            InitializeComponent();
            _userService = new UserService();
            _isUpdateMode = true;
            _user = user;
            TbxName.Text = user.Name;
            TbxLogin.Text = user.Login;
           // TbxRole.Text = user.Role.Name;
            
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            _user.Name = TbxName.Text;
            _user.Login = TbxLogin.Text;

            if (_isUpdateMode)
                _userService.Update(_user);
            else
                _userService.Create(_user);

        }
    }
}
