using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokoOnline.Proses
{
    class HargaPajak : HargaBarang
    {
        private List<ProsesItem> listTerima= new List<ProsesItem>();
        public override double harga(List<ProsesItem> itemDibeli)
        {
            double hargaPajak = 0;
            hargaPajak = base.harga(itemDibeli) * 0.1;
            listTerima = itemDibeli;
            return hargaPajak;
        }

        public double hargaTotal()
        {
            double hargaTotal;
            hargaTotal = base.harga(listTerima) + harga(listTerima);
            return hargaTotal;
        }
    }
}
