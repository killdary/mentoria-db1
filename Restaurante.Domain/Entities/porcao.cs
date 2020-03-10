using Restaurante.Domain.Common;
using Restaurante.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Entities
{
    public class Porcao : Entity
    {
        public Ingrediente Ingrediente { get; set; }
        public Receita Receita { get; set; }
        public float Quantidade { get; set; }
        public EUnidade Unidade { get; set; }
    }
}
