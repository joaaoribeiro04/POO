using System;

class Espetaculo
{
    private TimeSpan duracao;

    public string? Nome { get; set; }
    public TimeSpan Duracao { get => duracao; set => duracao = value; }
    public string? TipoAnimal { get; set; }

    public void RealizarEspetaculo()
    {
        Console.Write("Insira a data do espetáculo (dd/MM/yyyy): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataEspetaculo))
        {
            Console.Write("Insira a hora do espetáculo (HH:mm): ");
            if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan horaEspetaculo))
            {
                dataEspetaculo = dataEspetaculo.Add(horaEspetaculo);

                Console.WriteLine($"A realizar espetáculo no dia {dataEspetaculo:dd/MM/yyyy 'às' HH:mm}.");
            }
            else
            {
                Console.WriteLine("Hora inválida.");
            }
        }
        else
        {
            Console.WriteLine("Data inválida.");
        }
    }
}
