class Program
{
    public static void Main(string[] args)
    {
        Zoo zoo = new Zoo();

        Console.Write("Nome de usuário: ");
        string nomeUsuario = Console.ReadLine();

        Console.Write("Senha: ");
        string senha = Console.ReadLine();


        if (zoo.Login(nomeUsuario, senha))
        {
           
            zoo.Menu();
        }
        else
        {
            
            Console.WriteLine("Credenciais inválidas. O programa será encerrado.");
        }
    }

}