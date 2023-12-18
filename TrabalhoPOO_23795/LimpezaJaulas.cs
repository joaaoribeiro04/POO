using System;
using System.Collections.Generic;

/// <summary>
/// Classe responsável pela limpeza das jaulas dos animais.
/// </summary>
class LimpezaJaulas
{
    /// <summary>
    /// Limpa a jaula do animal especificado.
    /// </summary>
    /// <param name="animais">Lista de animais no zoológico.</param>
    public void LimparJaulaAnimal(List<Animal> animais)
    {
        Console.Write("Insira o nome do animal cuja jaula será limpa: ");
        string? nomeLimpeza = Console.ReadLine();
        Animal? animalLimpeza = animais.Find(a => a.Nome == nomeLimpeza);

        if (animalLimpeza != null)
        {
            LimparJaula(animalLimpeza);
        }
        else
        {
            Console.WriteLine("Animal não encontrado.");
        }
    }

    private void LimparJaula(Animal animal)
    {
        Console.WriteLine($"A limpar a jaula de {animal.Nome}.");
    }
}
