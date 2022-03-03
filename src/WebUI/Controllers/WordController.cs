using Anagrama.Api.Application.Common.Models;
using Anagrama.Api.Application.Features.Words.Commands.Create;
using Anagrama.Api.Application.Features.Words.Dtos;
using Anagrama.Api.Application.Features.Words.Queries.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anagrama.Api.WebUI.Controllers
{
    public class WordController : ApiControllerBase
    {
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateWordRequest request)
        {
            return await base.Command<CreateWordRequest, WordDto>(request);
        }

        /// <summary>
        /// Consultar Words
        /// </summary>
        /// <remarks>
        /// Obtiene los registros para la entidad <code>Word</code> de acuerdo a los filtros entregados con la clase <code>GetAllWordRequest</code>
        /// 
        /// Ejemplo de consumo:
        ///
        ///     GET /api/Word/GetAll?Id=1&amp;FirstWord=A&amp;SecondWord=a&amp;PageNumber=1&amp;PageSize=10
        /// </remarks>
        /// <param name="request">Filtro para obtener los datos</param>
        /// <response code="200">Retorna los datos para el filtro entregado</response>
        [ProducesResponseType(typeof(PaginatedList<WordDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllWordRequest request)
        {
            return await base.Query<GetAllWordRequest, PaginatedList<WordDto>>(request);
        }
    }
}
