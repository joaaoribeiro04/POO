using System;

class AssistenciaVeterinaria
{
    public string? VeterinarioResponsavel { get; set; }

    public static void RealizarExame(Animal animal)
    {
        Console.WriteLine($"A realizar exame médico no {animal.Nome}.");
    }

    public static void RealizarExameVeterinario(List<Animal> animais)
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
