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
    public sealed partial class CekckoutBeli : Page
    {
        public CekckoutBeli()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        public List<ProsesItem> listItemDibeli = new List<ProsesItem>(); 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            listItemDibeli = e.Parameter as List<ProsesItem>;
            itemBarangTerpilih.ItemsSource = listItemDibeli;
            HargaBarang hargaBarang = new HargaBarang();
            HargaPajak harga = new HargaPajak();
            outputTotalHarga.Text = "Rp. " + hargaBarang.harga(listItemDibeli).ToString();
            outputPajak.Text = "Rp. " + harga.harga(listItemDibeli).ToString();
            outputDibayar.Text = "Rp. " + harga.hargaTotal().ToString();
        }

        public string jenisKelamin;
        private void JenisKelamin_check(object sender, RoutedEventArgs e)
        {
            if (inputKelamin.IsChecked == true)
            {
                jenisKelamin = "laki";
            }
            else
            {
                jenisKelamin = "perempuan";
            }
        }

        private void submit_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private List<ProsesItem> listPilihHapus = new List<ProsesItem>();
        private void btnHapus_click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = 0;
                for (int i = 0; i < listPilihHapus.Count; i++)
                {
                    ProsesItem cariElemenList = listItemDibeli.Where<ProsesItem>(x => x.namaBarang == arrayNamaBarang[i]).Single<ProsesItem>();
                    index = listItemDibeli.IndexOf(cariElemenList);
                    listItemDibeli.RemoveAt(index);
                }

                counter = 0;
                itemBarangTerpilih.ItemsSource = null;
                itemBarangTerpilih.ItemsSource = listItemDibeli;
                HargaBarang hargaBarang = new HargaBarang();
                HargaPajak harga = new HargaPajak();
                outputTotalHarga.Text = "Rp. " + hargaBarang.harga(listItemDibeli).ToString();
                outputPajak.Text = "Rp. " + harga.harga(listItemDibeli).ToString();
                outputDibayar.Text = "Rp. " + harga.hargaTotal().ToString();
                listPilihHapus.Clear();
            }
            catch
            {
            }
        }

        public string[] arrayNamaBarang = new string[100];
        static int counter;
        private void pilih_hapus(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ProsesItem itemDipilih = e.AddedItems[0] as ProsesItem;
                arrayNamaBarang[counter] = itemDipilih.namaBarang;
                listPilihHapus.Add(itemDipilih);
                counter++;
            }
            catch
            {
            }
        }

        private void backButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PilihItem));
        }
    }
}
