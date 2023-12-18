using System;
using System.Collections.Generic;

class Alimentacao
{
    public List<TipoComida> TiposComida { get; set; }

    public Alimentacao()
    {
        TiposComida = new List<TipoComida>();
    }

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
