using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace RefeicoesDoRafaAPI.Models
{
    [PrimaryKey("idRefeicao")]
    public class Refeicao
    {
        public int idRefeicao { get; set; }

        [Precision(6,2)]
        public decimal preco { get; set; }

        [NotNull]
        public string nomeRefeicao { get; set; }

        [NotNull]
        public string tipoProteina { get; set; }

        [NotNull]
        public string tipoAcompanhamento { get; set; }

    }

}