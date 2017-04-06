using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasBSI1.Model
{
    class Venda
    {
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<ItemVenda> Produtos { get; set; }

        public Endereco Endereco { get; set; }

        public DateTime DataDaVenda { get; set; }
        
        public Venda()
        {
            Cliente = new Cliente();
            Vendedor = new Vendedor();
            Produtos = new List<ItemVenda>();
            Endereco = new Endereco();
        }
    }
}
