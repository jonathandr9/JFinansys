using AutoMapper;
using JFinansysBackEnd.Domain.IServices;
using JFinansysBackEnd.Domain.Models;
using JFinansysBackEnd.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace JFinansysBackEnd.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IEntradaService _entradaService;
        private readonly IMapper _mapper;

        public EntradaController(IEntradaService entradaService,
            IMapper mapper)
        {
            _entradaService = entradaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListarDespesas()
        {
            var despesas = _entradaService.ListarEntradas();

            return Ok(despesas);
        }

        [HttpGet("{ID?}")]
        public IActionResult BuscarDespesasPorID(string ID)
        {
            var despesa = _entradaService.ListaEntradaPorID(ID);

            return Ok(despesa);
        }

        [HttpPost]
        public IActionResult InserirDespesa(EntradaPost despesaPost)
        {
            var entrada = _mapper.Map<Entrada>(despesaPost);

            _entradaService.IncluirEntrada(entrada);

            return Ok();
        }

        [HttpPut("{ID?}")]
        public IActionResult AtualizarDespesa(string ID, EntradaPost despesaPost)
        {
            var entrada = _mapper.Map<Entrada>(despesaPost);

            _entradaService.AtualizarEntrada(ID, entrada);

            return NoContent();
        }
    }
}
