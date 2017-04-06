using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBSI1.Model;

namespace VendasBSI1.DAL
{
    class Dados
    {
        public static void Inicializar()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente()
                {
                    Nome = "Diogo",
                    Cpf = "1"
                },
                new Cliente()
                {
                    Nome = "José",
                    Cpf = "2"
                },
                new Cliente()
                {
                    Nome = "Maria",
                    Cpf = "3"
                },
                new Cliente()
                {
                    Nome = "Andre",
                    Cpf = "4"
                }
            };
            List<Vendedor> vendedores = new List<Vendedor>
            {
                new Vendedor()
                {
                    Nome = "Felipe",
                    Cpf = "5"
                },
                new Vendedor()
                {
                    Nome = "Augusto",
                    Cpf = "6"
                },
                new Vendedor()
                {
                    Nome = "Rafaela",
                    Cpf = "7"
                },
            };
            List<Produto> produtos = new List<Produto>
            {
                new Produto()
                {
                    Nome = "Arroz",
                    Markup = 2,
                    Preco = 2
                },
                new Produto()
                {
                    Nome = "Feijão",
                    Markup = 3,
                    Preco = 3
                },
                new Produto()
                {
                    Nome = "Macarrão",
                    Markup = 4,
                    Preco = 4
                },
            };
            List<Endereco> enderecos = new List<Endereco>()
            {
                new Endereco()
                {
                    nomeRua = "Salgado",
                    Cep = "000"
                    
                },
                new Endereco()
                {
                    nomeRua = "Verdura",
                    Cep = "001"

                },
                new Endereco()
                {
                    nomeRua = "Tempero",
                    Cep = "002"

                },
            };
            clientes.ForEach(x => ClienteDAO.AdicionarCliente(x));
            vendedores.ForEach(x => VendedorDAO.AdicionarVendedor(x));
            produtos.ForEach(x => ProdutoDAO.AdicionarProduto(x));
            enderecos.ForEach(x => EnderecoDAO.AdicionarEndereco(x));
        }
    }
}
