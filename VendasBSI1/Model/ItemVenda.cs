using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasBSI1.Model
{
    class ItemVenda
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }

        public ItemVenda()
        {
            Produto = new Produto();
        }

    }
}
