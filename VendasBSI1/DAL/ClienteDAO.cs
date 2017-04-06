using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBSI1.Model;

namespace VendasBSI1.DAL
{
    class ClienteDAO
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public static bool AdicionarCliente(Cliente cliente)
        {
            if (BuscarClientePorCPF(cliente) != null)
            {
                return false;
            }
            clientes.Add(cliente);
            return true;
        }

        public static Cliente BuscarClientePorCPF(Cliente cliente)
        {
            foreach (Cliente clienteCadastrado in clientes)
            {
                if (cliente.Cpf.Equals(clienteCadastrado.Cpf))
                {
                    return clienteCadastrado;
                }
            }
            return null;
        }

        public static List<Cliente> RetornarLista()
        {
            return clientes;
        }

    }
}
