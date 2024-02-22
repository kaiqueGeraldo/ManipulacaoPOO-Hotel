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
                Suites.Add(suite);

                Console.WriteLine($"\nSuíte número {suiteNumero} cadastrada com sucesso!\n\nDeseja cadastrar outra suíte? (S/N): ");
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

                Pessoa pessoa = Pessoas.FirstOrDefault(p => p.Id == pessoaId); // verificação do id inserido
                Suite suite = Suites.FirstOrDefault(s => s.Numero == suiteNumero); // verificação do número inserido

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
                Reservas.Add(reserva);

                Console.WriteLine($"\nReserva número {id} cadastrada com sucesso.\nValor final: R${CalcularValorTotal(dataEntrada, dataSaida, suite)}!");
                Console.WriteLine("\nDeseja cadastrar outra reserva? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase)); // loop para um novo cadastro
        }

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

        // itens do método cadastrar
        private bool PessoaExiste(int pessoaId) // método privado para verificar se o do cliente id existe
        {
            return Pessoas.Any(p => p.Id == pessoaId);
        }

        private bool SuiteExiste(int suiteNumero) // método privado para verificar se o número da suíte existe
        {
            return Suites.Any(s => s.Numero == suiteNumero);
        }

        private bool ReservaExiste(int id) // método privado para verificar se o id da reserva existe
        {
            return Reservas.Any(r => r.Id == id);
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


        //itens do método consultar
        private Pessoa BuscarCliente(string nome) // método para consultagem se existe o nome do cliente inserido
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

        private Suite BuscarSuite(int numero) // método para consultagem se existe o número da suíte inserido
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

        private Reserva BuscarReserva(int id) // método para consultagem se existe o id da reserva inserido
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
    }
}
