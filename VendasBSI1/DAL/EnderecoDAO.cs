using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBSI1.Model;

namespace VendasBSI1.DAL
{
    class EnderecoDAO
    {
        private static List<Endereco> enderecos = new List<Endereco>();

        public static bool AdicionarEndereco(Endereco endereco)
        {
            if (BuscarEnderecoPorCep(endereco) != null)
            {
                return false;
            }
            enderecos.Add(endereco);
            return true;
        }

        public static Endereco BuscarEnderecoPorCep(Endereco endereco)
        {
            foreach (Endereco enderecoCadastrado in enderecos)
            {
                if (endereco.Cep.Equals(enderecoCadastrado.Cep))
                {
                    return enderecoCadastrado;
                }
            }
            return null;
        }

        public static List<Endereco> RetornarLista()
        {
            return enderecos;
        }
    }
}
