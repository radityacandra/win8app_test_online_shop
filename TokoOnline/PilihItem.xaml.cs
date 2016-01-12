/* TA PBO 2014
 * Nama : Raditya Chandra Buana
 * Teknologi Informasi
 * 39511
 */ 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TokoOnline.Proses;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TokoOnline
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PilihItem : Page
    {
        public PilihItem()
        {
                List<ProsesItem> listItem = new List<ProsesItem>();
                TambahItem koleksiItem = new TambahItem();
                koleksiItem.tambahItem();
                listItem = koleksiItem.listItem;
                this.InitializeComponent();

                itemBarang.ItemsSource = listItem;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private List<ProsesItem> listSelectedItem = new List<ProsesItem>();
        private static int hargaTotal = 0;
        public void Klik_Item(object sender, ItemClickEventArgs e)
        {
            var selectedItemFromGrid = e.ClickedItem as ProsesItem;
            int harga = Convert.ToInt32(selectedItemFromGrid.hargaSatuan);
            hargaTotal = hargaTotal + harga;
            listSelectedItem.Add(selectedItemFromGrid);
            itemBarangTerpilih.ItemsSource = null;
            itemBarangTerpilih.ItemsSource = listSelectedItem;
            TextTotalHarga.Text = hargaTotal.ToString();
        }

        private void BtnLanjut_Klik(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CekckoutBeli),listSelectedItem);
        }

        private void backButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
