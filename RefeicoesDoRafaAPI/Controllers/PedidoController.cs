using Microsoft.AspNetCore.Mvc;
using RefeicoesDoRafaAPI.Dao;
using RefeicoesDoRafaAPI.Models;

namespace RefeicoesDoRafaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly Context _context;

        public PedidoController(ILogger<PedidoController> logger, Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PedidoDTOConsulta> Get()
        {
            var pedidos = _context.pedido.ToArray();
            var pedidosDTO = new List<PedidoDTOConsulta>();
            
            foreach (var pedido in pedidos)
            {
                var refeicao = _context.Find<Refeicao>(pedido.refeicaoidRefeicao);
                var pedidoDTOConsulta = new PedidoDTOConsulta() 
                {
                    nomeRefeicao = refeicao.nomeRefeicao,
                    preco = refeicao.preco,
                    idRefeicao = pedido.refeicaoidRefeicao,
                    cpfCliente = pedido.clientecpf,
                    observacoesSobreOPedido = pedido.observacoesSobreOPedido,   
                    isPedidoEntregue = pedido.isPedidoEntregue,
                    idPedido= pedido.idPedido,  
                };
                pedidosDTO.Add(pedidoDTOConsulta);
            }            

            return pedidosDTO.ToArray();
        }

        [HttpPost]
        public void Post(PedidoDTOBase pedidoDTObase)
        {
            var clienteCadastrado = _context.Find<Cliente>(pedidoDTObase.cpfCliente);
            var refeicaoCadastrada = _context.Find<Refeicao>(pedidoDTObase.idRefeicao);
            var pedido = new Pedido()
            { 
                cliente = clienteCadastrado,
                horaSolicitacao = DateTime.Now, 
                isPedidoEntregue = false,
                observacoesSobreOPedido = pedidoDTObase.observacoesSobreOPedido,
                refeicao = refeicaoCadastrada
            };

            _context.Add(pedido);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int idPedido)
        {
            var pedidoQueDeveSerCancelado = _context.Find<Pedido>(idPedido);
            _context.Remove<Pedido>(pedidoQueDeveSerCancelado);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put(PedidoDTOUpdate pedidoDTOUpdate)
        {
            var clienteCadastrado = _context.Find<Cliente>(pedidoDTOUpdate.cpfCliente);
            var refeicaoCadastrada = _context.Find<Refeicao>(pedidoDTOUpdate.idRefeicao);
            var pedido = new Pedido()
            {
                cliente = clienteCadastrado,
                horaSolicitacao = DateTime.Now,                
                observacoesSobreOPedido = pedidoDTOUpdate.observacoesSobreOPedido,
                refeicao = refeicaoCadastrada,
                idPedido = pedidoDTOUpdate.idPedido
            };

            _context.Update(pedido);
            _context.SaveChanges();
        }

        


    }
}