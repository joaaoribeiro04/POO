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
            meuZoo.Menu();
        }
        meuZoo.Menu();
    }
}