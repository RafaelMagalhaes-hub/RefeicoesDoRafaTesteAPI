using Microsoft.AspNetCore.Mvc;
using RefeicoesDoRafaAPI.Dao;
using RefeicoesDoRafaAPI.Models;

namespace RefeicoesDoRafaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RefeicaoController : ControllerBase
    {
        private readonly Context _context;

        public RefeicaoController(ILogger<RefeicaoController> logger, Context context)
        {
            _context = context;
        }       

        [HttpGet]
        public IEnumerable<Refeicao> Get()
        {
            var refeicoes = _context.refeicao.ToArray();
            return refeicoes;
        }

    }
}