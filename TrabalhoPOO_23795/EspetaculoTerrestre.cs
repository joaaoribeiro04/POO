using System;

/// <summary>
/// Representa a classe específica para espetáculos terrestres no zoológico.
/// </summary>
public class EspetaculoTerrestre : Espetaculo, IEspetaculo
{
    /// <summary>
    /// Implementação do método para realizar um espetáculo terrestre.
    /// </summary>
    public override void RealizarEspetaculo()
    {
        Console.WriteLine("A realizar espetáculo terrestre.");
    }
}
