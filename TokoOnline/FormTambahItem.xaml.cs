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
    public sealed partial class FormTambahItem : Page
    {
        private List<ProsesItem> listCollectionItem = new List<ProsesItem>();

        //public List<ProsesItem> koleksiTotal()
        //{
        //    return listCollectionItem;
        //}

        public FormTambahItem()
        {
            TambahItem koleksiItem = new TambahItem();
            koleksiItem.tambahItem();
            listCollectionItem = koleksiItem.listItem;
            this.InitializeComponent();

            itemBarang.ItemsSource = listCollectionItem;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Klik_TambahItem(object sender, RoutedEventArgs e)
        {
            int hargaBarang, jumlahBarang;
            string namaBarang, lokasiGambar;

            namaBarang = inputNamaBarang.Text;
            hargaBarang = Convert.ToInt32(inputHargaBarang.Text);
            jumlahBarang = Convert.ToInt16(inputKuantitasBarang.Text);
            lokasiGambar = inputGambar.Text;
            listCollectionItem.Add(new ProsesItem(namaBarang, hargaBarang, jumlahBarang, lokasiGambar));
            itemBarang.ItemsSource = null;
            itemBarang.ItemsSource = listCollectionItem;
        }

        private void backButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
