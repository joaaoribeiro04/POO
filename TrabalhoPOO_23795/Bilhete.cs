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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"Bilhete vendido por {Preco:N2}€");
            Disponivel = false;
        }
        else
        {
            Console.WriteLine("Desculpe, bilhetes esgotados.");
        }
    }
}
