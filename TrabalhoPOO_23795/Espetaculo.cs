using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Espetaculo
{
    private TimeSpan duracao;

    public string? Nome { get; set; }
    public TimeSpan Duracao { get => duracao; set => duracao = value; }

    public void RealizarEspetaculo()
    {
        Console.WriteLine($"Realizando espetáculo: {Nome} ({Duracao} horas).");
    }
}
