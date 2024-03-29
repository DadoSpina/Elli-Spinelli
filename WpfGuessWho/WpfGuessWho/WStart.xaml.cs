﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfGuessWho
{
    public partial class WStart : Window
    {
        DatiCondivisi condi;
        Client c;
        public int valueImage { get; set; }
        public Uri sourceOfTheImage { get; set; }
        Random rand = new Random();
        public WStart(DatiCondivisi condi, Client c)
        {
            sourceOfTheImage = new Uri("maleProfilePicture.jpg", UriKind.Relative);
            InitializeComponent();
            valueImage = 1;
            this.condi = condi;
            this.c = c;
        }
        public void closing()
        {
            Dispatcher.Invoke(delegate
            {
                if (txtUtente.Text != "" && txtUtente.Text != null)
                {
                    condi.Utente = txtUtente.Text;
                    condi.sourceOfTheImage = sourceOfTheImage;
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid username", "GUESS WHO");
                    condi.aCaso = false;
                }
            });
        }


        async Task WaitConnessione()
        {
            while (condi.connesso == 0)
            {
                await Task.Delay(100);
            }
            return;
        }
        async private void btnPartita_Click(object sender, RoutedEventArgs e)
        {
            if (condi.Utente == "")
            {

                if (txtUtente.Text == "" && txtUtente.Text != null)
                {
                    MessageBox.Show("Invalid username", "GUESS WHO");
                }
                else
                {
                    if (txtIP1.Text != "" && txtIP2.Text != "" && txtIP3.Text != "" && txtIP4.Text != "")
                    {
                        condi.ip = txtIP1.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text;
                    }
                    c.toCSV("r", txtUtente.Text);

                    condi.Utente = txtUtente.Text;
                    condi.sourceOfTheImage = sourceOfTheImage;
                    condi.turno = true;
                    btnPartita.Background = new SolidColorBrush(Color.FromArgb(255, 238, 6, 6));
                    await WaitConnessione();

                    if (condi.connesso == 1)
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("CONNECTION FAILED", "ERROR");
                        condi.connesso = 0;
                        condi.Utente = "";
                        condi.sourceOfTheImage = new Uri("", UriKind.Relative);
                        condi.turno = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Sei già in attesa", "ATTENTION");
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (sourceOfTheImage == new Uri("maleProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("femaleProfilePicture.jpg", UriKind.Relative);
            }
            else if (sourceOfTheImage == new Uri("femaleProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("dogProfilePicture.jpg", UriKind.Relative);
            }
            else if (sourceOfTheImage == new Uri("dogProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("catProfilePicture.jpg", UriKind.Relative);
            }
            imgProfilePicture.Source = new BitmapImage(sourceOfTheImage);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (sourceOfTheImage == new Uri("catProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("dogProfilePicture.jpg", UriKind.Relative);
            }
            else if (sourceOfTheImage == new Uri("dogProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("femaleProfilePicture.jpg", UriKind.Relative);
            }
            else if (sourceOfTheImage == new Uri("femaleProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("maleProfilePicture.jpg", UriKind.Relative);
            }
            imgProfilePicture.Source = new BitmapImage(sourceOfTheImage);
        }

        private void txtIP1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtIP1.Text, "[^0-9]"))
            {
                txtIP1.Text = "";
            }
        }

        private void txtIP2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtIP2.Text, "[^0-9]"))
            {
                txtIP2.Text = "";
            }
        }

        private void txtIP3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtIP3.Text, "[^0-9]"))
            {
                txtIP3.Text = "";
            }
        }

    }
}
