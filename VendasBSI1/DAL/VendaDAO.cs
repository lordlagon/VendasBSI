using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBSI1.Model;

namespace VendasBSI1.DAL
{
    class VendaDAO
    {
        private static List<Venda> vendas = new List<Venda>();

        public static void AdicionarVenda(Venda venda)
        {
            vendas.Add(venda);
        }

        public static List<Venda> RetornarLista()
        {
            return vendas;
        }

        public static List<Venda> BuscarVendasPorCliente(Cliente cliente)
        {
            List<Venda> vendasAux = new List<Venda>();
            foreach (Venda vendaCadastrada in vendas)
            {
                if (vendaCadastrada.Cliente.Cpf.Equals(cliente.Cpf))
                {
                    vendasAux.Add(vendaCadastrada);
                }
            }
            return vendasAux;

        }

        public static List<Venda> BuscarVendasPorEndereco(Endereco endereco)
        {
            List<Venda> vendasAux = new List<Venda>();
            foreach (Venda vendaCadastrada in vendas)
            {
                if (vendaCadastrada.Endereco.Cep.Equals(endereco.Cep))
                {
                    vendasAux.Add(vendaCadastrada);
                }
            }
            return vendasAux;
        }
    }
}
