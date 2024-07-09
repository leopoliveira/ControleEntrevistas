using System.Net.Mime;

using ControleEntrevistas.Core.Application.DTOs;
using ControleEntrevistas.Core.Application.Services;
using ControleEntrevistas.Core.Entidade;
using ControleEntrevistas.Core.Entidade.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

using static NuGet.Packaging.PackagingConstants;

namespace ControleEntrevistas.API.Controllers.V1
{
    [Route("api/v1/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CandidaturaController : ControllerBase
    {
        private readonly ICandidaturaService _service;

        public CandidaturaController(ICandidaturaService service)
        {
            _service = service;
        }

        [HttpGet("candidaturas")]
        public async Task<ActionResult<IEnumerable<CandidaturaResponse>>> GetAll([FromQuery] GetCandidaturasFilterDto filterDto)
        {
            var candidaturas = await _service.GetByFiltersAsync(filterDto);

            return Ok(candidaturas);
        }
    }
}
