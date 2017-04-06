using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasBSI1
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;
            Cliente cliente = new Cliente();
            List<Cliente> clientes = new List<Cliente>();

            do
            {
                Console.Clear();
                Console.WriteLine(" -- Sistema de Vendas -- ");
                Console.WriteLine("\n1 - Cadastro de Clientes");
                Console.WriteLine("2 - Lista de Clientes");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("\nDigite a opção desejada: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Cliente -- \n");
                        Console.WriteLine("Digite o nome do cliente: ");
                        cliente.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o CPF do cliente: ");
                        cliente.Cpf = Console.ReadLine();
                        clientes.Add(cliente);
                        Console.WriteLine("Cliente gravado com sucesso!");
                        Console.WriteLine("Nome do cliente: " + cliente.Nome);
                        Console.WriteLine("Cliente: " + cliente);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(" -- Listar Clientes -- \n");
                        for (int i = 0; i < clientes.Count; i++)
                        {
                            Console.WriteLine("Cliente: " + clientes[i]);
                        }
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Saindo...");
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
