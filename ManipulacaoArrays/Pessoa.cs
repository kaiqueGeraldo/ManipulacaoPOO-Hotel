using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoArrays
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Genero { get; set; }
        public string Profissao { get; set; }

        public ICollection<Reserva> Reservas { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string nome, int idade, string genero, string profissao)
        {
            Nome = nome;
            Idade = idade;
            Genero = genero;
            Profissao = profissao;
            Reservas = new List<Reserva>();
        }
    }
}