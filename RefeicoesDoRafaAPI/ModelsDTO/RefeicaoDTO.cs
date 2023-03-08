using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace RefeicoesDoRafaAPI.Models
{
    public class RefeicaoDTO
    {
        public int idRefeicao { get; set; }

        public decimal preco { get; set; }

        public string nomeRefeicao { get; set; }


    }

}