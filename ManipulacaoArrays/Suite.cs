using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoArrays
{
    public class Suite
    {
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public double ValorDiaria { get; set; }

        public ICollection<Reserva> Reservas { get; set; }

        public Suite()
        {
        }
    }
}