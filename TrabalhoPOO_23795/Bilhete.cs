using System;

public abstract class Bilhete
{
    public decimal Preco { get; set; }
    public bool Disponivel { get; set; }

    public abstract void VenderBilhete();
}
