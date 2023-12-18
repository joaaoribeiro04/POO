using System;

/// <summary>
/// Representa a classe específica para espetáculos aquáticos no zoológico.
/// </summary>
public class EspetaculoAquatico : Espetaculo, IEspetaculo
{
    /// <summary>
    /// Implementação do método para realizar um espetáculo aquático.
    /// </summary>
    public override void RealizarEspetaculo()
    {
        Console.WriteLine("A realizar espetáculo aquático.");
    }
}
