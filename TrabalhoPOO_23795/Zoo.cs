﻿using System.Text.Json;

class Zoo
{
    private List<Animal> animais;
    private AssistenciaVeterinaria veterinaria;
    private Alimentacao alimentacao;
    private Calendario calendario;
    private LimpezaJaulas limpeza;
    private Espetaculo espetaculo;
    private Bilhete bilhete;

    string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados_zoo.txt");





    public Zoo()
    {
        animais = new List<Animal>();
        veterinaria = new AssistenciaVeterinaria();
        alimentacao = new Alimentacao();
        calendario = new Calendario();
        limpeza = new LimpezaJaulas();
        espetaculo = new Espetaculo { Nome = "Show de Leões", Duracao = TimeSpan.FromHours(1) };
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

        string filePath = caminhoArquivo; // File path

        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(animais, options);


            File.WriteAllText(filePath, jsonString);
        }

        catch (JsonException jsonEx)
        {
            Console.WriteLine(jsonEx.Message);
            // Handle JSON serialization/deserialization exceptions
        }
        catch (IOException ioEx)
        {
            Console.WriteLine(ioEx.Message);
            // Handle I/O exceptions
            // Handle other exceptions
        }
    }

    public void ReadAnimalsFromFile()
    {
        string filePath = caminhoArquivo; // File path

        try
        {
            string jsonString = File.ReadAllText(filePath);
            animais = JsonSerializer.Deserialize<List<Animal>>(jsonString);
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine(jsonEx.Message);
            // Handle JSON serialization/deserialization exceptions
        }
        catch (IOException ioEx)
        {
            Console.WriteLine(ioEx.Message);
            // Handle I/O exceptions
            // Handle other exceptions
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
            Console.WriteLine("4. Adicionar evento ao calendário");
            Console.WriteLine("5. Limpar jaulas");
            Console.WriteLine("6. Realizar espetáculo");
            Console.WriteLine("7. Vender bilhete");
            Console.WriteLine("8. Mostrar animais");
            Console.WriteLine("9. Sair");
            Console.WriteLine("10. Salvar dados");
            Console.WriteLine("11. Carregar dados");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Insira o nome do animal: ");
                    string nomeAnimal = Console.ReadLine();
                    Console.Write("Insira a idade do animal: ");
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

                            Console.WriteLine($"A alimentar animais com {tipoComida.Nome}...");

                            foreach (var animal in animais)
                            {
                                Console.WriteLine($"A alimentar {animal.Nome} com {tipoComida.Nome}.");
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
                    Console.Write("Insira a data do evento (dd/mm/yyyy): ");
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
                    Console.WriteLine("A sair do programa.");
                    return;

                case "10":
                    WriteAnimalsToFile();
                    Console.WriteLine("Dados salvos com sucesso.");
                    break;

                case "11":
                    ReadAnimalsFromFile();
                    Console.WriteLine("Dados carregados com sucesso.");
                    break;

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
            Console.WriteLine($"Nome: {animal.Nome} - Idade: {animal.Idade} anos - Tipo: {animal.Tipo}");
        }
    }
}