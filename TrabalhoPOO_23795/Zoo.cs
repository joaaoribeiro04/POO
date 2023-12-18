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
                    alimentacao.AlimentarAnimal(animais);
                    break;

                case "4":
                    limpeza.LimparJaulaAnimal(animais);
                    break;

                case "5":
                    espetaculo.RealizarEspetaculo();
                    break;

                case "6":
                    bilhete.VenderBilhete();
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