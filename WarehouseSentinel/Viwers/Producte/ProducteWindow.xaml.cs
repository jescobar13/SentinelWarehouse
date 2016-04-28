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
using WarehouseSentinel.Controllers.Producte;

namespace WarehouseSentinel.Viwers.Producta
{
    /// <summary>
    /// Lógica de interacción para ProducteWindow.xaml
    /// </summary>
    public partial class ProducteWindow : Window
    {
        private ProducteWindowController controller;

        public ProducteWindow()
        {
            InitializeComponent();
            controller = new ProducteWindowController();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actualitzaProductes();
        }

        private void actualitzaProductes()
        {
            dataGrid_productes.ItemsSource = null;
            dataGrid_productes.ItemsSource = controller.donemProductes();
        }

        private void btn_AfegirProducte_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
