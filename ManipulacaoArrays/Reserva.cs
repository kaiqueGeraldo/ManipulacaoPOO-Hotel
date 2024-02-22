using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoArrays
{
    public class Reserva
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public int SuiteNumero { get; set; }
        public Suite Suite { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public double ValorFinal { get; set; }

        public Reserva()
        {
        }
    }
}