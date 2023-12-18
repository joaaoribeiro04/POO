using System;

/// <summary>
/// Representa a classe abstrata para bilhetes no zoológico.
/// </summary>
public abstract class Bilhete
{
    /// <summary>
    /// Obtém ou define o preço do bilhete.
    /// </summary>
    public decimal Preco { get; set; }

    /// <summary>
    /// Obtém ou define se o bilhete está disponível para venda.
    /// </summary>
    public bool Disponivel { get; set; }

    /// <summary>
    /// Método abstrato para vender um bilhete.
    /// </summary>
    public abstract void VenderBilhete();
}
