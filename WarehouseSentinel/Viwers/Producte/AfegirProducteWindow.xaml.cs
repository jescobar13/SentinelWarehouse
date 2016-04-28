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
using WarehouseSentinel.Controllers.Producte;
using WarehouseSentinel.Models;

namespace WarehouseSentinel.Viwers.Producte
{
    /// <summary>
    /// Lógica de interacción para AfegirProducteWindow.xaml
    /// </summary>
    public partial class AfegirProducteWindow : Window
    {
        private producte producte;
        private AfegirProducteWindowController controller;

        public AfegirProducteWindow(SentinelDBEntities context, producte producte)
        {
            InitializeComponent();
            this.controller = new AfegirProducteWindowController(context);
            this.producte = producte;
        }

        private void btn_afegirProducte_Click(object sender, RoutedEventArgs e)
        {
            producte.nom = textBox_nomProducte.Text;
            producte.preuKg = Convert.ToDouble(textBox_preuKg.Text);
            producte.unitatCaixa = Convert.ToInt32(textBox_unitatsCaixa.Text);

            string retorna = controller.afegeix(producte);

            MessageBox.Show(retorna, "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
