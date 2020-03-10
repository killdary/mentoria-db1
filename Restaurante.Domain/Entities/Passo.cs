using Restaurante.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Entities
{
    public class Passo : Entity
    {
        public string Descricao { get; set; }
        public Receita Receita { get; set; }
    }
}
