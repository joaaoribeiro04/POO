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
    public string? TipoAnimal { get; set; }

    public void RealizarEspetaculo(DateTime dataEspetaculo)
    {
        Console.WriteLine($"A realizar espetáculo no dia {dataEspetaculo:dd/MM/yyyy 'às' HH:mm}.");
    }
}
