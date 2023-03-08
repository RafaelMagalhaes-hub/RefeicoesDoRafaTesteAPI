using Microsoft.EntityFrameworkCore;
using RefeicoesDoRafaAPI.Dao;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace RefeicoesDoRafaAPI.Models
{
    [PrimaryKey("id")]    
    public class Endereco
    {
        public int id { get; set; }

        [StringLength(8)]
        [NotNull]
        public string cep { get; set; }

        [NotNull]
        public int numero { get; set; }

        [NotNull]
        public string complemento { get; set; }

    }
}
