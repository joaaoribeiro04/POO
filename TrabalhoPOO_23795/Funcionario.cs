using System;

/// <summary>
/// Representa a entidade de um funcionário no zoológico.
/// </summary>
public class Funcionario
{
    /// <summary>
    /// Obtém ou define o nome do funcionário.
    /// </summary>
    public string? Nome { get; set; }

    /// <summary>
    /// Obtém ou define a senha do funcionário.
    /// </summary>
    public string? Senha { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe Funcionario com o nome e senha especificados.
    /// </summary>
    /// <param name="nome">O nome do funcionário.</param>
    /// <param name="senha">A senha do funcionário.</param>
    public Funcionario(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }

    /// <summary>
    /// Autentica o funcionário comparando a senha fornecida com a senha do funcionário.
    /// </summary>
    /// <param name="senhaDigitada">A senha digitada pelo usuário para autenticação.</param>
    /// <returns>Retorna true se a autenticação for bem-sucedida, caso contrário, retorna false.</returns>
    public bool Autenticar(string senhaDigitada)
    {
        return Senha == senhaDigitada;
    }
}
