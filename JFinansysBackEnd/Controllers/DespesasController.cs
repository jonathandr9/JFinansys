using AutoMapper;
using JFinansysBackEnd.Domain.IServices;
using JFinansysBackEnd.Domain.Models;
using JFinansysBackEnd.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace JFinansysBackEnd.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {

        private readonly IDespesaService _despesaService;
        private readonly IMapper _mapper;

        public DespesasController(IDespesaService despesaService,
            IMapper mapper)
        {
            _despesaService = despesaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListarDespesas()
        {
            var despesas = _despesaService.ListarDepesas();

            return Ok(despesas);
        }

        [HttpGet("{ID?}")]
        public IActionResult BuscarDespesasPorID(string ID)
        {
            var despesa = _despesaService.ListaDespesaPorID(ID);

            return Ok(despesa);
        }

        [HttpPost]
        public IActionResult InserirDespesa(DespesaPost despesaPost)
        {
            var despesa = _mapper.Map<Despesa>(despesaPost);

            _despesaService.IncluirDespesa(despesa);

            return Ok();
        }

        [HttpPut("{ID?}")]
        public IActionResult AtualizarDespesa(string ID,DespesaPost despesaPost)
        {
            var despesa = _mapper.Map<Despesa>(despesaPost);

            _despesaService.AtualizarDespesa(ID, despesa);

            return NoContent();
        }
    }
}
