using AwesomeGym.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.Entidades
{
  public class Aparelho
  {
    public int Id { get; private set; }
    public string Nome{ get; private set; }
    public string Descricao { get; private set; }
    public DateTime DataCompra { get; private set; }
    
    public StatusAparelhoEnum Status { get; private set; }
  }
}
