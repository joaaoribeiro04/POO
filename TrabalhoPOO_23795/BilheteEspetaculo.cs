using System;

/// <summary>
/// Representa a classe de bilhete para espetáculos no zoológico.
/// </summary>
public class BilheteEspectaculo : Bilhete
{
    /// <summary>
    /// Implementação do método abstrato para vender um bilhete de espetáculo.
    /// </summary>
    public override void VenderBilhete()
    {
        Console.Write("Insira a data do espetáculo (dd/MM/yyyy): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataEspetaculo))
        {
            Console.Write("Insira a hora do espetáculo (HH:mm): ");
            if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan horaEspetaculo))
            {
                dataEspetaculo = dataEspetaculo.Add(horaEspetaculo);
                if (Disponivel)
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.WriteLine($"Bilhete vendido para o espetáculo no dia {dataEspetaculo:dd/MM/yyyy 'às' HH:mm} por {Preco:N2}€");
                    Disponivel = false;
                }
                else
                {
                    Console.WriteLine("Desculpe, bilhetes esgotados.");
                }
            }
            else
            {
                Console.WriteLine("Hora inválida.");
            }
        }
        else
        {
            Console.WriteLine("Data inválida.");
        }
    }
}
