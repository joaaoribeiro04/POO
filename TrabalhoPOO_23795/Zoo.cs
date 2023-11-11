class Zoo
{
    private List<Animal> animais;
    private AssistenciaVeterinaria veterinaria;
    private Alimentacao alimentacao;
    private Calendario calendario;
    private LimpezaJaulas limpeza;
    private Espetaculo espetaculo;
    private Bilhete bilhete;

    public Zoo()
    {
        animais = new List<Animal>();
        veterinaria = new AssistenciaVeterinaria();
        alimentacao = new Alimentacao();
        calendario = new Calendario();
        limpeza = new LimpezaJaulas();
        espetaculo = new Espetaculo { Nome = "Show de Leões", Duracao = TimeSpan.FromHours(1) };
        bilhete = new Bilhete { Preco = 20.0m, Disponivel = true };
    }

    public void AdicionarAnimal(Animal animal)
    {
        animais.Add(animal);
        Console.WriteLine($"{animal.Nome} foi adicionado ao zoológico.");
    }

    public void Menu()
    {
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Adicionar animal");
            Console.WriteLine("2. Realizar exame veterinário");
            Console.WriteLine("3. Alimentar animais");
            Console.WriteLine("4. Adicionar evento ao calendário");
            Console.WriteLine("5. Limpar jaulas");
            Console.WriteLine("6. Realizar espetáculo");
            Console.WriteLine("7. Vender bilhete");
            Console.WriteLine("8. Mostrar animais");
            Console.WriteLine("9. Sair");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome do animal: ");
                    string nomeAnimal = Console.ReadLine();
                    Console.Write("Digite a idade do animal: ");
                    int idadeAnimal = int.Parse(Console.ReadLine());

                    Console.Write("Tipo de animal (Leao/Elefante): ");
                    string tipoAnimal = Console.ReadLine();

                    Animal novoAnimal;
                    if (tipoAnimal.ToLower() == "leao")
                    {
                        novoAnimal = new Leao();
                    }
                    else if (tipoAnimal.ToLower() == "elefante")
                    {
                        novoAnimal = new Elefante();
                    }
                    else
                    {
                        novoAnimal = new Animal();
                    }

                    novoAnimal.Nome = nomeAnimal;
                    novoAnimal.Idade = idadeAnimal;

                    AdicionarAnimal(novoAnimal);
                    break;

                case "2":
                    Console.Write("Digite o nome do animal a ser examinado: ");
                    string nomeExame = Console.ReadLine();
                    Animal animalExame = animais.Find(a => a.Nome == nomeExame);

                    if (animalExame != null)
                    {
                        veterinaria.RealizarExame(animalExame);
                    }
                    else
                    {
                        Console.WriteLine("Animal não encontrado.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Escolha o tipo de comida (1. Carnívoro, 2. Herbívoro, 3. Onívoro): ");
                    if (int.TryParse(Console.ReadLine(), out int escolhaComida))
                    {
                        TipoComida tipoComida = null;

                        switch (escolhaComida)
                        {
                            case 1:
                                tipoComida = new TipoComida { Nome = "Carnívoro", Descricao = "Comida para carnívoros" };
                                break;
                            case 2:
                                tipoComida = new TipoComida { Nome = "Herbívoro", Descricao = "Comida para herbívoros" };
                                break;
                            case 3:
                                tipoComida = new TipoComida { Nome = "Onívoro", Descricao = "Comida para onívoros" };
                                break;
                            default:
                                Console.WriteLine("Escolha inválida de comida.");
                                break;
                        }

                        if (tipoComida != null)
                        {
                            alimentacao.TiposComida.Add(tipoComida);

                            Console.WriteLine($"Alimentando animais com {tipoComida.Nome}...");

                            foreach (var animal in animais)
                            {
                                Console.WriteLine($"Alimentando {animal.Nome} com {tipoComida.Nome}.");
                                alimentacao.Alimentar(animal);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Escolha inválida. Insira um número.");
                    }
                    break;


                case "4":
                    Console.Write("Digite a data do evento (dd/mm/yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime dataEvento))
                    {
                        calendario.AdicionarEvento(dataEvento);
                    }
                    else
                    {
                        Console.WriteLine("Data inválida.");
                    }
                    break;

                case "5":
                    Console.Write("Digite o nome do animal cuja jaula será limpa: ");
                    string nomeLimpeza = Console.ReadLine();
                    Animal animalLimpeza = animais.Find(a => a.Nome == nomeLimpeza);

                    if (animalLimpeza != null)
                    {
                        limpeza.LimparJaula(animalLimpeza);
                    }
                    else
                    {
                        Console.WriteLine("Animal não encontrado.");
                    }
                    break;

                case "6":
                    espetaculo.RealizarEspetaculo();
                    break;

                case "7":
                    bilhete.VenderBilhete();
                    break;

                case "8":
                    MostrarAnimais();
                    break;

                case "9":
                    Console.WriteLine("Saindo do programa.");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        } while (true);
    }

    public void MostrarAnimais()
    {
        Console.WriteLine("Animais no zoológico:");
        foreach (var animal in animais)
        {
            Console.WriteLine($"{animal.Nome} - Idade: {animal.Idade} anos");
        }
    }
}