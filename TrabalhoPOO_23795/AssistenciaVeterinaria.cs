using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AssistenciaVeterinaria
{
    public string? VeterinarioResponsavel { get; set; }

    public void RealizarExame(Animal animal)
    {
        Console.WriteLine($"Realizando exame médico em {animal.Nome}.");
    }
}
