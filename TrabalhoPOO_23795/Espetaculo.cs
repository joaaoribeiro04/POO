using System;

public class Espetaculo
{
    private TimeSpan duracao;

    public string? Nome { get; set; }
    public TimeSpan Duracao { get => duracao; set => duracao = value; }

    public virtual void RealizarEspetaculo()
    {
        Console.Write("Escolha o tipo de espetáculo (1. Aéreo, 2. Aquático, 3. Terrestre): ");
        if (int.TryParse(Console.ReadLine(), out int escolhaEspetaculo))
        {
            Espetaculo espetaculo;

            switch (escolhaEspetaculo)
            {
                case 1:
                    espetaculo = new EspetaculoAereo();
                    break;
                case 2:
                    espetaculo = new EspetaculoAquatico();
                    break;
                case 3:
                    espetaculo = new EspetaculoTerrestre(); 
                    break;
                default:
                    Console.WriteLine("Escolha inválida.");
                    return;
            }

            espetaculo.RealizarEspetaculo();
        }
        else
        {
            Console.WriteLine("Escolha inválida. Insira um número.");
        }
    }
}

