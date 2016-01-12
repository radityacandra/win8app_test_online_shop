using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokoOnline;

namespace TokoOnline.Proses
{
    class HargaBarang
    {
        public virtual double harga(List<ProsesItem> itemDibeli)
        {
            double hargaTotalFinal = 0;
            foreach (ProsesItem harga in itemDibeli)
            {
                hargaTotalFinal = hargaTotalFinal + harga.hargaSatuan;
            }
            return hargaTotalFinal;
        }
    }
}
