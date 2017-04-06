using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBSI1.Model;

namespace VendasBSI1.DAL
{
    class VendedorDAO
    {
        private static List<Vendedor> vendedores = new List<Vendedor>();

        public static bool AdicionarVendedor(Vendedor vendedor)
        {
            if (BuscarVendedorPorCPF(vendedor) != null)
            {
                return false;
            }
            vendedores.Add(vendedor);
            return true;
        }

        public static Vendedor BuscarVendedorPorCPF(Vendedor vendedor)
        {
            foreach (Vendedor vendedorCadastrado in vendedores)
            {
                if (vendedor.Cpf.Equals(vendedorCadastrado.Cpf))
                {
                    return vendedorCadastrado;
                }
            }
            return null;
        }

        public static List<Vendedor> RetornarLista()
        {
            return vendedores;
        }

    }
}
