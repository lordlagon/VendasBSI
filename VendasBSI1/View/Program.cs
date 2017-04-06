using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBSI1.DAL;
using VendasBSI1.Model;

namespace VendasBSI1.View
{
    class Program
    {
        static void Main(string[] args)
        {
            Dados.Inicializar();
            string opcao, opcaoVenda;
            double totalItem = 0, totalVenda = 0, totalGeral = 0;
            Cliente cliente = new Cliente();
            Vendedor vendedor = new Vendedor();
            Produto produto = new Produto();
            Venda venda = new Venda();
            ItemVenda itemVenda = new ItemVenda();
            Endereco endereco = new Endereco();

            do
            {
                Console.Clear();
                Console.WriteLine(" -- Sistema de Vendas -- ");
                Console.WriteLine("\n1 - Cadastro de Cliente");
                Console.WriteLine("2 - Lista de Clientes");
                Console.WriteLine("3 - Cadastro de Vendedor");
                Console.WriteLine("4 - Lista de Vendedores");
                Console.WriteLine("5 - Cadastro de Produto");
                Console.WriteLine("6 - Lista de Produtos");
                Console.WriteLine("7 - Registrar vendas");
                Console.WriteLine("8 - Listar vendas");
                Console.WriteLine("9 - Listar vendas por cliente");
                Console.WriteLine("10 - Listar vendas por Endereço");
                Console.WriteLine("11 - Cadastrar Endereço");
                Console.WriteLine("12 - Listar Endereço");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("\nDigite a opção desejada: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        cliente = new Cliente();
                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Cliente -- \n");
                        Console.WriteLine("Digite o nome do cliente: ");
                        cliente.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o CPF do cliente: ");
                        cliente.Cpf = Console.ReadLine();

                        if (ClienteDAO.AdicionarCliente(cliente) == true)
                        {
                            Console.WriteLine("Cliente gravado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível adicionar o cliente!");
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine(" -- Listar Clientes -- \n");
                        foreach (Cliente clienteCadastrado in ClienteDAO.RetornarLista())
                        {
                            Console.WriteLine("Cliente: " + clienteCadastrado);
                        }
                        break;

                    case "3":
                        vendedor = new Vendedor();
                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Vendedor -- \n");
                        Console.WriteLine("Digite o nome do vendedor: ");
                        vendedor.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o CPF do vendedor: ");
                        vendedor.Cpf = Console.ReadLine();
                        Console.WriteLine("Digite a taxa de comissão: ");
                        vendedor.Comissao = Convert.ToDouble(Console.ReadLine());

                        if (VendedorDAO.AdicionarVendedor(vendedor) == true)
                        {
                            Console.WriteLine("Vendedor gravado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível adicionar o vendedor!");
                        }
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine(" -- Listar Vendedores -- \n");
                        foreach (Vendedor vendedorCadastrado in VendedorDAO.RetornarLista())
                        {
                            Console.WriteLine("Vendedor: " + vendedorCadastrado);
                        }
                        break;

                    case "5":
                        produto = new Produto();
                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Produto -- \n");
                        Console.WriteLine("Digite o nome do produto: ");
                        produto.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o preço do produto: ");
                        produto.Preco = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Digite o markup do produto: ");
                        produto.Markup = Convert.ToDouble(Console.ReadLine());

                        if (ProdutoDAO.AdicionarProduto(produto) == true)
                        {
                            Console.WriteLine("Produto gravado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível adicionar o produto!");
                        }
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine(" -- Listar Produtos -- \n");
                        foreach (Produto produtoCadastrado in ProdutoDAO.RetornarLista())
                        {
                            Console.WriteLine("Produto: " + produtoCadastrado);
                        }
                        break;

                    case "7":
                        venda = new Venda();
                        cliente = new Cliente();
                        vendedor = new Vendedor();
                        produto = new Produto();
                        itemVenda = new ItemVenda();
                        endereco = new Endereco();

                        Console.Clear();
                        Console.WriteLine(" -- Registrar Venda -- \n");

                        Console.WriteLine("Digite o CPF do cliente: ");
                        cliente.Cpf = Console.ReadLine();
                        cliente = ClienteDAO.BuscarClientePorCPF(cliente);
                        if (cliente != null)
                        {
                            venda.Cliente = cliente;
                            Console.WriteLine("Digite o CPF do vendedor: ");
                            vendedor.Cpf = Console.ReadLine();
                            vendedor = VendedorDAO.BuscarVendedorPorCPF(vendedor);
                            if (vendedor != null)
                            {
                                venda.Vendedor = vendedor;
                                do
                                {
                                    itemVenda = new ItemVenda();
                                    produto = new Produto();
                                    Console.WriteLine("Digite o nome do produto: ");
                                    produto.Nome = Console.ReadLine();
                                    produto = ProdutoDAO.BuscarProdutoPorNome(produto);
                                    if (produto != null)
                                    {
                                        itemVenda.Produto = produto;
                                        Console.WriteLine("Digite a quantidade do produto:");
                                        itemVenda.Quantidade = Convert.ToInt32(Console.ReadLine());
                                        itemVenda.PrecoUnitario = produto.Markup * produto.Preco;
                                        venda.Produtos.Add(itemVenda);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Produto não encontrado!");
                                    }
                                    Console.WriteLine("Deseja adicionar mais produtos?");
                                    opcaoVenda = Console.ReadLine();
                                } while (opcaoVenda.ToUpper().Equals("S"));

                                Console.WriteLine("Digite o CEP do Endereço: ");
                                endereco.Cep = Console.ReadLine();
                                endereco = EnderecoDAO.BuscarEnderecoPorCep(endereco);
                                if (endereco != null)
                                {
                                    venda.Endereco = endereco;
                                }
                                else
                                {
                                    Console.WriteLine("Endereço não encontrado!");
                                }
                                venda.DataDaVenda = DateTime.Now;
                                VendaDAO.AdicionarVenda(venda);
                                Console.WriteLine("Venda adicionada com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Vendedor não encontrado!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cliente não encontrado!");
                        }
                        break;
                    case "8":
                        Console.Clear();
                        Console.WriteLine(" -- Listar Venda -- \n");
                        totalGeral = 0;
                        foreach (Venda vendaCadastrada in VendaDAO.RetornarLista())
                        {
                            totalVenda = 0;
                            Console.WriteLine("\nCliente: " + vendaCadastrada.Cliente.Nome);
                            Console.WriteLine("Vendedor: " + vendaCadastrada.Vendedor.Nome);
                            Console.WriteLine("Endereço de Entrega: Rua " + vendaCadastrada.Endereco.nomeRua);
                            Console.WriteLine("Data: " + vendaCadastrada.DataDaVenda.ToString());

                            foreach (ItemVenda itemVendaCadastrado in vendaCadastrada.Produtos)
                            {
                                Console.WriteLine("\n\tProduto: " + itemVendaCadastrado.Produto.Nome);
                                Console.WriteLine("\tQuantidade: " + itemVendaCadastrado.Quantidade);
                                Console.WriteLine("\tPreço: " + itemVendaCadastrado.PrecoUnitario.ToString("C2"));
                                totalItem = itemVendaCadastrado.Quantidade * itemVendaCadastrado.PrecoUnitario;
                                Console.WriteLine("\tTotal: " + totalItem.ToString("C2"));
                                //totalVenda = totalVenda + totalItem;
                                totalVenda += totalItem;
                            }
                            Console.WriteLine("\t\nTotal da venda: " + totalVenda.ToString("C2"));
                            totalGeral += totalVenda;
                        }
                        Console.WriteLine("Total da venda: " + totalGeral.ToString("C2"));
                        break;
                    case "9":
                        cliente = new Cliente();
                        Console.Clear();

                        Console.WriteLine("Digite o CPF do cliente: ");
                        cliente.Cpf = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(" -- Listar Venda por cliente -- \n");
                        totalGeral = 0;

                        foreach (Venda vendaCadastrada in VendaDAO.BuscarVendasPorCliente(cliente))
                        {
                            totalVenda = 0;
                            Console.WriteLine("\nCliente: " + vendaCadastrada.Cliente.Nome);
                            Console.WriteLine("Vendedor: " + vendaCadastrada.Vendedor.Nome);
                            Console.WriteLine("Endereço de Entrega: Rua " + vendaCadastrada.Endereco.nomeRua);
                            Console.WriteLine("Data: " + vendaCadastrada.DataDaVenda.ToString());
                            foreach (ItemVenda itemVendaCadastrado in vendaCadastrada.Produtos)
                            {
                                Console.WriteLine("\n\tProduto: " + itemVendaCadastrado.Produto.Nome);
                                Console.WriteLine("\tQuantidade: " + itemVendaCadastrado.Quantidade);
                                Console.WriteLine("\tPreço: " + itemVendaCadastrado.PrecoUnitario.ToString("C2"));
                                totalItem = itemVendaCadastrado.Quantidade * itemVendaCadastrado.PrecoUnitario;
                                Console.WriteLine("\tTotal: " + totalItem.ToString("C2"));
                                totalVenda += totalItem;
                            }
                            Console.WriteLine("\t\nTotal da venda: " + totalVenda.ToString("C2"));
                            totalGeral += totalVenda;
                        }
                        Console.WriteLine("\nTotal geral: " + totalGeral.ToString("C2"));
                        break;

                    case "10":
                        endereco = new Endereco();
                        Console.Clear();
                        Console.WriteLine("Digite o Cep do Endereço: ");
                        endereco.Cep = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(" -- Listar Venda por Endereço -- \n");
                        totalGeral = 0;

                        foreach (Venda vendaCadastrada in VendaDAO.BuscarVendasPorEndereco(endereco))
                        {
                            totalVenda = 0;
                            Console.WriteLine("\nCliente: " + vendaCadastrada.Cliente.Nome);
                            Console.WriteLine("Vendedor: " + vendaCadastrada.Vendedor.Nome);
                            Console.WriteLine("Endereço de Entrega: Rua " + vendaCadastrada.Endereco.nomeRua);
                            Console.WriteLine("Data: " + vendaCadastrada.DataDaVenda.ToString());
                            foreach (ItemVenda itemVendaCadastrado in vendaCadastrada.Produtos)
                            {
                                Console.WriteLine("\n\tProduto: " + itemVendaCadastrado.Produto.Nome);
                                Console.WriteLine("\tQuantidade: " + itemVendaCadastrado.Quantidade);
                                Console.WriteLine("\tPreço: " + itemVendaCadastrado.PrecoUnitario.ToString("C2"));
                                totalItem = itemVendaCadastrado.Quantidade * itemVendaCadastrado.PrecoUnitario;
                                Console.WriteLine("\tTotal: " + totalItem.ToString("C2"));
                                totalVenda += totalItem;
                            }
                            Console.WriteLine("\t\nTotal da venda: " + totalVenda.ToString("C2"));
                            totalGeral += totalVenda;
                        }
                        Console.WriteLine("\nTotal geral: " + totalGeral.ToString("C2"));
                        break;

                    case "11":
                        endereco = new Endereco();
                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Endereço -- \n");
                        Console.WriteLine("Digite o nome da Rua: ");
                        endereco.nomeRua = Console.ReadLine();
                        Console.WriteLine("Digite o Cep do Endereço: ");
                        endereco.Cep = Console.ReadLine();

                        if (EnderecoDAO.AdicionarEndereco(endereco) == true)
                        {
                            Console.WriteLine("Endereço gravado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível adicionar o Endereço!");
                        }
                        break;
                    case "12":
                        Console.Clear();
                        Console.WriteLine(" -- Listar Endereços -- \n");
                        foreach (Endereco enderecoCadastrado in EnderecoDAO.RetornarLista())
                        {
                            Console.WriteLine("Endereço: " + enderecoCadastrado);
                        }
                        break;

                    case "0":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("Aperte uma tecla para continuar...");
                Console.ReadKey();
            } while (!opcao.Equals("0"));
        }
    }
}
