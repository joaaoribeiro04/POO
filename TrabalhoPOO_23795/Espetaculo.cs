using System;

/// <summary>
/// Representa a classe base para espetáculos no zoológico.
/// </summary>
public class Espetaculo : IEspetaculo
{
    private TimeSpan duracao;

    /// <summary>
    /// Obtém ou define o nome do espetáculo.
    /// </summary>
    public string? Nome { get; set; }

    /// <summary>
    /// Obtém ou define a duração do espetáculo.
    /// </summary>
    public TimeSpan Duracao { get => duracao; set => duracao = value; }

    /// <summary>
    /// Implementação do método virtual para realizar um espetáculo genérico.
    /// </summary>
    public virtual void RealizarEspetaculo()
    {
        Console.Write("Escolha o tipo de espetáculo (1. Aéreo, 2. Aquático, 3. Terrestre): ");
        if (int.TryParse(Console.ReadLine(), out int escolhaEspetaculo))
        {
            IEspetaculo espetaculo;

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
