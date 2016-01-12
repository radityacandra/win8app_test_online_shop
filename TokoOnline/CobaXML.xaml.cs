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
using System.Xml.Linq;
using System.Xml;
using Windows.ApplicationModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TokoOnline
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CobaXML : Page
    {
        private List<ProsesItem> listItem = new List<ProsesItem>();
        public CobaXML()
        {
            this.InitializeComponent();
            
            TambahItem koleksiItem = new TambahItem();
            //koleksiItem.tambahItem();
            //listItem = koleksiItem.listItem;

            //itemBarang.ItemsSource = listItem;
            bacaXML();
            
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
            int harga = Convert.ToInt16(selectedItemFromGrid.hargaSatuan);
            hargaTotal = hargaTotal + harga;
            //listSelectedItem.Add(new ProsesItem(selectedItemFromGrid.namaBarang,  harga, 0,""));
            listSelectedItem.Add(selectedItemFromGrid);
            itemBarangTerpilih.ItemsSource = null;
            itemBarangTerpilih.ItemsSource = listSelectedItem;
            TextTotalHarga.Text = hargaTotal.ToString();
        }

        public void bacaXML()
        {
            string lokasiXML = Path.Combine(Package.Current.InstalledLocation.Path, "Proses/DataBarang.xml");
            XDocument dataXML = XDocument.Load(lokasiXML);

            var dataItem = from query in dataXML.Descendants("item") select new ProsesItemXML
            {
                namaBarang = (string)query.Element("namaBarang"),
                hargaSatuan = (int)query.Element("hargaSatuan"),
                jumlahStok = (int)query.Element("jumlahStok")
            };
            itemBarang.ItemsSource = dataItem;
        }
    }
}
