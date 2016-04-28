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
using WarehouseSentinel.Controllers;
using WarehouseSentinel.Models;

namespace WarehouseSentinel.Viwers.Clients
{
    /// <summary>
    /// Lógica de interacción para AfegirClientWindow.xaml
    /// </summary>
    public partial class AfegirClientWindow : Window
    {
        //Prova de commentari
        private client client;
        private AfegirClientWindowController controller;
        modeControllerClient mode;
        private SentinelDBEntities context;

        public AfegirClientWindow(client c, modeControllerClient mode, SentinelDBEntities context)
        {
            InitializeComponent();
            controller = new AfegirClientWindowController(context);
            this.client = c;
            this.mode = mode;
            this.context = context;
        }

        private void afegirClientWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (mode == modeControllerClient.modificar)
                textBox_CIF.IsEnabled = false;
            else
                btn_AplicarCanvisClient.Visibility = Visibility.Hidden;

            textBox_CIF.Text = client.CIF;
            textBox_EmpresaNom.Text = client.nom;
            textBox_Cognom.Text = client.cognom;
            textBox_Adreca.Text = client.adreça;
            textBox_CodiPostal.Text = client.codiPostal;
            textBox_Pais.Text = client.pais;

            if (client.actiu == false)
                radioButton_estatDeshabilitat.IsChecked = true;
            else
                radioButton_estatActiu.IsChecked = true;
        }

        private void listView_contactes_Loaded(object sender, RoutedEventArgs e)
        {
            actualitzaLlistaContactes();
        }

        private void actualitzaLlistaContactes()
        {
            listView_contactes.ItemsSource = null;
            listView_contactes.ItemsSource = controller.donemContactes(client);
        }

        private void btn_AplicarCanvisClient_Click(object sender, RoutedEventArgs e)
        {
            client.nom = textBox_EmpresaNom.Text;
            client.cognom = textBox_Cognom.Text;
            client.adreça = textBox_Adreca.Text;
            client.codiPostal = textBox_CodiPostal.Text;
            client.pais = textBox_Pais.Text;

            if (radioButton_estatActiu.IsEnabled == true)
                client.actiu = true;
            else
                client.actiu = false;

            string retorna = controller.modifica(client);

            MessageBox.Show(retorna, "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void btn_AfegirClient_Click(object sender, RoutedEventArgs e)
        {
            client.CIF = textBox_CIF.Text;
            client.nom = textBox_EmpresaNom.Text;
            client.cognom = textBox_Cognom.Text;
            client.adreça = textBox_Adreca.Text;
            client.codiPostal = textBox_CodiPostal.Text;
            client.pais = textBox_Pais.Text;

            if (radioButton_estatActiu.IsEnabled == true)
                client.actiu = true;
            else
                client.actiu = false;

            string retorna = controller.afegeix(client);

            MessageBox.Show(retorna, "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btn_afegirContacte_Click(object sender, RoutedEventArgs e)
        {
            ContacteWindow contacteWindow = new ContacteWindow(
                context, client, new contacte(), modeControllerContacte.AFEGIR);
            contacteWindow.ShowDialog();
            actualitzaLlistaContactes();
        }

        private void btn_modificarContacte_Click(object sender, RoutedEventArgs e)
        {
            if(listView_contactes.SelectedItems.Count == 1)
            {
                ContacteWindow contacteWindow = new ContacteWindow(
                    context, client, listView_contactes.SelectedItem as contacte, 
                    modeControllerContacte.MODIFICAR);
                contacteWindow.ShowDialog();
                actualitzaLlistaContactes();
            }
        }
    }
}
