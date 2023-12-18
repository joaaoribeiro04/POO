using System.Text.Json;

class Zoo
{
    private List<Animal> animais;
    private AssistenciaVeterinaria veterinaria;
    private Alimentacao alimentacao;
    private LimpezaJaulas limpeza;
    private Espetaculo espetaculo;
    private Bilhete? bilhete;

    private string? caminhoArquivo;


    public Zoo()
    {
        animais = new List<Animal>();
        veterinaria = new AssistenciaVeterinaria();
        alimentacao = new Alimentacao();
        limpeza = new LimpezaJaulas();
        espetaculo = new Espetaculo();
        bilhete = new Bilhete { Preco = 20m, Disponivel = true };
        caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados_zoo.txt");
    }


    private Funcionario? funcionarioLogado;

    public bool Login(string nome, string senha)
    {
        if (nome == "joao" && senha == "joao")
        {
            funcionarioLogado = new Funcionario(nome, senha);
            Console.WriteLine($"Bem-vindo, {nome}!");
            return true;
        }
        else
        {
            Console.WriteLine("Credenciais inválidas. Tente novamente.");
            return false;
        }
    }

    public void Menu()
    {
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Adicionar animal");
            Console.WriteLine("2. Realizar exame veterinário");
            Console.WriteLine("3. Alimentar animais");
            Console.WriteLine("4. Limpar jaulas");
            Console.WriteLine("5. Realizar espetáculo");
            Console.WriteLine("6. Vender bilhete");
            Console.WriteLine("7. Mostrar animais");
            Console.WriteLine("8. Salvar dados");
            Console.WriteLine("9. Carregar dados");
            Console.WriteLine("0. Sair");

            Console.Write("Escolha uma opção: ");
            string? opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Animal? animal = new Animal();
                    animal.AdicionarAoZoo(animais);
                    break;

                case "2":
                    veterinaria.RealizarExameVeterinario(animais);
                    break;

                case "3":
                    Console.Write("Insira o nome do animal a ser alimentado: ");
                    string? nomeAlimentar = Console.ReadLine();

                    Animal? animalAlimentar = animais.Find(a => a.Nome == nomeAlimentar);

                    if (animalAlimentar != null)
                    {
                        Console.WriteLine("Escolha o tipo de comida (1. Carnívora, 2. Herbívora, 3. Omnívora): ");
                        if (int.TryParse(Console.ReadLine(), out int escolhaComida))
                        {
                            TipoComida? tipoComida = null;

                            switch (escolhaComida)
                            {
                                case 1:
                                    tipoComida = new TipoComida { Nome = "Carnívora", Descricao = "Comida para carnívoros" };
                                    break;
                                case 2:
                                    tipoComida = new TipoComida { Nome = "Herbívora", Descricao = "Comida para herbívoros" };
                                    break;
                                case 3:
                                    tipoComida = new TipoComida { Nome = "Omnívora", Descricao = "Comida para onívoros" };
                                    break;
                                default:
                                    Console.WriteLine("Escolha inválida de comida.");
                                    break;
                            }

                            if (tipoComida != null)
                            {
                                alimentacao.TiposComida.Add(tipoComida);

                                Console.WriteLine($"A alimentar {animalAlimentar.Nome} com comida {tipoComida.Nome}.");
                                alimentacao.Alimentar(animalAlimentar);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Escolha inválida. Insira um número.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Animal não encontrado.");
                    }
                    break;


                case "4":
                    Console.Write("Insira o nome do animal cuja jaula será limpa: ");
                    string? nomeLimpeza = Console.ReadLine();
                    Animal? animalLimpeza = animais.Find(a => a.Nome == nomeLimpeza);

                    if (animalLimpeza != null)
                    {
                        limpeza.LimparJaula(animalLimpeza);
                    }
                    else
                    {
                        Console.WriteLine("Animal não encontrado.");
                    }
                    break;

                case "5":
                    Console.Write("Insira a data do espetáculo (dd/mm/yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime dataEspetaculo))
                    {
                        Console.Write("Insira a hora do espetáculo (hh:mm): ");
                        if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan horaEspetaculo))
                        {
                            dataEspetaculo = dataEspetaculo.Add(horaEspetaculo);

                            espetaculo.RealizarEspetaculo(dataEspetaculo);
                        }
                        else
                        {
                            Console.WriteLine("Hora inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data inválida.");
                    }
                    break;

                case "6":
                    Console.Write("Insira a data do espetáculo (dd/MM/yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out dataEspetaculo))
                    {
                        Console.Write("Insira a hora do espetáculo (HH:mm): ");
                        if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan horaEspetaculo))
                        {
                            dataEspetaculo = dataEspetaculo.Add(horaEspetaculo);
                            espetaculo.RealizarEspetaculo(dataEspetaculo);
                        }
                        else
                        {
                            Console.WriteLine("Hora inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data inválida.");
                    }
                    break;


                case "7":
                    Console.WriteLine(Animal.MostrarAnimais(animais));
                    break;

                case "8":
                    Animal.WriteAnimalsToFile(animais);
                    Console.WriteLine("Dados salvos com sucesso.");
                    break;

                case "9":
                    var a = Animal.ReadAnimalsFromFile();
                    if (a != null) { animais = a; }
                    Console.WriteLine("Dados carregados com sucesso.");
                    break;


                case "0":
                    Console.WriteLine("A sair do programa.");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        } while (true);
    }
}