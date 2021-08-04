using AwesomeGym.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.Entidades
{
  public class Aluno
  {
    protected Aluno() { }
    public Aluno(string nome, string endereco, DateTime dataNascimento, StatusAlunoEnum status)
    {
      Nome = nome;
      Endereco = endereco;
      DataNascimento = dataNascimento;
      Status = StatusAlunoEnum.Ativo;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Endereco { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public StatusAlunoEnum Status { get; private set; }
  }
}
