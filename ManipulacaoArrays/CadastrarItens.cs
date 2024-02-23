using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoArrays
{
    public class CadastrarItens
    {
        // método cadastrar
        public static void Cadastrar()
        {
            Console.WriteLine("O que você deseja cadastrar?: Cliente(1); Suite(2); Reserva(3): ");
            int escolhaCadastro = Hotel.EscolhaCSR();

            switch (escolhaCadastro)
            {
                case 1:
                    CadastrarCliente();
                    break;
                case 2:
                    CadastrarSuite();
                    break;
                case 3:
                    CadastrarReserva();
                    break;
            }
        }

        public static void CadastrarCliente() // cadastro do cliente
        {
            string loop;
            do
            {
                Console.WriteLine("\nInsira o id do cliente: ");
                int pessoaId;
                while (!int.TryParse(Console.ReadLine(), out pessoaId) || pessoaId <= 0 || PessoaExiste(pessoaId)) // filtragem de erro
                {
                    if (PessoaExiste(pessoaId))
                    {
                        Console.WriteLine("ID da pessoa já existe. Por favor, insira um ID diferente: ");
                    }
                    else
                    {
                        Console.WriteLine("Por favor, insira um número válido para o id do cliente: ");
                    }
                }

                Console.WriteLine("Insira o nome do cliente: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Insira a idade do cliente: ");
                int idade;
                while (!int.TryParse(Console.ReadLine(), out idade) || idade < 18) // filtragem de erro
                {
                    if (idade < 18)
                    {
                        Console.WriteLine("Clientes menores de idade não podem ser cadastrados: ");
                    }
                    else
                    {
                        Console.WriteLine("Por favor, insira um número válido para a idade do cliente: ");
                    }
                }

                Console.WriteLine("Insira o gênero do cliente: ");
                string genero = Console.ReadLine();

                Console.WriteLine("Insira a profissão do cliente: ");
                string profissao = Console.ReadLine();

                Pessoa pessoa = new Pessoa { Id = pessoaId, Nome = nome, Idade = idade, Genero = genero, Profissao = profissao };
                Hotel.Pessoas.Add(pessoa);

                Console.WriteLine($"\nCliente {nome} cadastrado com sucesso!\n\nDeseja cadastrar outro cliente? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para um novo cadastro
        }

        public static void CadastrarSuite() // cadastro de suíte
        {
            string loop;
            do
            {
                Console.WriteLine("\nInsira o número da suíte: ");
                int suiteNumero;
                while (!int.TryParse(Console.ReadLine(), out suiteNumero) || suiteNumero <= 0 || SuiteExiste(suiteNumero)) // filtragem de erro
                {
                    if (SuiteExiste(suiteNumero))
                    {
                        Console.WriteLine("O número da suíte já cadastrado. Por favor insira um número diferente: ");
                    }
                    else
                    {
                        Console.WriteLine("Por favor, insira um número válido para o id da suíte: ");
                    }
                }

                Console.WriteLine("Insira a capacidade da suíte: ");
                int capacidade;
                while (!int.TryParse(Console.ReadLine(), out capacidade) || capacidade < 0) // filtragem de erro
                {
                    Console.WriteLine("Por favor, insira um número válido para a capacidade da suite: ");
                }

                Console.WriteLine("Insira o valor da diária da suíte: ");
                double valorDiaria;
                while (!double.TryParse(Console.ReadLine(), out valorDiaria) || valorDiaria < 0) // filtragem de erro
                {
                    Console.WriteLine("Por favor, insira um valor válido para o valor da diária da suíte: ");
                }

                Suite suite = new Suite { Numero = suiteNumero, Capacidade = capacidade, ValorDiaria = valorDiaria };
                Hotel.Suites.Add(suite);

                Console.WriteLine($"\nSuíte número {suiteNumero} cadastrada com sucesso!\n\nDeseja cadastrar outra suíte? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para um novo cadastro
        }

        public static void CadastrarReserva() // cadastro de reserva
        {
            string loop = "";
            do
            {
                Console.WriteLine("\nInsira id da reserva: ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id) || id <= 0 || ReservaExiste(id)) // filtragem de erro
                {
                    if (ReservaExiste(id))
                    {
                        Console.WriteLine("O id da reserva já cadastrado. Por favor insira um id diferente: ");
                    }
                    else
                    {
                        Console.WriteLine("Por favor, insira um número válido para o id da reserva: ");
                    }
                }

                Console.WriteLine("Insira id do cliente que fez a reserva: ");
                int pessoaId;
                while (!int.TryParse(Console.ReadLine(), out pessoaId) || !PessoaExiste(pessoaId)) // filtragem de erro
                {
                    Console.WriteLine("ID da pessoa não encontrado. Verifique o ID do cliente e tente novamente: ");
                }

                Console.WriteLine("Insira o número da suíte que estava na reserva: ");
                int suiteNumero;
                while (!int.TryParse(Console.ReadLine(), out suiteNumero) || !SuiteExiste(suiteNumero)) // filtragem de erro
                {
                    Console.WriteLine("Suíte não encontrada. Verifique o número da suíte e tente novamente: ");
                }

                Console.WriteLine("Insira a data de entrada da reserva no formato (dd/mm/aaaa): ");
                DateTime dataEntrada;
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataEntrada)) // filtragem de erro para data
                {
                    Console.WriteLine("Por favor, insira uma data válida no formato dd/mm/aaaa: ");
                }

                Console.WriteLine("Insira a data de saída da reserva no formato (dd/mm/aaaa): ");
                DateTime dataSaida;
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataSaida)) // filtragem de erro para data
                {
                    Console.WriteLine("Por favor, insira uma data válida no formato dd/mm/aaaa: ");
                }

                Pessoa pessoa = Hotel.Pessoas.FirstOrDefault(p => p.Id == pessoaId); // verificação do id inserido
                Suite suite = Hotel.Suites.FirstOrDefault(s => s.Numero == suiteNumero); // verificação do número inserido

                if (pessoa == null)
                {
                    Console.WriteLine("Cliente não encontrada. Verifique o id do cliente e tente novamente.");
                    continue;
                }
                else if (suite == null)
                {
                    Console.WriteLine("Suite não encontrada. Verifique o número da suíte e tente novamente.");
                    continue;
                }

                double valorFinal = CalcularValorTotal(dataEntrada, dataSaida, suite);

                Reserva reserva = new Reserva { Id = id, PessoaId = pessoaId, SuiteNumero = suiteNumero, DataEntrada = dataEntrada, DataSaida = dataSaida, ValorFinal = valorFinal };
                Hotel.Reservas.Add(reserva);

                Console.WriteLine($"\nReserva número {id} cadastrada com sucesso.\nValor final: R${CalcularValorTotal(dataEntrada, dataSaida, suite)}!");
                Console.WriteLine("\nDeseja cadastrar outra reserva? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para um novo cadastro
        }

        // fim método cadastrar



        // itens do método cadastrar
        private static bool PessoaExiste(int pessoaId) // método privado para verificar se o do cliente id existe
        {
            return Hotel.Pessoas.Any(p => p.Id == pessoaId);
        }

        private static bool SuiteExiste(int suiteNumero) // método privado para verificar se o número da suíte existe
        {
            return Hotel.Suites.Any(s => s.Numero == suiteNumero);
        }

        private static bool ReservaExiste(int id) // método privado para verificar se o id da reserva existe
        {
            return Hotel.Reservas.Any(r => r.Id == id);
        }

        public static double CalcularValorTotal(DateTime dataEntrada, DateTime dataSaida, Suite suite) // método para calcular valor total  
        {
            int diasDeEstadia = (int)(dataSaida - dataEntrada).TotalDays;

            double valorTotal;

            if (diasDeEstadia > 10)
            {
                double valorDiariaComDesconto = suite.ValorDiaria * 0.9; // calculo para desconto de 10% caso a hospendagem ultrapasse 10 dias
                valorTotal = diasDeEstadia * valorDiariaComDesconto;
            }
            else
            {
                valorTotal = diasDeEstadia * suite.ValorDiaria;
            }

            return valorTotal;
        }
    }
}