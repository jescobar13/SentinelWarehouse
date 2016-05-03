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
using WarehouseSentinel.Controllers;
using WarehouseSentinel.Models;

namespace WarehouseSentinel.Viwers.Comanda
{
    /// <summary>
    /// Lógica de interacción para ComandaWindow.xaml
    /// </summary>
    public partial class ComandaWindow : Window
    {
        private ComandesWindowController controller;
        private comanda comanda;

        public client client { get; set; }

        public ComandaWindow(SentinelDBEntities context, comanda comanda)
        {
            InitializeComponent();
            controller = new ComandesWindowController(context);
            this.comanda = comanda;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            datePicker_dataComanda.Text = string.Format("{0:MM/dd/yyyy}", comanda.dataComanda);
            datePicker_dataEntrega.Text = string.Format("{0:MM/dd/yyyy}", comanda.dataEntrega);

        }
    }
}
