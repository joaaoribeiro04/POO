using System;

class LimpezaJaulas
{
    public void LimparJaulaAnimal(List<Animal> animais)
    {
        Console.Write("Insira o nome do animal cuja jaula será limpa: ");
        string? nomeLimpeza = Console.ReadLine();
        Animal? animalLimpeza = animais.Find(a => a.Nome == nomeLimpeza);

        if (animalLimpeza != null)
        {
            LimparJaula(animalLimpeza);
        }
        else
        {
            Console.WriteLine("Animal não encontrado.");
        }
    }

    private void LimparJaula(Animal animal)
    {
        Console.WriteLine($"A limpar a jaula de {animal.Nome}.");
    }
}
