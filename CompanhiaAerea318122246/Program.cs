using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CompanhiaAerea318122246.Listas;
using System.Text;
using System.Threading.Tasks;
 
namespace CompanhiaAerea318122246
{
    class Program
    {
        static void CriarListadeVoos()
        {
            VoosDisponibilizados voos = new VoosDisponibilizados();
            voos.VoosExistentes();
        }

        static void PesquisarPassageiro(List<Passageiro> lista)
        {
            string CPF = string.Empty;

            Console.WriteLine("Em qual lista de espera se encontra");
            Console.WriteLine("VOO: \n\n 1 - BH/Rio \n\n 2 - BH/SP \n\n 3 - BH/Recife");
            int voo = int.Parse(Console.ReadLine());

            Console.WriteLine("Consulta de Passageiro");
            Console.Write("Por favor, informe o CPF: ");
            CPF = Console.ReadLine();

            var verificarSeExistePassageiroComCpfInformado = lista.Count(x => x.NumeroVoo == voo && x.CPF == CPF);

            if (verificarSeExistePassageiroComCpfInformado != 0)
            {
                var dadosDoPassageiro = lista.Where(x => x.CPF == CPF);

                foreach (var item in dadosDoPassageiro)
                {
                    Console.WriteLine("Exibir dados do passageiro:");

                    Console.WriteLine($"Nome: {item.Nome}");
                    Console.WriteLine($"Sobrenome: {item.Sobrenome}");
                    Console.WriteLine($"CPF: {item.Cpf}");
                    Console.WriteLine($"Telefone: {item.Telefone}");
                    Console.WriteLine($"Endereço: {item.Endereco}");
                    Console.WriteLine($"Passagem: {item.NumeroPassagem} ");
                    Console.WriteLine($"Número de seu vôo: {item.NumeroVoo}");
                    Console.WriteLine($"Poltrona: {item.NumeroPoltrona}");
                    Console.WriteLine($"Horário: {item.Horario}");
                    Console.WriteLine("________________________________________");
                }
            }
            else Console.WriteLine("Passageiro não localizado neste vôo.");
        }

