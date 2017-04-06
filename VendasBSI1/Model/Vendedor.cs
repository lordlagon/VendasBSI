using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasBSI1.Model
{
    class Vendedor
    {
        public string Nome { get; set;  }
        public string Cpf { get; set; }
        public double Comissao { get; set; }

        public override string ToString()
        {
            return "Nome: " + Nome + " CPF: " + Cpf;
        }
    }
}
