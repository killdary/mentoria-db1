using Restaurante.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Entities
{
    public class Ingrediente : Entity
    {
        public string Descricao { get; set; }
        public IngredienteCategoria IngredienteCategoria { get; set; }

        public ICollection<Porcao> Porcoes { get; set; }

        public void AlterarDados(string descricao)
        {
            Descricao = descricao;
            DateUpdate = DateTime.Now;
        }
    }
}
