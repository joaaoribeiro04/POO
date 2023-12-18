using System;

class AssistenciaVeterinaria
{
    public string? VeterinarioResponsavel { get; set; }

    public void RealizarExame(Animal animal)
    {
        Console.WriteLine($"A realizar exame médico no {animal.Nome}.");
    }

    public void RealizarExameVeterinario(List<Animal> animais)
    {
        Console.Write("Insira o nome do animal a ser examinado: ");
        string? nomeExame = Console.ReadLine();
        Animal? animalExame = animais.Find(a => a.Nome == nomeExame);

        if (animalExame != null)
        {
            RealizarExame(animalExame);
        }
        else
        {
            Console.WriteLine("Animal não encontrado.");
        }
    }
}
