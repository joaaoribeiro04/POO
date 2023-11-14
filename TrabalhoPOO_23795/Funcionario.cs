using System;

public class Funcionario
{
    public string? Nome { get; set; }
    public string? Senha { get; set; }

    public Funcionario(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }

    public bool Autenticar(string senhaDigitada)
    {
        return Senha == senhaDigitada;
    }
}
