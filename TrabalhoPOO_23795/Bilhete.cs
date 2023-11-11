using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Bilhete
{
    public decimal Preco { get; set; }
    public bool Disponivel { get; set; }

    public void VenderBilhete()
    {
        if (Disponivel)
        {
            Console.WriteLine($"Bilhete vendido por {Preco}.");
            Disponivel = false;
        }
        else
        {
            Console.WriteLine("Desculpe, bilhetes esgotados.");
        }
    }
}
