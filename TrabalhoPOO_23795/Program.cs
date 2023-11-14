class Program
{
    static void Main()
    {
        Zoo meuZoo = new();
        // Pedir ao usuário que faça login
        Console.Write("Nome do funcionário: ");
        string nomeUsuario = Console.ReadLine();

        Console.Write("Senha: ");
        string senhaUsuario = Console.ReadLine();

        // Tenta fazer login
        if (meuZoo.Login(nomeUsuario, senhaUsuario))
        {
            // Funcionário autenticado, agora você pode acessar as funcionalidades do zoológico
            meuZoo.Menu();
        }
        meuZoo.Menu();
    }
}