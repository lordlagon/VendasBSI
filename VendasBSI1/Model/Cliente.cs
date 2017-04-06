using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasBSI1.Model
{
    class Cliente
    {
        //C#
        public string Nome { get; set;  }
        public string Cpf { get; set; }

        //Construtores
        public Cliente(string nome)
        {
            Nome = nome;
        }

        public Cliente()
        {

        }


        //ToString
        public override string ToString()
        {
            return "Nome: " + Nome + " CPF: " + Cpf;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        //JAVA
        //private string nome;
        //private string cpf;

        //public void setNome(string nome)
        //{
        //    this.nome = nome;
        //}

        //public string getNome()
        //{
        //    return this.nome;
        //}
    }
}
