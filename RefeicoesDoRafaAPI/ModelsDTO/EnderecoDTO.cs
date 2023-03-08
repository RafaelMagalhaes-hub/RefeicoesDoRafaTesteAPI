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
    public class EnderecoDTO
    {
        public string cep { get; set; }

        public int numero { get; set; }

        public string complemento { get; set; }


    }
}
