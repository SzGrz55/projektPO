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

namespace Hotel
{
    /// <summary>
    /// Logika interakcji dla klasy DodajGoscia.xaml
    /// </summary>
    public partial class DodajGoscia : Window
    {
        private RejestrGosci rejestrGosci;

        public DodajGoscia(RejestrGosci rejestr)
        {
            InitializeComponent();
            rejestrGosci = rejestr;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Adres adres = new Adres
                {
                    Ulica = txtUlica.Text,
                    NrDomu = int.Parse(txtNrDomu.Text),
                    Miejscowosc = txtMiejscowosc.Text,
                    KodPocztowy = txtKodPocztowy.Text,
                    NrLokalu = string.IsNullOrWhiteSpace(txtNrLokalu.Text) ? 0 : int.Parse(txtNrLokalu.Text)
                };

                var gosc = new Gosc
                {
                    Imie = txtImie.Text,
                    Nazwisko = txtNazwisko.Text,
                    Pesel = txtPesel.Text,
                    Adres = adres,
                    DataUrodzenia = dpDataUrodzenia.SelectedDate.Value
                };

                rejestrGosci.DodajGoscia(gosc);
                MessageBox.Show("Gość dodany pomyślnie");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

    }

}
