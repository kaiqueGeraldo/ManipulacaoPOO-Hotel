using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoArrays
{
    public class Hotel
    {
        public List<Pessoa> Pessoas { get; set; }
        public List<Suite> Suites { get; set; }
        public List<Reserva> Reservas { get; set; }

        public Hotel()
        {
            Pessoas = new List<Pessoa>();
            Suites = new List<Suite>();
            Reservas = new List<Reserva>();
        }

        // método iniciar
        public void IniciarHotel()
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
                        Cadastrar();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Listar();
                        break;
                    case 4:
                        Console.WriteLine("\nEncerrando Programa...");
                        continuar = false;
                        break;
                }

            } while (continuar);
        }

        // fim método iniciar



        // método cadastrar
        public void Cadastrar()
        {
            Console.WriteLine("O que você deseja cadastrar?: Cliente(1); Suite(2); Reserva(3): ");
            int escolhaCadastro = EscolhaCSR();

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

        public void CadastrarCliente() // cadastro do cliente
        {
            string loop;
            do
            {
                Console.WriteLine("\nInsira o id do cliente: ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Por favor, insira um número válido para o id do cliente: "); // filtragem de erro
                }

                Console.WriteLine("Insira o nome do cliente: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Insira a idade do cliente: ");
                int idade;
                while (!int.TryParse(Console.ReadLine(), out idade))
                {
                    Console.WriteLine("Por favor, insira um número válido para a idade do cliente: ");  // filtragem de erro
                }

                Console.WriteLine("Insira o gênero do cliente: ");
                string genero = Console.ReadLine();

                Console.WriteLine("Insira a profissão do cliente: ");
                string profissao = Console.ReadLine();

                Pessoa pessoa = new Pessoa { Id = id, Nome = nome, Idade = idade, Genero = genero, Profissao = profissao };
                Pessoas.Add(pessoa);

                Console.WriteLine($"\nCliente {nome} cadastrado com sucesso!\n\nDeseja cadastrar outro cliente? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para um novo cadastro
        }

        public void CadastrarSuite() // cadastro de suíte
        {
            string loop;
            do
            {
                Console.WriteLine("\nInsira o número da suíte: ");
                int numero;
                while (!int.TryParse(Console.ReadLine(), out numero))
                {
                    Console.WriteLine("Por favor, insira um número válido para o id da suíte: "); // filtragem de erro
                }

                Console.WriteLine("Insira a capacidade da suíte: ");
                int capacidade;
                while (!int.TryParse(Console.ReadLine(), out capacidade))
                {
                    Console.WriteLine("Por favor, insira um número válido para a capacidade da suite: "); // filtragem de erro
                }

                Console.WriteLine("Insira o valor da diária da suíte: ");
                double valorDiaria;
                while (!double.TryParse(Console.ReadLine(), out valorDiaria))
                {
                    Console.WriteLine("Por favor, insira um número válido para o valor da diária da suíte: "); // filtragem de erro
                }

                Suite suite = new Suite { Numero = numero, Capacidade = capacidade, ValorDiaria = valorDiaria };
                Suites.Add(suite);

                Console.WriteLine($"\nSuíte número {numero} cadastrada com sucesso!\n\nDeseja cadastrar outra suíte? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para um novo cadastro
        }

        public void CadastrarReserva() // cadastro de reserva
        {
            string loop = "";
            do
            {
                Console.WriteLine("\nInsira id da reserva: ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Por favor, insira um número válido para o id da reserva: "); // filtragem de erro
                }

                Console.WriteLine("Insira id do cliente que fez a reserva: ");
                int pessoaId;
                while (!int.TryParse(Console.ReadLine(), out pessoaId))
                {
                    Console.WriteLine("Por favor, insira um número válido para o id do cliente: "); // filtragem de erro
                }

                Console.WriteLine("Insira o número da suíte que estava na reserva: "); 
                int suiteNumero;
                while (!int.TryParse(Console.ReadLine(), out suiteNumero))
                {
                    Console.WriteLine("Por favor, insira um número válido para o número da suíte: "); // filtragem de erro
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

                Suite suite = Suites.FirstOrDefault(s => s.Numero == suiteNumero); // importação da calsse suíte para dentro do método

                if (suite == null)
                {
                    Console.WriteLine("Suite não encontrada. Verifique o número da suíte e tente novamente.");
                    continue;
                }

                Console.WriteLine($"\nReserva número {id} cadastrada com sucesso.\nValor final: R${CalcularValorTotal(dataEntrada, dataSaida, suite)}!");
                Console.WriteLine("\nDeseja cadastrar outra reserva? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para um novo cadastro
        }

        // método para calcular valor total  
        static double CalcularValorTotal(DateTime dataEntrada, DateTime dataSaida, Suite suite)
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

        // fim método valor total

        // fim método cadastrar



        // método consultar
        public void Consultar()
        {
            Console.WriteLine("\nO que você deseja cadastrar?: Cliente(1); Suite(2); Reserva(3): ");
            int escolhaCadastro = EscolhaCSR();

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

        public void ConsultarCliente() // consulta de cliente
        {
            string loop;
            do
            {
                Console.WriteLine("\nInsira o nome do cliente que deseja consultar: ");
                string ConsultarNomeCliente = Console.ReadLine();

                Pessoa pessoa = BuscarCliente(ConsultarNomeCliente); // método para consultagem se existe o nome inserido
                if (pessoa != null)
                {
                    Console.WriteLine($"Nome: {pessoa.Nome} - Idade: {pessoa.Idade} - Gênero: {pessoa.Genero} - Profissão: {pessoa.Profissao}");
                }
                else
                {
                    Console.WriteLine($"Cliente '{ConsultarNomeCliente}' não encontrado no sistema.");
                }

                Console.WriteLine("\nDeseja consultar outro cliente? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para uma nova consulta
        }

        private Pessoa BuscarCliente(string nome) // método para consultagem se existe o nome inserido
        {
            foreach (Pessoa pessoa in Pessoas)
            {
                if (pessoa.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                {
                    return pessoa;
                }
            }
            return null;
        }

        public void ConsultarSuite() // consulta de suíte
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
                        Console.WriteLine($"Número: {suite.Numero} - Capacidade: {suite.Capacidade} - Valor Diária: R${suite.ValorDiaria}");
                    }
                    else
                    {
                        Console.WriteLine($"Suíte '{ConsultarNumeroSuite}' não encontrada no sistema.");
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

        private Suite BuscarSuite(int numero) // método para consultagem se existe o numero inserido
        {
            foreach (Suite suite in Suites)
            {
                if (suite.Numero == numero)
                {
                    return suite;
                }
            }
            return null;
        }

        public void ConsultarReserva() // consulta de reserva
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
                        Console.WriteLine($"Id: {reserva.Id} - Id Cliente: {reserva.PessoaId} - Número da suíte: {reserva.SuiteNumero} - Data entrada: {reserva.DataEntrada} - Data saída: {reserva.DataSaida} - Valor Final: R${reserva.ValorFinal}");
                    }
                    else
                    {
                        Console.WriteLine($"Reserva '{ConsultarIdReserva}' não encontrada no sistema.");
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

        private Reserva BuscarReserva(int id) // método para consultagem se existe o id inserido
        {
            foreach (Reserva reserva in Reservas)
            {
                if (reserva.Id == id)
                {
                    return reserva;
                }
            }
            return null;
        }

        // fim método consultar



        // método listar
        public void Listar()
        {
            Console.WriteLine("\nO que você deseja listar?: Cliente(1); Suite(2); Reserva(3): ");
            int escolhaCadastro = EscolhaCSR();

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

        public void ListarClientes() // listagem de clientes
        {
            Console.WriteLine("\nClientes:\n");
            for (int i = 0; i < Pessoas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Pessoas[i].Nome} - Idade: {Pessoas[i].Idade} - Gênero: {Pessoas[i].Genero} - Profissão: {Pessoas[i].Profissao}");
            }
        }

        public void ListarSuites() // listagem de suítes
        {
            Console.WriteLine("\nSuítes:\n");
            for (int i = 0; i < Suites.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Número: {Suites[i].Numero} - Capacidade: {Suites[i].Capacidade} - Valor Diária: R${Suites[i].ValorDiaria}");
            }
        }

        public void ListarReservas() // listagem de reservas
        {
            Console.WriteLine("\nReservas:\n");
            for (int i = 0; i < Reservas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Id: {Reservas[i].Id} - Id Cliente: {Reservas[i].PessoaId} - Número da suíte: {Reservas[i].SuiteNumero} - Data entrada: {Reservas[i].DataEntrada} - Data saída: {Reservas[i].DataSaida} - Valor Final: R${Reservas[i].ValorFinal}");
            }
        }

        // fim método listar


        // filtragem de erros
        public int Escolha() // escolha menu
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 4)
            {
                Console.WriteLine("\nEscolha inválida! Tente Novamente. Cadastrar(1); Consultar(2); Listar(3); Sair(4): ");
            }
            return escolha;
        }

        public int EscolhaCSR() // escolha Cliente/Suíte/Reserva CSR
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
