using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infra.Writting.Data
{
    public class WritingContextSeed
    {

        private static readonly List<IngredienteCategoria> _ingredienteCategorias = new List<IngredienteCategoria>
        {
            new IngredienteCategoria(){Descricao = "Tempero"},
            new IngredienteCategoria(){Descricao = "Carne"},
            new IngredienteCategoria(){Descricao = "Peixe"}
        };

        public async static void PopulateTestData(WritingContext context)
        {
            var houveAlteracao = false;

            if (!context.IngredienteCategorias.Any(x => x.Descricao == _ingredienteCategorias.FirstOrDefault().Descricao))
            {
                context.IngredienteCategorias.AddRange(_ingredienteCategorias);
                houveAlteracao = true;
            }
            if (houveAlteracao)
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
