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
using static magazyn_projekt.SqliteDataAccess;
using static magazyn_projekt.loginWindow;

namespace magazyn_projekt
{
    public partial class CustomerWindow : Window
    {
        List<itemModel> koszyk = new List<itemModel>();

        private void DodajItemDoWidokuSklepu(itemModel item)
        {
            listBoxSklep.Items.Add($"{item.nazwaTow} (Cena: {item.cenaSprz}) (Dostępna ilość: {item.ilosc})");
        }

        private void DodajItemDoWidokuKoszyka(itemModel item)
        {
            listViewKoszyk.Items.Add($"{item.nazwaTow} \t {item.ilosc} x {item.cenaSprz} = {Math.Round(item.ilosc* item.cenaSprz, 2)} PLN");
        }

        private void OdswiezWidokKoszyka()
        {
            double kosztRazem = 0;
            listViewKoszyk.Items.Clear();
            foreach (var item in koszyk)
            {
                DodajItemDoWidokuKoszyka(item);
                kosztRazem += item.ilosc * item.cenaSprz;
            }
            textBoxRazem.Text = $"Razem: {Math.Round(kosztRazem, 2)} PLN";
        }
        
        private void OdswiezWidokSklepu(string pattern = null)
        {
            listBoxSklep.Items.Clear();
            foreach (var item in items)
                if (string.IsNullOrEmpty(pattern))
                    DodajItemDoWidokuSklepu(item);
                else if (item.nazwaTow.ToLower().Contains(pattern.ToLower()))
                    DodajItemDoWidokuSklepu(item);
        }

        public CustomerWindow()
        {
            InitializeComponent();
            OdswiezWidokSklepu();
        }

        private void SearchTextBoxChanged(object sender, RoutedEventArgs e)
        {
            string pattern = searchTextBox.Text;
            OdswiezWidokSklepu(pattern);
        }

        private void listBoxDoubleClicked(object sender, RoutedEventArgs e)
        {
            ListBox listBoxItem = sender as ListBox;
            if(listBoxItem.SelectedValue != null)
            {
                int indexNazwy = listBoxItem.SelectedValue.ToString().IndexOf("(Cena:");
                string nazwa = listBoxItem.SelectedValue.ToString().Remove(indexNazwy).Trim();
                var itemSelected = items.FirstOrDefault(x => x.nazwaTow.Equals(nazwa));

                if (itemSelected != null)
                {
                    var itemKoszyk = koszyk.FirstOrDefault(x => x.nazwaTow.Equals(nazwa));

                    if (itemKoszyk != null)
                        itemKoszyk.ilosc++;
                    else
                    {
                        koszyk.Add(new itemModel
                        {
                            cenaSprz = itemSelected.cenaSprz,
                            cenaZak = itemSelected.cenaZak,
                            idDos = itemSelected.idDos,
                            idTow = itemSelected.idTow,
                            nazwaTow = itemSelected.nazwaTow,
                            ilosc = 1
                        });
                    }
                    OdswiezWidokKoszyka();
                };
            }
        }

        private void ButtonKupTerazClick(object sender, RoutedEventArgs e)
        {
            if (koszyk.Count > 0)
            {
                addInvoice(koszyk, userLogged);
                koszyk.Clear();
                OdswiezWidokKoszyka();
                OdswiezWidokSklepu();
            }
        }

        private void ButtonUsunZaznaczoneClick(object sender, RoutedEventArgs e)
        {
            var selectedItems = listViewKoszyk.SelectedItems;
            foreach (string item in selectedItems)
            {
                koszyk.RemoveAll(x => item.Contains(x.nazwaTow));
            }
            OdswiezWidokKoszyka();
        }
    }
}
