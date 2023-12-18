using System;
using System.Text.Json;

class Animal
{
    public string? Nome { get; set; }
    public int Idade { get; set; }
    public string? TipoAnimal { get; set; }

    public static Animal CriarNovoAnimal()
    {
        Console.Write("Insira o nome do animal: ");
        string? nomeAnimal = Console.ReadLine();

        Console.Write("Insira a idade do animal: ");
        if(!int.TryParse(Console.ReadLine(), out int idadeAnimal))
        {
            Console.WriteLine("erro");
        }

        Console.Write("Tipo de animal: ");
        string? tipoAnimal = Console.ReadLine();

        return new Animal
        {
            Nome = nomeAnimal,
            Idade = idadeAnimal,
            TipoAnimal = tipoAnimal
        };
    }
    public static string MostrarAnimais(List<Animal> animais)
    {
        string result = "Animais no zoológico:\n";
        foreach (var animal in animais)
        {
            result += $"Nome: {animal.Nome} - Idade: {animal.Idade} anos - Tipo: {animal.TipoAnimal}\n";
        }
        return result;
    }

    public void AdicionarAoZoo(List<Animal> animais)
    {
        Animal novoAnimal = CriarNovoAnimal();
        animais.Add(novoAnimal);
        Console.WriteLine($"{novoAnimal.Nome} foi adicionado ao zoológico.");
    }

    public static void WriteAnimalsToFile(List<Animal> animais)

    {

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados_zoo.txt"); ;

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

    public static List<Animal>? ReadAnimalsFromFile()
    {
        
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados_zoo.txt"); ;

        try
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Animal>>(jsonString);
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (IOException ioEx)
        {
            Console.WriteLine(ioEx.Message);
            return null;
        }
    }
}
