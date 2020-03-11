using Newtonsoft.Json;
using Restaurante.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Restaurante.Api.IntegrationTest.IngredienteCategoria
{
    public class IngredienteCategoriaControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {

        private readonly CustomWebApplicationFactory<Startup> _factory;

        public IngredienteCategoriaControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        #region GET
        [Fact]
        public async Task GetTodosIngredienteCategorias_Returns200Code()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"/api/ingredienteCategoria");

            var data = JsonConvert.DeserializeObject<QueryResult>( await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.Equal(3, data.RowCount);
        }


        #endregion

    }
}
