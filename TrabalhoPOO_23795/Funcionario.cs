using System;

/// <summary>
/// Representa a entidade de um funcion�rio no zool�gico.
/// </summary>
public class Funcionario
{
    /// <summary>
    /// Obt�m ou define o nome do funcion�rio.
    /// </summary>
    public string? Nome { get; set; }

    /// <summary>
    /// Obt�m ou define a senha do funcion�rio.
    /// </summary>
    public string? Senha { get; set; }

    /// <summary>
    /// Inicializa uma nova inst�ncia da classe Funcionario com o nome e senha especificados.
    /// </summary>
    /// <param name="nome">O nome do funcion�rio.</param>
    /// <param name="senha">A senha do funcion�rio.</param>
    public Funcionario(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }

    /// <summary>
    /// Autentica o funcion�rio comparando a senha fornecida com a senha do funcion�rio.
    /// </summary>
    /// <param name="senhaDigitada">A senha digitada pelo usu�rio para autentica��o.</param>
    /// <returns>Retorna true se a autentica��o for bem-sucedida, caso contr�rio, retorna false.</returns>
    public bool Autenticar(string senhaDigitada)
    {
        return Senha == senhaDigitada;
    }
}
