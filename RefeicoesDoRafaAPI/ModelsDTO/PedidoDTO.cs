using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RefeicoesDoRafaAPI.Models
{
    public class PedidoDTOBase
    {
        public int idRefeicao { get; set; }

        public string cpfCliente { get; set; }       

        public string observacoesSobreOPedido { get; set; }

    }

    public class PedidoDTOUpdate : PedidoDTOBase
    {
        public int idPedido { get; set; }

    }

    public class PedidoDTOConsulta : PedidoDTOBase 
    {

        public string nomeRefeicao { get; set; }

        public decimal preco { get; set; }

        public int idPedido { get; set; }

        public bool isPedidoEntregue { get; set; }

    }
}
