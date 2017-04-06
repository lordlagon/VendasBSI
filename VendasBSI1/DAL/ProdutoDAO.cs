using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBSI1.Model;

namespace VendasBSI1.DAL
{
    class ProdutoDAO
    {
        private static List<Produto> produtos = new List<Produto>();

        public static bool AdicionarProduto(Produto produto)
        {
            if (BuscarProdutoPorNome(produto) != null)
            {
                return false;
            }
            produtos.Add(produto);
            return true;
        }

        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            foreach (Produto produtoCadastrado in produtos)
            {
                if (produto.Nome.Equals(produtoCadastrado.Nome))
                {
                    return produtoCadastrado;
                }
            }
            return null;
        }

        public static List<Produto> RetornarLista()
        {
            return produtos;
        }

    }
}
