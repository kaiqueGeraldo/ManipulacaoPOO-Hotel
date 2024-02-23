using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoArrays
{
    public class ListarItens
    {
        // método listar
        public static void Listar()
        {
            Console.WriteLine("\nO que você deseja listar?: Cliente(1); Suite(2); Reserva(3): ");
            int escolhaCadastro = Hotel.EscolhaCSR();

            switch (escolhaCadastro)
            {
                case 1:
                    ListarClientes();
                    break;
                case 2:
                    ListarSuites();
                    break;
                case 3:
                    ListarReservas();
                    break;
            }
        }

        public static void ListarClientes() // listagem de clientes
        {
            Console.WriteLine("\nClientes:\n");
            for (int i = 0; i < Hotel.Pessoas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Hotel.Pessoas[i].Nome} - Idade: {Hotel.Pessoas[i].Idade} - Gênero: {Hotel.Pessoas[i].Genero} - Profissão: {Hotel.Pessoas[i].Profissao}");
            }
        }

        public static void ListarSuites() // listagem de suítes
        {
            Console.WriteLine("\nSuítes:\n");
            for (int i = 0; i < Hotel.Suites.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Número: {Hotel.Suites[i].Numero} - Capacidade: {Hotel.Suites[i].Capacidade} - Valor Diária: R${Hotel.Suites[i].ValorDiaria}");
            }
        }

        public static void ListarReservas() // listagem de reservas
        {
            Console.WriteLine("\nReservas:\n");
            for (int i = 0; i < Hotel.Reservas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Id: {Hotel.Reservas[i].Id} - Id Cliente: {Hotel.Reservas[i].PessoaId} - Número da suíte: {Hotel.Reservas[i].SuiteNumero} - Data entrada: {Hotel.Reservas[i].DataEntrada} - Data saída: {Hotel.Reservas[i].DataSaida} - Valor Final: R${Hotel.Reservas[i].ValorFinal}");
            }
        }

        // fim método listar
    }
}