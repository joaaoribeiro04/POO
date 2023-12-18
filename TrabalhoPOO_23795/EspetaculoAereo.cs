using System;

/// <summary>
/// Representa a classe específica para espetáculos aéreos no zoológico.
/// </summary>
public class EspetaculoAereo : Espetaculo, IEspetaculo
{
    /// <summary>
    /// Implementação do método para realizar um espetáculo aéreo.
    /// </summary>
    public override void RealizarEspetaculo()
    {
        Console.WriteLine("A realizar espetáculo aéreo.");
    }
}
