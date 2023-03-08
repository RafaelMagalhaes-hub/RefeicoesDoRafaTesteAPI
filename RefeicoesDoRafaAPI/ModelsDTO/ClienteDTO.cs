using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace RefeicoesDoRafaAPI.Models
{
    public class ClienteDTO
    {

        public string cpf { get; set; }

        public string nomeCompletoCliente { get; set; }

        public string email { get; set; }

        public string whatsapp { get; set; }

        public EnderecoDTO endereco { get; set; }  

    }
}
