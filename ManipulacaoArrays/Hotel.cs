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
        public void IniciarLoja()
        {
            Console.WriteLine("Bem-Vindo ao menu do Hotel!");
            Console.WriteLine("O que você deseja fazer? Cadastrar(1); Consultar(2); Listar(3); Sair(4): ");
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
                    Console.WriteLine("Encerrando Programa...");
                    break;
            }
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

        public void CadastrarCliente()
        {
            string loop;
            do
            {
                Console.WriteLine("Insira o id do cliente: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira o nome do cliente: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Insira a idade do cliente: ");
                int idade = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira o gênero do cliente: ");
                string genero = Console.ReadLine();

                Console.WriteLine("Insira a profissão do cliente: ");
                string profissao = Console.ReadLine();

                Pessoa pessoa = new Pessoa { Id = id, Nome = nome, Idade = idade, Genero = genero, Profissao = profissao };
                Pessoas.Add(pessoa);

                Console.WriteLine($"Cliente {nome} cadastrado com sucesso!\n\nDeseja cadastrar outro cliente? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase));
        }

        public void CadastrarSuite()
        {
            string loop;
            do
            {
                Console.WriteLine("Insira o número da suíte: ");
                int numero = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira a capacidade da suíte: ");
                int capacidade = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira o valor da diária da suíte: ");
                double valorDiaria = double.Parse(Console.ReadLine());

                Suite suite = new Suite { Numero = numero, Capacidade = capacidade, ValorDiaria = valorDiaria };
                Suites.Add(suite);

                Console.WriteLine($"Suíte número {numero} cadastrada com sucesso!\n\nDeseja cadastrar outra suíte? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase));
        }

        public void CadastrarReserva()
        {
            string loop;
            do
            {
                Console.WriteLine("Insira id da reserva: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira id do cliente que fez a reserva: ");
                int pessoaId = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira o número da suíte que estava na reserva: ");
                int suiteNumero = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira a data de entrada da reserva no formato (dd/mm/aaaa): ");
                DateTime dataEntrada = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Insira a data de saída da reserva no formato (dd/mm/aaaa): ");
                DateTime dataSaida = DateTime.Parse(Console.ReadLine());

                Suite suite = Suites.FirstOrDefault(s => s.Numero == suiteNumero);

                if (suite == null)
                {
                    Console.WriteLine("Suite não encontrada. Verifique o número da suíte e tente novamente.");
                    continue;
                }

                Console.WriteLine($"Reserva número {id} cadastrada com sucesso.\n Valor final: R${CalcularValorTotal(dataEntrada, dataSaida, suite)}!\n\nDeseja cadastrar outra suíte? (S/N): ");
                loop = Console.ReadLine();

            } while (Equals("S", StringComparison.OrdinalIgnoreCase));

            // método para calcular valor total  
            static double CalcularValorTotal(DateTime dataEntrada, DateTime dataSaida, Suite suite)
            {
                int diasDeEstadia = (int)(dataSaida - dataEntrada).TotalDays;

                double valorTotal;

                if (diasDeEstadia > 10)
                {
                    double valorDiariaComDesconto = suite.ValorDiaria * 0.9;
                    valorTotal = diasDeEstadia * valorDiariaComDesconto;
                }
                else
                {
                    valorTotal = diasDeEstadia * suite.ValorDiaria;
                }

                return valorTotal;
            }

            // fim método valor total

        }

        // fim método cadastrar



        // método consultar
        public void Consultar()
        {
            Console.WriteLine("O que você deseja consultar?: Cliente(1); Suite(2); Reserva(3): ");
            int escolhaConsultar = EscolhaCSR();

            switch (escolhaConsultar)
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

        public void ConsultarCliente(string nome)
        {
            string loop;
            do
            {
                Console.WriteLine("Insira o nome do cliente que deseja consultar: ");
                string ConsultarNomeCliente = Console.ReadLine();

                Pessoa pessoa = BuscarCliente(nome);
                if (pessoa != null)
                {
                    Console.WriteLine($"Nome: {Pessoas[i].Nome} - Idade: {Pessoas[i].Idade} - Gênero: {Pessoas[i].Genero} - Profissão: {Pessoas[i].Profissao}");
                }
                else
                {
                    Console.WriteLine($"Cliente '{nome}' não encontrado no sistema.");
                }     

                Console.WriteLine("Deseja consultar outro cliente? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase));
        }
        
        private Pessoa BuscarCliente(string nome)
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
        

        public void ConsultarSuite(int numero)
        {
            string loop;
            do
            {
                Console.WriteLine("Insira o número da suíte que deseja consultar: ");
                int ConsultarNumeroSuite = Console.ReadLine();

                Suite suite = BuscarSuite(numero);
                if (suite != null)
                {
                    Console.WriteLine($"{i + 1}. Número: {Suites[i].Numero} - Capacidade: {Suites[i].Capacidade} - Valor Diária: {Suites[i].ValorDiaria}");
                }
                else
                {
                    Console.WriteLine($"Suíte '{numero}' não encontrada no sistema.");
                }     

                Console.WriteLine("Deseja consultar outra suíte? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase));
        }

        private Suite BuscarSuite(int numero)
        {
            foreach (Suite suite in Suites)
            {
                if (suite.Numero.Equals(numero))
                {
                    return suite;
                }
            }
            return null;
        }
        

        public void ConsultarReserva(int id)
        {
            string loop;
            do
            {
                Console.WriteLine("Insira o id da reserva que deseja consultar: ");
                int ConsultarIdReserva = Console.ReadLine();

                Reserva reserva = BuscarReserva(id);
                if (reserva != null)
                {
                    Console.WriteLine($"{i + 1}. Id: {Reservas[i].Id} - Id Cliente: {Reservas[i].PessoaId} - Número da suíte: {Reservas[i].SuiteNumero} - Data entrada: {Reservas[i].DataEntrada} - Data entrada: {Reservas[i].DataSaida} - Valor Final: R${Reservas[i].ValorFinal}");
                }
                else
                {
                    Console.WriteLine($"Reserva '{id}' não encontrada no sistema.");
                }     

                Console.WriteLine("Deseja consultar outra reserva? (S/N): ");
                loop = Console.ReadLine();

            } while (loop.Equals("S", StringComparison.OrdinalIgnoreCase));
        }

        private Suite BuscarReserva(int id)
        {
            foreach (Reserva reserva in Reservas)
            {
                if (reserva.Id.Equals(id))
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
            Console.WriteLine("O que você deseja listar?: Cliente(1); Suite(2); Reserva(3): ");
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

        public void ListarClientes()
        {
            Console.WriteLine("Clientes:\n");
            for (int i = 0; i < Pessoas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Pessoas[i].Nome} - Idade: {Pessoas[i].Idade} - Gênero: {Pessoas[i].Genero} - Profissão: {Pessoas[i].Profissao}");
            }
        }

        public void ListarSuites()
        {
            Console.WriteLine("Suítes:\n");
            for (int i = 0; i < Suites.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Número: {Suites[i].Numero} - Capacidade: {Suites[i].Capacidade} - Valor Diária: {Suites[i].ValorDiaria}");
            }
        }

        public void ListarReservas()
        {
            Console.WriteLine("Reservas:\n");
            for (int i = 0; i < Reservas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Id: {Reservas[i].Id} - Id Cliente: {Reservas[i].PessoaId} - Número da suíte: {Reservas[i].SuiteNumero} - Data entrada: {Reservas[i].DataEntrada} - Data entrada: {Reservas[i].DataSaida} - Valor Final: R${Reservas[i].ValorFinal}");
            }
        }

        // fim método listar


        // filtragem de erros
        public int Escolha() // escolha menu
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 4)
            {
                Console.WriteLine("Escolha inválida! Tente Novamente. Cadastrar(1); Consultar(2); Listar(3); Sair(4): ");
            }
            return escolha;
        }

        public int EscolhaCSR() // escolha Cliente/Suíte/Reserva CSR
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 3)
            {
                Console.WriteLine("Escolha inválida! Tente Novamente. Cliente(1); Suite(2); Reserva(3): ");
            }
            return escolha;
        }

    }
}
