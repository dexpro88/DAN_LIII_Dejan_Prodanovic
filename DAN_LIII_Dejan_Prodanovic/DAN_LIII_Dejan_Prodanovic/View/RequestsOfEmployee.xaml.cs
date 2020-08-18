﻿using DAN_LIII_Dejan_Prodanovic.Model;
using DAN_LIII_Dejan_Prodanovic.ViewModel;
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

namespace DAN_LIII_Dejan_Prodanovic.View
{
    /// <summary>
    /// Interaction logic for RequestsOfEmployee.xaml
    /// </summary>
    public partial class RequestsOfEmployee : Window
    {
        public RequestsOfEmployee()
        {
            InitializeComponent();
        }
        public RequestsOfEmployee(tblEmployee employee)
        {
            InitializeComponent();
            DataContext = new RequestsOfEmployeeViewModel(this, employee);
        }
    }
}
