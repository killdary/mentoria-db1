using Restaurante.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Entities
{
    public class IngredienteCategoria : Entity
    {
        public string Descricao { get; set; }
        public ICollection<Ingrediente> Ingredientes { get; set; }
        
        public void AlterarDados(string descricao)
        {
            Descricao = descricao;
            DateUpdate = DateTime.Now;
        }
    }
}
