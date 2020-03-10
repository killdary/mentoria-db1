using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.IngredienteCategorias.Commands;
using Restaurante.Application.IngredienteCategorias.Queries;

namespace Restaurante.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredienteCategoriaController : BaseController
    {
        

        public IngredienteCategoriaController(IMediator mediator)
            :base(mediator)
        {}

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var response = await _mediator.Send(new TodosIngredienteCategoriasQuery());


            return Response(response);
        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetPorId(Guid id)
        {

            var response = await _mediator.Send(new BuscarIgrendienteCategoriaPorIdQuery(id));

            return Response(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateIngredienteCategoriaCommand request)
        {
            var response = await _mediator.Send(request);

            return Response(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateIngredienteCategoriaCommand request)
        {
            var response = await _mediator.Send(request);

            return Response(response);
        }



        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteIngredienteCategoriaCommand() { Id = id});

            return Response(response);
        }
    }
}