        static List<Passageiro> CadastroDoPassageiro(List<Passageiro> lista)
        {
            string CPF, Nome, Sobrenome, Endereco, Telefone;
            int numeroPassagem, numerodoVoo, numerodaPoltrona;
            DateTime Horario;

            Console.WriteLine("Cadastro do Passageiro: ");

            bool paradaLoop = true;
            do
            {
                Console.WriteLine("CPF: ");
                CPF = Console.ReadLine();

                ValidaInformacoes validacoes = new ValidaInformacoes();
                paradaLoop = validacoes.ValidaCPF(CPF);

                if (paradaLoop == false)
                {
                    Console.WriteLine("Número de CPF incorreto, favor inserir um número de CPF válido para prosseguir.");
                    paradaLoop = true;
                }
                else
                {
                    var cpfExistente = lista.Count(x => x.CPF == CPF);

                    if (cpfExistente != 0)
                    {
                        Console.WriteLine("Número de CPF já cadastrado no sistema.");
                    }
                    else
                    {
                        paradaLoop = false;
                    }
                }

            } while (paradaLoop);

            Console.WriteLine("Nome:");
            Nome = Console.ReadLine();

            Console.WriteLine("Sobrenome:");
            Sobrenome = Console.ReadLine();

            Console.WriteLine("Endereço:");
            Endereco = Console.ReadLine();

            Console.WriteLine("Telefone:");
            Telefone = Console.ReadLine();

            Console.WriteLine("VOO: \n\n 1 - BH/Rio \n\n 2 - BH/SP \n\n 3 - BH/Recife");
            numerodoVoo = int.Parse(Console.ReadLine());

            if (lista.Count(x => x.NumeroVoo == numerodoVoo) != 0)
            {
                int numeroUltimaPaumerssagemVendida = lista.Max(x => x.NumeroPassagem);
                numeroPassagem = numeroUltimaPaumerssagemVendida + 1;

                int numeroUltimaPoltronaVendida = lista.Max(x => x.NumeroPoltrona);
                numerodaPoltrona = numeroUltimaPoltronaVendida + 1;
            }
            else
            {
                numeroPassagem = 1;
                numerodaPoltrona = 1;
            }

            if (numerodoVoo == 1)
                Horario = new DateTime(2019, 1, 1, 13, 00, 00);
            else if (numerodoVoo == 2)
                Horario = new DateTime(2019, 1, 1, 13, 30, 00);
            else if (numerodoVoo == 3)
                Horario = new DateTime(2019, 1, 1, 14, 00, 00);
            else
                Horario = new DateTime();

            if (lista.Count(x => x.NumeroVoo == numerodoVoo) >= 0 &&
                lista.Count(x => x.NumeroVoo == numerodoVoo) <= 1)
            {
                lista.Add(new Passageiro
                {
                    Nome = Nome,
                    Sobrenome = Sobrenome,
                    Cpf = CPF,
                    Telefone = Telefone,
                    Endereco = Endereco,
                    NumeroPassagem = numeroPassagem,
                    NumeroVoo = numerodoVoo,
                    NumeroPoltrona = numerodaPoltrona,
                    Horario = Horario,
                    VendaBloqueada = false
                });
            }
            else
            {
                lista.Add(new Passageiro
                {
                    Nome = Nome,
                    Sobrenome = Sobrenome,
                    Cpf = CPF,
                    Telefone = Telefone,
                    Endereco = Endereco,
                    NumeroPassagem = numeroPassagem,
                    NumeroVoo = numerodoVoo,
                    NumeroPoltrona = numerodaPoltrona,
                    Horario = Horario,
                    VendaBloqueada = true
                });
            }

            return lista;
        }
        static List<Passageiro> ExcluirPassageiro(List<Passageiro> lista)
        {
            string CPF;
            Console.WriteLine("CPF: ");
            CPF = Console.ReadLine();

            var verificaCpfExistente = lista.Count(x => x.CPF == CPF);
            if (verificaCpfExistente != 0)
            {
                Console.WriteLine("Confirma exclusão de passageiro?");
                Console.WriteLine("1 - Sim\n\n 2 - Não");
                string resposta = Console.ReadLine();
                if (resposta == "1")
                {
                    lista.RemoveAll(x => x.CPF == CPF);
                    Console.WriteLine("Passageiro excluído.");
                }
                else
                {
                    Console.WriteLine("Exlusão cancelada.");
                    Console.WriteLine("Não foi possível realizar a exclusão.");
                }
            }
            else
            {
                Console.WriteLine("Cadastro não existente.");
            }

            return lista;
        }

        static List<Espera> CadastrarPassageiroNaListaDeEspera(List<Espera> listadeEspera, List<Passageiro> listadePassageiro)
        {

            var informacoesAdicionais = from x in listadePassageiro where x.VendaBloqueada == true select x;

            foreach (var item in informacoesAdicionais)
            {
                int listaDeEsperaPassageiroPorVoo = listadeEspera.Count(x => x.NumeroVoo == item.NumeroVoo);

                if (listaDeEsperaPassageiroPorVoo <= 5)
                {
                    var cadastroPresenteNaEspera = from x in listadeEspera where x.CPF == item.CPF select x;
                    if (cadastroPresenteNaEspera != null)
                    {
                        listadeEspera.Add(new Espera
                        {
                            Nome = item.Nome,
                            Sobrenome = item.Sobrenome,
                            CPF = item.CPF,
                            Endereco = item.Endereco,
                            Telefone = item.Telefone,
                            NumerodoVoo = item.NumerodoVoo
                        });
                    }
                    else Console.WriteLine("Passageiro já se encontra na lista de espera.");
                }
                else Console.WriteLine("Por favor aguarde uma nova lista, a atual se encontra cheia.");
            }

            return listadeEspera;
        }

