using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoArrays
{
    public class Hotel
    {
        public static List<Pessoa> Pessoas { get; set; }
        public static List<Suite> Suites { get; set; }
        public static List<Reserva> Reservas { get; set; }

        public Hotel()
        {
            Pessoas = new List<Pessoa>();
            Suites = new List<Suite>();
            Reservas = new List<Reserva>();
        }

        // método iniciar
        public static void IniciarHotel()
        {
            Console.WriteLine("Bem-Vindo ao menu do Hotel!");
            bool continuar = true;

            do
            {
                Console.WriteLine("\nO que você deseja fazer? Cadastrar(1); Consultar(2); Listar(3); Sair(4): ");
                int escolha = Escolha();

                switch (escolha)
                {
                    case 1:
                        CadastrarItens.Cadastrar();
                        break;
                    case 2:
                        ConsultarItens.Consultar();
                        break;
                    case 3:
                        ListarItens.Listar();
                        break;
                    case 4:
                        Console.WriteLine("\nEncerrando Programa...");
                        continuar = false;
                        break;
                }

            } while (continuar);
        }

        // fim método iniciar


        // métodos de verificação
        public static int Escolha() // escolha menu
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 4)
            {
                Console.WriteLine("\nEscolha inválida! Tente Novamente. Cadastrar(1); Consultar(2); Listar(3); Sair(4): ");
            }
            return escolha;
        }

        public static int EscolhaCSR() // escolha Cliente/Suíte/Reserva CSR
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 3)
            {
                Console.WriteLine("\nEscolha inválida! Tente Novamente. Cliente(1); Suite(2); Reserva(3): ");
            }
            return escolha;
        }

    }
}
