using System;
using System.Collections.Generic;

/// <summary>
/// Representa a classe responsável pela assistência veterinária no zoológico.
/// </summary>
class AssistenciaVeterinaria
{
    /// <summary>
    /// Obtém ou define o veterinário responsável pela assistência veterinária.
    /// </summary>
    public string? VeterinarioResponsavel { get; set; }

    /// <summary>
    /// Realiza um exame médico no animal especificado.
    /// </summary>
    /// <param name="animal">O animal a ser examinado.</param>
    public static void RealizarExame(Animal animal)
    {
        Console.WriteLine($"A realizar exame médico no {animal.Nome}.");
    }

    /// <summary>
    /// Realiza um exame veterinário num animal da lista de animais do zoológico.
    /// </summary>
    /// <param name="animais">Lista de animais no zoológico.</param>
    public static void RealizarExameVeterinario(List<Animal> animais)
    {
        Console.Write("Insira o nome do animal a ser examinado: ");
        string? nomeExame = Console.ReadLine();
        Animal? animalExame = animais.Find(a => a.Nome == nomeExame);

        if (animalExame != null)
        {
            RealizarExame(animalExame);
        }
        else
        {
            Console.WriteLine("Animal não encontrado.");
        }
    }
}
