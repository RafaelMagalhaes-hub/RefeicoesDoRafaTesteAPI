using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RefeicoesDoRafaAPI.Models
{
    [PrimaryKey("idPedido")]
    public class Pedido
    {
        public int idPedido { get; set; }

        [NotNull]
        public Cliente cliente { get; set; }

        public string clientecpf { get; set; }

        [NotNull]
        public Refeicao refeicao { get; set; }

        public int refeicaoidRefeicao { get; set; }

        [NotNull]
        public DateTime horaSolicitacao { get; set; }

        [NotNull]
        public bool isPedidoEntregue { get; set; }

        [AllowNull]
        public string observacoesSobreOPedido { get; set; }
        
    }
}
