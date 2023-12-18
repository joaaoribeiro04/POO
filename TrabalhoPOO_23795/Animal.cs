using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

/// <summary>
/// Representa a classe que define as características e operações relacionadas aos animais no zoológico.
/// </summary>
class Animal
{
    /// <summary>
    /// Obtém ou define o nome do animal.
    /// </summary>
    public string? Nome { get; set; }

    /// <summary>
    /// Obtém ou define a idade do animal.
    /// </summary>
    public int Idade { get; set; }

    /// <summary>
    /// Obtém ou define o tipo de animal.
    /// </summary>
    public string? TipoAnimal { get; set; }

    /// <summary>
    /// Cria um novo animal, solicitando ao utilizador informações como nome, idade e tipo de animal.
    /// </summary>
    /// <returns>Uma instância do tipo <see cref="Animal"/> criada com as informações fornecidas.</returns>
    public static Animal CriarNovoAnimal()
    {
        Console.Write("Insira o nome do animal: ");
        string? nomeAnimal = Console.ReadLine();

        Console.Write("Insira a idade do animal: ");
        if (!int.TryParse(Console.ReadLine(), out int idadeAnimal))
        {
            Console.WriteLine("Erro ao obter a idade.");
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

    /// <summary>
    /// Retorna uma string formatada com a lista de animais no zoológico.
    /// </summary>
    /// <param name="animais">Lista de animais no zoológico.</param>
    /// <returns>String formatada com a lista de animais.</returns>
    public static string MostrarAnimais(List<Animal> animais)
    {
        string result = "Animais no zoológico:\n";
        foreach (var animal in animais)
        {
            result += $"Nome: {animal.Nome} - Idade: {animal.Idade} anos - Tipo: {animal.TipoAnimal}\n";
        }
        return result;
    }

    /// <summary>
    /// Adiciona um novo animal à lista de animais do zoológico.
    /// </summary>
    /// <param name="animais">Lista de animais no zoológico.</param>
    public void AdicionarAoZoo(List<Animal> animais)
    {
        Animal novoAnimal = CriarNovoAnimal();
        animais.Add(novoAnimal);
        Console.WriteLine($"{novoAnimal.Nome} foi adicionado ao zoológico.");
    }

    /// <summary>
    /// Grava a lista de animais num ficheiro JSON.
    /// </summary>
    /// <param name="animais">Lista de animais a ser gravada.</param>
    public static void WriteAnimalsToFile(List<Animal> animais)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados_zoo.txt");

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

    /// <summary>
    /// Lê a lista de animais de um ficheiro JSON.
    /// </summary>
    /// <returns>Lista de animais lida a partir do ficheiro.</returns>
    public static List<Animal>? ReadAnimalsFromFile()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados_zoo.txt");

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
