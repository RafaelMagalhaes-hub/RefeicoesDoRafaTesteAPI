using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RefeicoesDoRafaAPI.Models
{
    [PrimaryKey("cpf")]
    public class Cliente
    {
        [StringLength(11)]
        public string cpf { get; set; }

        [NotNull]
        [MaxLength(150)]
        public string nomeCompletoCliente { get; set; }

        [NotNull]
        [MaxLength(150)]
        public string email { get; set; }

        [NotNull]
        [StringLength(11)]
        public string whatsapp { get; set; }

        public Endereco endereco { get; set; }

        [NotNull]
        public int enderecoid { get; set; }

    }
}
