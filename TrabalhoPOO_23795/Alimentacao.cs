using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Alimentacao
{
    public List<TipoComida> TiposComida { get; set; }

    public Alimentacao()
    {
        TiposComida = new List<TipoComida>();
    }

    public void Alimentar(Animal animal)
    {
        Console.WriteLine($"A alimentar {animal.Nome}.");
    }
}