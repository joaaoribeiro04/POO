using System.Text.Json;

class Zoo
{
    private List<Animal> animais;
    private AssistenciaVeterinaria veterinaria;
    private Alimentacao alimentacao;
    private LimpezaJaulas limpeza;
    private Espetaculo espetaculo;
    private Bilhete bilhete;

    string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados_zoo.txt");


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


    private Funcionario funcionarioLogado;

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

    public void AdicionarAnimal(Animal animal)
    {
        animais.Add(animal);
        Console.WriteLine($"{animal.Nome} foi adicionado ao zoológico.");
    }

    public void WriteAnimalsToFile()
        
    {

        string filePath = caminhoArquivo; 

        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(animais, options);


            File.WriteAllText(filePath, jsonString);
        }

        catch (JsonException jsonEx)
        {
            Console.WriteLine(jsonEx.Message);
           
        }
        catch (IOException ioEx)
        {
            Console.WriteLine(ioEx.Message);
           
        }
    }

    public void ReadAnimalsFromFile()
    {
        string filePath = caminhoArquivo; 

        try
        {
            string jsonString = File.ReadAllText(filePath);
            animais = JsonSerializer.Deserialize<List<Animal>>(jsonString);
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine(jsonEx.Message);
          
        }
        catch (IOException ioEx)
        {
            Console.WriteLine(ioEx.Message);
            
        }
    }

    public void MostrarAnimais()
    {
        Console.WriteLine("Animais no zoológico:");
        foreach (var animal in animais)
        {
            Console.WriteLine($"Nome: {animal.Nome} - Idade: {animal.Idade} anos - Tipo: {animal.TipoAnimal}");
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
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Insira o nome do animal: ");
                    string nomeAnimal = Console.ReadLine();
                    Console.Write("Insira a idade do animal: ");
                    int idadeAnimal = int.Parse(Console.ReadLine());

                    Console.Write("Tipo de animal: ");
                    string tipoAnimal = Console.ReadLine();

                    Animal novoAnimal;
                    {
                        novoAnimal = new Animal();
                    }

                    novoAnimal.Nome = nomeAnimal;
                    novoAnimal.Idade = idadeAnimal;
                    novoAnimal.TipoAnimal = tipoAnimal;

                    AdicionarAnimal(novoAnimal);
                    break;

                case "2":
                    Console.Write("Insira o nome do animal a ser examinado: ");
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
                    Console.Write("Insira o nome do animal a ser alimentado: ");
                    string nomeAlimentar = Console.ReadLine();

                    Animal animalAlimentar = animais.Find(a => a.Nome == nomeAlimentar);

                    if (animalAlimentar != null)
                    {
                        Console.WriteLine("Escolha o tipo de comida (1. Carnívora, 2. Herbívora, 3. Omnívora): ");
                        if (int.TryParse(Console.ReadLine(), out int escolhaComida))
                        {
                            TipoComida tipoComida = null;

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
                    bilhete.VenderBilhete();
                    break;

                case "7":
                    MostrarAnimais();
                    break;

                case "8":
                    WriteAnimalsToFile();
                    Console.WriteLine("Dados salvos com sucesso.");
                    break;

                case "9":
                    ReadAnimalsFromFile();
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