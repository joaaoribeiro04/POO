using System;
using System.Collections.Generic;

/// <summary>
/// Representa a classe responsável pela gestão da alimentação dos animais no zoológico.
/// </summary>
class Alimentacao
{
    /// <summary>
    /// Obtém ou define a lista de tipos de comida disponíveis.
    /// </summary>
    public List<TipoComida> TiposComida { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Alimentacao"/>.
    /// </summary>
    public Alimentacao()
    {
        TiposComida = new List<TipoComida>();
    }

    /// <summary>
    /// Realiza a alimentação de um animal específico, permitindo a escolha do tipo de comida.
    /// </summary>
    /// <param name="animais">A lista de animais no zoológico.</param>
    public void AlimentarAnimal(List<Animal> animais)
    {
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
                    TiposComida.Add(tipoComida);

                    Console.WriteLine($"A alimentar {animalAlimentar.Nome} com comida {tipoComida.Nome}.");
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
    }
}
