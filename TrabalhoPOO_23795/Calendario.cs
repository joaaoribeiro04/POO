using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Calendario
{
    public List<DateTime>? Eventos { get; set; }

    public void AdicionarEvento(DateTime data)
    {
        Eventos.Add(data);
        Console.WriteLine($"Evento adicionado para {data}");
    }
}