using Restaurante.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Entities
{
    public class Receita : Entity
    {
        public string Nome { get; set; }
        public ICollection<Porcao> Porcoes { get; set; }
        public ICollection<Passo> Passos { get; set; }
    }
}
