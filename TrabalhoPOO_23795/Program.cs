using System;

/// <summary>
/// Classe principal que contém o método de inicialização do programa.
/// </summary>
class Program
{
    /// <summary>
    /// Método principal que inicia o programa.
    /// </summary>
    /// <param name="args">Argumentos de linha de comando (não utilizados neste contexto).</param>
    static void Main(string[] args)
    {
        // Inicialização do objeto Zoo.
        Zoo zoo = new Zoo();

        // Solicitar nome do utilizador.
        Console.Write("Nome do utilizador: ");
        string? nomeUsuario = Console.ReadLine();

        // Solicitar senha.
        Console.Write("Senha: ");
        string? senha = Console.ReadLine();

        // Verificar autenticação.
        if (zoo.Login(nomeUsuario, senha))
        {
            // Se autenticado, exibir o menu do zoológico.
            zoo.Menu();
        }
        else
        {
            // Se não autenticado, mostrar mensagem e encerrar o programa.
            Console.WriteLine("Credenciais inválidas. O programa será encerrado.");
        }
    }
}
