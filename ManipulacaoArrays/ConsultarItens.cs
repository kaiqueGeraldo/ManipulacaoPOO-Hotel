using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoArrays
{
    public class ConsultarItens
    {
        // método consultar
        public static void Consultar()
        {
            Console.WriteLine("\nO que você deseja consultar?: Cliente(1); Suite(2); Reserva(3): ");
            int escolhaCadastro = Hotel.EscolhaCSR();

            switch (escolhaCadastro)
            {
                case 1:
                    ConsultarCliente();
                    break;
                case 2:
                    ConsultarSuite();
                    break;
                case 3:
                    ConsultarReserva();
                    break;
            }
        }

        public static void ConsultarCliente() // consulta de cliente
        {
            string loop;
            do
            {
                Console.WriteLine("\nInsira o nome do cliente que deseja consultar: ");
                string ConsultarNomeCliente = Console.ReadLine();

                Pessoa pessoa = BuscarCliente(ConsultarNomeCliente); // método para consultagem se existe o nome inserido
                if (pessoa != null)
                {
                    Console.WriteLine($"\nNome: {pessoa.Nome} - Idade: {pessoa.Idade} - Gênero: {pessoa.Genero} - Profissão: {pessoa.Profissao}");
                }
                else
                {
                    Console.WriteLine($"\nCliente '{ConsultarNomeCliente}' não encontrado no sistema.");
                }

                Console.WriteLine("\nDeseja consultar outro cliente? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para uma nova consulta
        }

        public static void ConsultarSuite() // consulta de suíte
        {
            string loop;
            do
            {
                Console.WriteLine("\nInsira o número da suíte que deseja consultar: ");
                int ConsultarNumeroSuite;
                if (int.TryParse(Console.ReadLine(), out ConsultarNumeroSuite))
                {
                    Suite suite = BuscarSuite(ConsultarNumeroSuite); // método para consultagem se existe o numero inserido
                    if (suite != null)
                    {
                        Console.WriteLine($"\nNúmero: {suite.Numero} - Capacidade: {suite.Capacidade} - Valor Diária: R${suite.ValorDiaria}");
                    }
                    else
                    {
                        Console.WriteLine($"\nSuíte '{ConsultarNumeroSuite}' não encontrada no sistema.");
                    }
                }
                else
                {
                    Console.WriteLine("\nNúmero de suíte inválido.");
                }

                Console.WriteLine("\nDeseja consultar outra suíte? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para uma nova consulta
        }

        public static void ConsultarReserva() // consulta de reserva
        {
            string loop;
            do
            {
                Console.WriteLine("\nInsira o id da reserva que deseja consultar: ");
                int ConsultarIdReserva;
                if (int.TryParse(Console.ReadLine(), out ConsultarIdReserva))
                {
                    Reserva reserva = BuscarReserva(ConsultarIdReserva); // método para consultagem se existe o id inserido
                    if (reserva != null)
                    {
                        Console.WriteLine($"\nId: {reserva.Id} - Id Cliente: {reserva.PessoaId} - Número da suíte: {reserva.SuiteNumero} - Data entrada: {reserva.DataEntrada} - Data saída: {reserva.DataSaida} - Valor Final: R${reserva.ValorFinal}");
                    }
                    else
                    {
                        Console.WriteLine($"\nReserva '{ConsultarIdReserva}' não encontrada no sistema.");
                    }
                }
                else
                {
                    Console.WriteLine("\nID de reserva inválido.");
                }

                Console.WriteLine("\nDeseja consultar outra reserva? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para uma nova consulta
        }

        // fim método consultar


        //verificações do método consultar
        private static Pessoa BuscarCliente(string nome) // método para consultagem se existe o nome do cliente inserido
        {
            foreach (Pessoa pessoa in Hotel.Pessoas)
            {
                if (pessoa.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                {
                    return pessoa;
                }
            }
            return null;
        }

        private static Suite BuscarSuite(int numero) // método para consultagem se existe o número da suíte inserido
        {
            foreach (Suite suite in Hotel.Suites)
            {
                if (suite.Numero == numero)
                {
                    return suite;
                }
            }
            return null;
        }

        private static Reserva BuscarReserva(int id) // método para consultagem se existe o id da reserva inserido
        {
            foreach (Reserva reserva in Hotel.Reservas)
            {
                if (reserva.Id == id)
                {
                    return reserva;
                }
            }
            return null;
        }
    }
}