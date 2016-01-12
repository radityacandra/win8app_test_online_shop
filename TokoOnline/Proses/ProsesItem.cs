using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokoOnline.Proses
{
    public class ProsesItem
    {
        public string namaBarang { get; set; }
        public int hargaSatuan { get; set; }
        public int jumlahStok { get; set; }
        public string lokasiGambar { get; set; }
        public int kuantitasBeli { get; set; }

        public ProsesItem(string terimaNamaItem, int terimaHarga, int terimaStok, string terimaGambar)
        {
            namaBarang = terimaNamaItem;
            hargaSatuan = terimaHarga;
            jumlahStok = terimaStok;
            lokasiGambar = "/Assets/"+terimaGambar;
        }
        
    }

    class ProsesItemXML
    {
        public string namaBarang { get; set; }
        public int hargaSatuan { get; set; }
        public int jumlahStok { get; set; }
        public string lokasiGambar { get; set; }
    }
}
