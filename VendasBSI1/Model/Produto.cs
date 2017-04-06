using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasBSI1.Model
{
    class Produto
    {
        public string Nome { get; set;  }
        public double Preco { get; set; }
        public double Markup { get; set; }

        public override string ToString()
        {
            return "Nome: " + Nome + " Preço: " + Preco;
        }
    }
}
