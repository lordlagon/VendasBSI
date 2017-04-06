using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasBSI1.Model
{
    class Endereco
    {
        public string nomeRua { get; set; }
        public string Cep { get; set; }

        //Construtores
        public Endereco(string cep)
        {
            Cep = cep;
        }

        public Endereco() {}

        //ToString
        public override string ToString()
        {
            return "Rua: " + nomeRua + " CEP: " + Cep;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