        static void ExibeListaPassageiro(List<Passageiro> listaPassageiro)
        {
            foreach (var item in listaPassageiro)
            {
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Sobrenome: {item.Sobrenome}");
                Console.WriteLine($"CPF: {item.Cpf}");
                Console.WriteLine($"Telefone: {item.Telefone}");
                Console.WriteLine($"Endereço: {item.Endereco}");
                Console.WriteLine($"Passagem: {item.NumeroPassagem} ");
                Console.WriteLine($"Número de seu vôo: {item.NumeroVoo}");
                Console.WriteLine($"Poltrona: {item.NumeroPoltrona}");
                Console.WriteLine($"Horário: {item.Horario}");
                Console.WriteLine("_______________________________________");
            }
        }

        static void ExibeListaDeEspera(List<Espera> listaEspera)
        {
            Console.WriteLine("Em qual lista de espera se encontra");
            Console.WriteLine("VOO: \n\n 1 - BH/Rio \n\n 2 - BH/SP \n\n 3 - BH/Recife");
            int valor = int.Parse(Console.ReadLine());

            var query = listaEspera.Where(x => x.NumeroVoo == valor);

            foreach (var item in query)
            {
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Sobrenome: {item.Sobrenome}");
                Console.WriteLine($"CPF: {item.Cpf}");
                Console.WriteLine($"Telefone: {item.Telefone}");
                Console.WriteLine($"Endereço: {item.Endereco}");
                Console.WriteLine($"Passagem: {item.NumeroPassagem} ");
                Console.WriteLine($"Número de seu vôo: {item.NumeroVoo}");
                Console.WriteLine($"Poltrona: {item.NumeroPoltrona}");
                Console.WriteLine($"Horário: {item.Horario}");
                Console.WriteLine("_______________________________________");
            }
        }

        static void Main(string[] args)
        {
            List<Passageiro> listaPassageiro = new List<Passageiro>();
            List<Espera> listaDeEspera = new List<Espera>();
            CriaListaVoos();


            bool paradaBool = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Tela Inicial");
                Console.WriteLine("F1 - Lista dos Passageiros");
                Console.WriteLine("F2 - Localizar Passageiro");
                Console.WriteLine("F3 - Cadastrar um Passageiro");
                Console.WriteLine("F4 - Exluir um Passageiro");
                Console.WriteLine("F5 - Localizar Lista de Espera");
                Console.WriteLine("Esc - Fechar Sistema");

                ConsoleKeyInfo tecla;
                Console.WriteLine("Tecla");
                tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.F1:
                        Console.Clear();
                        Console.WriteLine("F1");
                        ExibeListaPassageiro(listaPassageiro);
                        Console.WriteLine("Tecle qualquer comando para prosseguir.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.F2:
                        Console.Clear();
                        Console.WriteLine("F2");
                        PesquisaPassageiro(listaPassageiro);
                        Console.WriteLine("Tecle qualquer comando para prosseguir.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.F3:
                        Console.Clear();
                        Console.WriteLine("F3");
                        listaPassageiro = CadastraPassageiro(listaPassageiro);
                        listaDeEspera = CadastraPassageiroListaDeEspera(listaDeEspera, listaPassageiro);
                        listaPassageiro.RemoveAll(x => x.VendaBloqueada == true);
                        Console.WriteLine("Tecle qualquer comando para prosseguir.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.F4:
                        Console.Clear();
                        Console.WriteLine("F4");
                        listaPassageiro = ExcluirPassageiro(listaPassageiro);
                        Console.WriteLine("Tecle qualquer comando para prosseguir.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.F5:
                        Console.Clear();
                        Console.WriteLine("F5");
                        ExibeListaDeEspera(listaDeEspera);
                        Console.WriteLine("Tecle qualquer comando para prosseguir.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("Esc");
                        paradaBool = false;
                        Console.WriteLine("Sistema encerrada.");
                        Console.WriteLine("Tecle qualquer comando para prosseguir.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inexistente.");
                        Console.Clear();
                        break;
                }
            }
            while (paradaBool);
        }
    }
}
